using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using Managers.Buildings;
using Managers.Meta;
using Managers.Resources;
using UnityEngine;
using Util;
using Random = UnityEngine.Random;

namespace Managers
{
    public class PrimaryManager : MonoBehaviour
    {
        private const float Speed = .01f;

        private List<IManager> _managers = new List<IManager>();

        private void Start()
        {
            SetupManager<BuildingManager>();
            SetupManager<ResourceManager>();
            SetupManager<OutputManager>();
            var saveInfo = GetSaveInfo();
            Setup(saveInfo);

            StartCoroutine(Process());
        }

        private SaveInfo GetSaveInfo()
        {
            //TODO REAL SAVE!
            var saveInfo = new SaveInfo();
            var resourcesCount = new Dictionary<ResourceEnum, AdvancedNumber>();
            var resourcesRate = new Dictionary<ResourceEnum, AdvancedNumber>();
            var metaResourcesCount = new Dictionary<MetaResourceEnum, AdvancedNumber>();
            var metaResourcesRate = new Dictionary<MetaResourceEnum, AdvancedNumber>();

            Temp(MetaResourceEnum.Food, metaResourcesCount, metaResourcesRate);
            Temp(MetaResourceEnum.Production, metaResourcesCount, metaResourcesRate);
            Temp(MetaResourceEnum.Population, metaResourcesCount, metaResourcesRate);

            Temp(ResourceEnum.Fish, resourcesCount, resourcesRate);
            Temp(ResourceEnum.Meat, resourcesCount, resourcesRate);
            Temp(ResourceEnum.Berry, resourcesCount, resourcesRate);
            Temp(ResourceEnum.Wood, resourcesCount, resourcesRate);
            Temp(ResourceEnum.Stone, resourcesCount, resourcesRate);
            Temp(ResourceEnum.Clay, resourcesCount, resourcesRate);
            saveInfo.ResourcesCount = resourcesCount;
            saveInfo.ResourcesRate = resourcesRate;
            saveInfo.MetaResourcesCount = metaResourcesCount;
            saveInfo.MetaResourcesRate = metaResourcesRate;
            return saveInfo;
        }

        private void Temp<T>(MetaResourceEnum temp, T count, T rate)
            where T : Dictionary<MetaResourceEnum, AdvancedNumber>
        {
            count.Add(temp, 0);
            rate.Add(temp, Random.value);
        }

        private void Temp<T>(ResourceEnum temp, T count, T rate) where T : Dictionary<ResourceEnum, AdvancedNumber>
        {
            count.Add(temp, 0);
            rate.Add(temp, Random.value);
        }


        private void Setup(SaveInfo saveInfo)
        {
            foreach (var manager in _managers)
            {
                manager.InitialSetup();
                manager.Load(saveInfo);
            }
        }

        private T SetupManager<T>() where T : MonoBehaviour, IManager
        {
            var newManager = gameObject.AddComponent<T>();
            _managers.Add(newManager);
            return newManager;
        }

        private IEnumerator Process()
        {
            //Loading
            //Maintain
            while (true)
            {
                try
                {
                    ResourceManager.ThisManager.Advance(Speed);
                    OutputManager.ThisManager.UpdatedResources(ResourceManager.ThisManager
                        .GetResourceDisplayInfos());
                    OutputManager.ThisManager.UpdatedMetaResources(ResourceManager.ThisManager
                        .GetProductionResourceDisplayInfos());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                yield return new WaitForSeconds(Speed);
            }
        }
    }
}
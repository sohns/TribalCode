using System;
using System.Collections;
using System.Collections.Generic;
using CustomClasses;
using Enum;
using Managers.Buildings;
using Managers.Meta;
using Managers.Outputs;
using Managers.Resources;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class PrimaryManager : MonoBehaviour
    {
        private const float Speed = .1f;

        private List<IManager> _managers = new List<IManager>();

        private void Awake()
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

            SetFakeData<MetaResourceEnum, Dictionary<MetaResourceEnum, AdvancedNumber>,
                Dictionary<MetaResourceEnum, AdvancedNumber>>(TempMeta, metaResourcesCount, metaResourcesRate);

            SetFakeData<ResourceEnum, Dictionary<ResourceEnum, AdvancedNumber>,
                Dictionary<ResourceEnum, AdvancedNumber>>(TempResource, resourcesCount, resourcesRate);


            var building = new Dictionary<BuildingEnum, AdvancedNumber>();
            var useless = new Dictionary<BuildingEnum, AdvancedNumber>();

            SetFakeData<BuildingEnum, Dictionary<BuildingEnum, AdvancedNumber>,
                Dictionary<BuildingEnum, AdvancedNumber>>(TempBuilding, building, useless);

            saveInfo.Buildings = building;
            saveInfo.ResourcesCount = resourcesCount;
            saveInfo.ResourcesRate = resourcesRate;
            saveInfo.MetaResourcesCount = metaResourcesCount;
            saveInfo.MetaResourcesRate = metaResourcesRate;            
            return saveInfo;
        }

        private void SetFakeData<TP, TS, TQ>(Action<TP, TS, TQ> action, TS s, TQ q)
        {
            foreach (var aEnum in (TP[]) System.Enum.GetValues(typeof(TP)))
            {
                action(aEnum, s, q);
            }
        }

        private void TempBuilding<T>(BuildingEnum temp, T count, T useless)
            where T : Dictionary<BuildingEnum, AdvancedNumber>
        {
            count.Add(temp, 1);
        }

        private void TempMeta<T>(MetaResourceEnum temp, T count, T rate)
            where T : Dictionary<MetaResourceEnum, AdvancedNumber>
        {
            if (temp == MetaResourceEnum.None)
            {
                return;
            }
            count.Add(temp, 0);
            rate.Add(temp, Random.value);
        }

        private void TempResource<T>(ResourceEnum temp, T count, T rate)
            where T : Dictionary<ResourceEnum, AdvancedNumber>
        {
            if (temp == ResourceEnum.None)
            {
                return;
            }
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
                    foreach (var manager in _managers)
                    {
                        manager.Advance(Speed);
                    }                
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
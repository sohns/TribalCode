using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using Managers.Buildings;
using Managers.Meta;
using Managers.Outputs;
using Managers.Outputs.Loader;
using Managers.Resources;
using UnityEngine;

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
            Setup(LoaderManager.GetSave(LoaderEnum.FakeInfo));
            StartCoroutine(Process());
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
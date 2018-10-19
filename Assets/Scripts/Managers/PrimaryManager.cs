using System;
using System.Collections;
using Managers.Meta;
using Managers.Resources;
using UnityEngine;

namespace Managers
{
    public class PrimaryManager : MonoBehaviour
    {
        private ResourceManager _resourceManager;
        private const float Speed = .01f;

        private void Start()
        {
            //TODO: SAVE
            _resourceManager = new ResourceManager();
            _resourceManager.InitialSetup();
            _resourceManager.Load(new SaveInfo());
            StartCoroutine(Process());
        }

        private IEnumerator Process()
        {
            //Loading
            //Maintain
            while (true)
            {
                try
                {
                    _resourceManager.Advance(Speed);
                    OutputManager.ThisOutputManager.UpdatedResources(_resourceManager.GetResourceDisplayInfos());
                    MetaOutputManager.AnotherOutputManager.UpdatedResources(_resourceManager.GetProductionResourceDisplayInfos());
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
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
            FakeOutputManager.OutputManager.GenerateResource(_resourceManager.GetResourceDisplayInfos());
            FakeOutputManager.OutputManager.GenerateMetaResource(_resourceManager.GetMetaResourceDisplayInfos());
            //Maintain
            while (true)
            {
                try
                {
                    _resourceManager.Advance(Speed);
                    FakeOutputManager.OutputManager.DisplayAdvance(_resourceManager.GetResourceDisplayInfos(),
                        _resourceManager.GetMetaResourceDisplayInfos());
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
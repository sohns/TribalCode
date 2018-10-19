using UnityEngine;
using Enum;
using System.Collections.Generic;
using Managers.Outputs;

namespace Managers
{
    public class MetaOutputManager : MonoBehaviour
    {
        public static MetaOutputManager AnotherOutputManager;

        private Dictionary<MetaResourceEnum, GameObject> _resourceDictionary = new Dictionary<MetaResourceEnum, GameObject>();

        public void UpdatedResources(List<MetaResourceDisplayInfo> productionresourceDisplayInfos)
        {
            foreach (var productionresourceDisplayInfo in productionresourceDisplayInfos)
            {
                if (!_resourceDictionary.ContainsKey(productionresourceDisplayInfo.MetaResourceEnum))
                {
                    continue;
                }

                var singularResourceScript = _resourceDictionary[productionresourceDisplayInfo.MetaResourceEnum].GetComponent<MetaResourceDisplayScript>();
                singularResourceScript.SetValues(productionresourceDisplayInfo);
            }
        }

        private void Awake()
        {
            AnotherOutputManager = this;
        }

        public void ResourceRegistration(MetaResourceEnum metaresourceEnum, GameObject registrationGameObject)
        {
            _resourceDictionary.Add(metaresourceEnum, registrationGameObject);
        }
    }
}
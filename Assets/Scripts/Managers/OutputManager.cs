using UnityEngine;
using Enum;
using System.Collections.Generic;
using Managers.Outputs;

namespace Managers
{
    public class OutputManager : MonoBehaviour
    {
        public static OutputManager ThisOutputManager;

        private Dictionary<ResourceEnum, GameObject> _resourceDictionary = new Dictionary<ResourceEnum, GameObject>();

        public void UpdatedResources(List<ResourceDisplayInfo> resourceDisplayInfos)
        {
            foreach (var resourceDisplayInfo in resourceDisplayInfos)
            {
                if (!_resourceDictionary.ContainsKey(resourceDisplayInfo.ResourceEnum))
                {
                    continue;
                }

                var singularResourceScript = _resourceDictionary[resourceDisplayInfo.ResourceEnum].GetComponent<ResourceDisplayScript>();
                singularResourceScript.SetValues(resourceDisplayInfo);
            }
        }

        private void Awake()
        {
            ThisOutputManager = this;
        }

        public void ResourceRegistration(ResourceEnum resourceEnum, GameObject registrationGameObject)
        {
            _resourceDictionary.Add(resourceEnum, registrationGameObject);
        }
    }
}
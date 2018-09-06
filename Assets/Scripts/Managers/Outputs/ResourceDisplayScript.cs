using Enum;
using System;
using UnityEngine;

namespace Managers.Outputs
{
    public class ResourceDisplayScript : BaseResourceDisplayPrefabScript
    {
        public ResourceEnum ResourceEnum;

        private void Start()
        {
            OutputManager.ThisOutputManager.ResourceRegistration(ResourceEnum,gameObject);
        }
        public void SetValues(ResourceDisplayInfo resourceDisplayInfo)
        {
            if (resourceDisplayInfo.ResourceEnum != ResourceEnum)
            {
                throw new ArgumentException("using the wrong resource enum:" + resourceDisplayInfo.ResourceEnum + "correct resource enum:" + ResourceEnum);
            }

            base.SetValues(resourceDisplayInfo);
        }
    }
}
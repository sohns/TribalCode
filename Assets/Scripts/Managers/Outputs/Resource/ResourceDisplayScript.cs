using System;
using Enum;

namespace Managers.Outputs.Resource
{
    public class ResourceDisplayScript : BaseResourceDisplayScript
    {
        public ResourceEnum ResourceEnum;

        private void Start()
        {
            OutputManager.ThisManager.ResourceRegistration(ResourceEnum,gameObject);
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
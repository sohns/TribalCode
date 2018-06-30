using Enum;

namespace Managers.Outputs
{
    public class ResourceDisplayPrefabScript : BaseResourceDiplayPrefabScript
    {
        public ResourceEnum ResourceEnum;

        public void SetValues(ResourceDisplayInfo resourceDisplayInfo)
        {
            ResourceEnum = resourceDisplayInfo.ResourceEnum;
            base.SetValues(resourceDisplayInfo);
        }
    }
}
using Enum;

namespace Managers.Outputs
{
    public class MetaResourceDisplayPrefabScript : BaseResourceDiplayPrefabScript
    {
        public MetaResourceEnum MetaResourceEnum;

        public void SetValues(MetaResourceDisplayInfo resourceDisplayInfo)
        {
            MetaResourceEnum = resourceDisplayInfo.MetaResourceEnum;
            base.SetValues(resourceDisplayInfo);
        }
    }
}
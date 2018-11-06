using Enum;

namespace Managers.Outputs.Building
{
    public class StorageBuildingDisplayScript : BaseBuildingDisplayScript, IBuildingDisplay
    {
        public void Setup(BuildingEnum buildingEnum)
        {
            BuildingEnum = buildingEnum;
            BuildingType = BuildingType.Storage;
            base.Setup();
        }
    }
}
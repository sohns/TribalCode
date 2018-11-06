using Enum;

namespace Managers.Outputs.Building
{
    public class PopulationAssignmentBuildingDisplayScript : BaseBuildingDisplayScript, IBuildingDisplay
    {
        public void Setup(BuildingEnum buildingEnum)
        {
            BuildingEnum = buildingEnum;
            BuildingType = BuildingType.PopulationAssignment;
            Setup();
        }
    }
}
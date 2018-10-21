using Enum;

namespace Managers.Outputs.Building
{
    public class PopulationAssignmentBuildingDisplayScript : BaseBuildingDisplayScript
    {
        void Start()
        {
            BuildingType = BuildingType.PopulationAssignment;
            Setup();
        }
    }
}
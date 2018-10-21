using Enum;

namespace Managers.Outputs.Building
{
    public class StorageBuildingDisplayScript : BaseBuildingDisplayScript
    {
        void Start()
        {
            BuildingType = BuildingType.Storage;
            Setup();
        }
    }
}
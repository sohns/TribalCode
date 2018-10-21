using Enum;

namespace Managers.Outputs.Building
{
    public class BaseBuildingDisplayInfo
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public BuildingEnum BuildingEnum { get; set; }
        public BuildingType BuildingType { get; set; }
    }
}
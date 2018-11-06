using Enum;

namespace Managers.Outputs.Building
{
    public class ConverterBuildingDisplayScripts : BaseBuildingDisplayScript, IBuildingDisplay
    {
        public void Setup(BuildingEnum buildingEnum)
        {
            BuildingEnum = buildingEnum;
            BuildingType = BuildingType.Converter;
            base.Setup();
        }
    }
}
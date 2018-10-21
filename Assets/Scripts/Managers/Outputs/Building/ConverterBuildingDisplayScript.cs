using Enum;

namespace Managers.Outputs.Building
{
    public class ConverterBuildingDisplayScripts : BaseBuildingDisplayScript
    {
        void Start()
        {
            BuildingType = BuildingType.Converter;
            Setup();
        }
    }
}
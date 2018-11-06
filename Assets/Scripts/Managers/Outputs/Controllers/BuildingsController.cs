using Enum;
using Managers.Outputs.Building;
using UnityEngine;

namespace Managers.Outputs.Controllers
{
    public class BuildingsController : MonoBehaviour
    {
        public StorageBuildingDisplayScript BasketYard;
        public StorageBuildingDisplayScript StorageYard;
        public StorageBuildingDisplayScript Granary;
        public StorageBuildingDisplayScript StoragePit;

        public ConverterBuildingDisplayScripts SmokeHut;
        public ConverterBuildingDisplayScripts ButcherHut;
        public ConverterBuildingDisplayScripts JuiceHut;
        public ConverterBuildingDisplayScripts LumberHut;
        public ConverterBuildingDisplayScripts MasonHut;
        public ConverterBuildingDisplayScripts KilnHut;

        public PopulationAssignmentBuildingDisplayScript Fishery;
        public PopulationAssignmentBuildingDisplayScript HuntingLodge;
        public PopulationAssignmentBuildingDisplayScript GatheringHut;
        public PopulationAssignmentBuildingDisplayScript LumberCamp;
        public PopulationAssignmentBuildingDisplayScript Quarry;
        public PopulationAssignmentBuildingDisplayScript ClayPit;

        void Start()
        {
            Setup(BasketYard, BuildingEnum.BasketYard);
            Setup(StorageYard, BuildingEnum.StorageYard);
            Setup(Granary, BuildingEnum.Granary);
            Setup(StoragePit, BuildingEnum.StoragePit);
            Setup(SmokeHut, BuildingEnum.SmokeHut);
            Setup(ButcherHut, BuildingEnum.ButcherHut);
            Setup(JuiceHut, BuildingEnum.JuiceHut);
            Setup(LumberHut, BuildingEnum.LumberHut);
            Setup(MasonHut, BuildingEnum.MasonHut);
            Setup(KilnHut, BuildingEnum.KilnHut);
            Setup(Fishery, BuildingEnum.Fishery);
            Setup(HuntingLodge, BuildingEnum.HuntingLodge);
            Setup(GatheringHut, BuildingEnum.GatheringHut);
            Setup(LumberCamp, BuildingEnum.LumberCamp);
            Setup(Quarry, BuildingEnum.Quarry);
            Setup(ClayPit, BuildingEnum.ClayPit);
        }

        private void Setup<T>(T baseScript, BuildingEnum buildingEnum) where T : IBuildingDisplay
        {
            if (baseScript != null)
            {
                baseScript.Setup(buildingEnum);
            }
        }
    }
}
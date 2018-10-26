using System;
using System.Linq;
using Enum;
using Managers.Buildings;
using TMPro;
using UnityEngine;

namespace Managers.Outputs.MouseOver
{
    public class MouseOverBaseDisplay : MonoBehaviour
    {
        public GameObject Name, Level, Rates, Costs, Other, BuildingType;

        private void Start()
        {
            OutputManager.ThisManager.MouseOverRegistration(gameObject);
        }

        public void SetInfo(BaseBuilding building)
        {
            SetValue(building.Name, Name);
            SetValue(building.Level.ToString(), Level);
            var ratesDisplay = string.Format("Base: {0} -- Current: {1}", building.BaseRate, building.CurrentRate);
            SetValue(ratesDisplay, Rates);
            SetValue(
                string.Join("\n",
                    building.CurrentCost.Select(costInfo =>
                            string.Format(costInfo.Key + ":" + costInfo.Value + " -- " + "Increase:" +
                                          building.CostIncrease[costInfo.Key] + " Base:" +
                                          building.BaseCost[costInfo.Key]))
                        .ToArray()), Costs);
            SetValue(building.BuildingType.ToString(), BuildingType);
            var other = "";
            switch (building.BuildingType)
            {
                case Enum.BuildingType.Converter:
                    var converterBuilding = (ConverterBuilding) building;
                    other = String.Format(
                        "Converts:" + converterBuilding.ResourceEnum + " to " + converterBuilding.MetaResourceEnum);
                    break;
                case Enum.BuildingType.Storage:
                    var storageBuilding = (StorageBuilding) building;
                    var storageType = storageBuilding.ResourceType == ResourceType.Resource
                        ? "Resources for "
                        : "MetaResources for ";
                    storageType += storageBuilding.MetaResourceEnum.ToString();
                    other = String.Format(
                        "Stores " + storageType + ":" + storageBuilding.CurrentStorage + " -- Base: " +
                        storageBuilding.BaseStorage);
                    break;
                case Enum.BuildingType.PopulationAssignment:
                    var populationAssignmentBuildings = (PopulationAssignmentBuildings) building;
                    other = string.Format(
                        "Population:{0}/{1} for {2}", populationAssignmentBuildings.CurrentPopulation,
                        populationAssignmentBuildings.PopulationCapCurrent, populationAssignmentBuildings.ResourceEnum);
                    break;
                case Enum.BuildingType.TownCenter:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            SetValue(other, Other);
        }

        private void SetValue(string value, GameObject toSet)
        {
            toSet.GetComponent<TextMeshProUGUI>().text = value;
        }
    }
}
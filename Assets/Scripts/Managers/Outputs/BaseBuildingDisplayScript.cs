using System;
using Managers.Buildings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.Outputs
{
    public class BaseBuildingDisplayScript : MonoBehaviour
    {
        public GameObject DisplayName, BuildingLevel;
        public Button PurchaseButton { get; set; }
        public BuildingEnum ThisBuildingType { get; set; }

        protected void Setup()
        {
            
        }

        protected void BuildBuilding()
        {
            
        }
        
        public void SetValues(BaseBuildingDisplayInfo baseBuildingDisplayInfo)
        {
            SetValue(baseBuildingDisplayInfo.Name, DisplayName);
            SetValue(baseBuildingDisplayInfo.Level, DisplayName);
        }

        private void SetValue(string value, GameObject toSet)
        {
            toSet.GetComponent<TextMeshProUGUI>().text = value;
        }
    }
}
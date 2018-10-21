using System;
using Enum;
using Managers.Buildings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.Outputs.Building
{
    public class BaseBuildingDisplayScript : MonoBehaviour
    {
        public GameObject DisplayName, BuildingLevel;
        public Button PurchaseButton;
        public BuildingEnum BuildingEnum;
        protected BuildingType BuildingType;

        protected void Setup()
        {
            PurchaseButton.onClick.AddListener(BuildBuilding);
            OutputManager.ThisManager.BuildingRegistration(BuildingEnum, gameObject);
        }

        protected void BuildBuilding()
        {
            BuildingManager.ThisManager.AddBuilding(BuildingEnum);
        }

        public void SetValues(BaseBuildingDisplayInfo info)
        {
            if (info.BuildingType != BuildingType)
            {
                throw new Exception("BUILDING:" + DisplayName + " is not of type " + BuildingType);
            }
            SetValue(info.Name, DisplayName);
            SetValue(info.Level, BuildingLevel);
        }

        private void SetValue(string value, GameObject toSet)
        {
            toSet.GetComponent<TextMeshProUGUI>().text = value;
        }
    }
}
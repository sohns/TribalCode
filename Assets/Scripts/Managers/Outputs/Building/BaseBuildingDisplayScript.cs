using System;
using Enum;
using Managers.Buildings;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Managers.Outputs.Building
{
    public class BaseBuildingDisplayScript : MonoBehaviour
    {
        public GameObject BuildingLevel;
        public Button PurchaseButton;
        protected BuildingEnum BuildingEnum;
        protected BuildingType BuildingType;

        public void Setup()
        {
            PurchaseButton.onClick.AddListener(BuildBuilding);
            OutputManager.ThisManager.BuildingRegistration(BuildingEnum, gameObject);
            var clickHandler = PurchaseButton.gameObject.AddComponent<ClickHandler>();
            clickHandler.Right = Right;
        }

        protected void BuildBuilding()
        {
            BuildingManager.ThisManager.AddBuilding(BuildingEnum);
        }

        public void SetValues(BaseBuildingDisplayInfo info)
        {
            if (info.BuildingType != BuildingType)
            {
                throw new Exception("BUILDING:" + info.Name + " is not of type " + BuildingType);
            }
            SetValue(info.Level, BuildingLevel);
        }

        private void SetValue(string value, GameObject toSet)
        {
            toSet.GetComponent<TextMeshProUGUI>().text = value;
        }

        private void Right()
        {
            OutputManager.ThisManager.SetMouseOver(BuildingEnum);
        }
    }
}
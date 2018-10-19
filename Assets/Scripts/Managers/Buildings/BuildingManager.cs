using System.Collections.Generic;
using Managers.Meta;
using UnityEngine;

namespace Managers.Buildings
{
    public class BuildingManager : MonoBehaviour, IManager
    {
        public static BuildingManager ThisManager;
        public Dictionary<BuildingEnum, BaseBuilding> Buildings;
        public SaveInfo Save(SaveInfo saveInfo)
        {
            return saveInfo;
        }

        public void Load(SaveInfo saveInfo)
        {
            Buildings = new Dictionary<BuildingEnum, BaseBuilding>();
            
        }

        public void InitialSetup()
        {
            ThisManager = this;
        }

        public void PostLoad()
        {
            
        }
    }
}
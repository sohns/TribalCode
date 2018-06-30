using System;
using TMPro;
using UnityEngine;

namespace Managers.Outputs
{
    public class BaseResourceDiplayPrefabScript : MonoBehaviour
    {
        public GameObject Name, Value, Change;

        public void SetValues(BaseResourceDisplayInfo baseResourceDisplayInfo)
        {
            SetValue(baseResourceDisplayInfo.Name, Name);
            SetValue(baseResourceDisplayInfo.Value, Value);
            SetValue(baseResourceDisplayInfo.Change, Change);
        }

        private void SetValue(string value, GameObject toSet)
        {
            toSet.GetComponent<TextMeshProUGUI>().text = value;
        }
    }
}
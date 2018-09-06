using System;
using TMPro;
using UnityEngine;

namespace Managers.Outputs
{
    public class BaseResourceDisplayPrefabScript : MonoBehaviour
    {
        public GameObject Value, Change;

        public void SetValues(BaseResourceDisplayInfo baseResourceDisplayInfo)
        {
            SetValue(baseResourceDisplayInfo.Value, Value);
            SetValue(baseResourceDisplayInfo.Change, Change);
        }

        private void SetValue(string value, GameObject toSet)
        {
            toSet.GetComponent<TextMeshProUGUI>().text = value;
        }
    }
}
using System;
using TMPro;
using UnityEngine;

namespace Managers.Outputs
{
    public class BaseMetaResourceDisplayScript : MonoBehaviour
    {
        public GameObject Value, Change;

        public void SetValues(BaseMetaResourceDisplayInfo baseMetaResourceDisplayInfo)
        {
            SetValue(baseMetaResourceDisplayInfo.Value, Value);
            SetValue(baseMetaResourceDisplayInfo.Change, Change);
        }

        private void SetValue(string value, GameObject toSet)
        {
            toSet.GetComponent<TextMeshProUGUI>().text = value;
        }
    }
}
using System;
using TMPro;
using UnityEngine;

namespace Managers.Outputs
{
    public class MetaResourceDisplayPrefabScript : MonoBehaviour
    {
        public GameObject Value, Change;

        public void SetValues(MetaResourceDisplayInfo metaResourceDisplayInfo)
        {
            SetValue(metaResourceDisplayInfo.Value, Value);
            SetValue(metaResourceDisplayInfo.Change, Change);
        }

        private void SetValue(string value, GameObject toSet)
        {
            toSet.GetComponent<TextMeshProUGUI>().text = value;
        }
    }
}
using TMPro;
using UnityEngine;

namespace Managers.Outputs.MetaResource
{
    public class BaseMetaResourceDisplayScript : MonoBehaviour
    {
        public GameObject Value, Change, MaxValue;

        public void SetValues(BaseMetaResourceDisplayInfo baseMetaResourceDisplayInfo)
        {
            SetValue(baseMetaResourceDisplayInfo.Value, Value);
            SetValue(baseMetaResourceDisplayInfo.Change, Change);
            //SetValue(baseMetaResourceDisplayInfo.MaxValue, MaxValue);
        }

        private void SetValue(string value, GameObject toSet)
        {
            toSet.GetComponent<TextMeshProUGUI>().text = value;
        }
    }
}
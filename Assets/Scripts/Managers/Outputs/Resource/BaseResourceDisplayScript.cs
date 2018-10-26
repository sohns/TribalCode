using TMPro;
using UnityEngine;

namespace Managers.Outputs.Resource
{
    public class BaseResourceDisplayScript : MonoBehaviour
    {
        public GameObject Value, Change, MaxValue;

        public void SetValues(BaseResourceDisplayInfo baseResourceDisplayInfo)
        {
            SetValue(baseResourceDisplayInfo.Value, Value);
            SetValue(baseResourceDisplayInfo.Change, Change);
            //SetValue(baseResourceDisplayInfo.MaxValue, MaxValue);
        }

        private void SetValue(string value, GameObject toSet)
        {
            toSet.GetComponent<TextMeshProUGUI>().text = value;
        }
    }
}
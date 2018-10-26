using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Managers.Outputs.Building
{
    public class ClickHandler : MonoBehaviour, IPointerClickHandler
    {
        public Action Left, Middle, Right;

        public void OnPointerClick(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    UseAction(Left);
                    break;
                case PointerEventData.InputButton.Middle:
                    UseAction(Middle);
                    break;
                case PointerEventData.InputButton.Right:
                    UseAction(Right);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void UseAction(Action action)
        {
            if (action != null)
            {
                action();
            }
        }
    }
}
using System;
using UnityEngine;

namespace GamePackage.Runtime.Input
{
    public class InputDragHandler : MonoBehaviour
    {
        public event Action<Vector3> DidDrag;
        public event Action DidDragEnd;

        [SerializeField] private InputDirection _InputDirection;
        private Vector3? _lastInputPos;

        private void Update()
        {
            var isInput = UnityEngine.Input.GetMouseButton(0);
            var mousePosition = GetMousePositionWithDirection(_InputDirection);

            if (isInput && _lastInputPos.HasValue)
            {
                var v = mousePosition - _lastInputPos.Value;
                var direction = v.normalized;
                DidDrag?.Invoke(direction);
            }
            else if (_lastInputPos.HasValue)
            {
                _lastInputPos = null;
                DidDragEnd?.Invoke();
            }

            if (isInput) _lastInputPos = mousePosition;
        }

        private Vector3 GetMousePositionWithDirection(InputDirection direction)
        {
            var mousePosition = UnityEngine.Input.mousePosition;
            switch (direction)
            {
                case InputDirection.Horizontal:
                    mousePosition.y = 0;
                    break;
                case InputDirection.Vertical:
                    mousePosition.x = 0;
                    break;
                case InputDirection.Both:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return mousePosition;
        }
    }
}

public enum InputDirection
{
    Horizontal,
    Vertical,
    Both
}
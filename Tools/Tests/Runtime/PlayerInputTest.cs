using GamePackage.Runtime.Input;
using UnityEngine;

namespace GamePackage.Tests.Runtime
{
    public class PlayerInputTest : MonoBehaviour
    {
        [SerializeField] private InputDragHandler _Input;
        [SerializeField] private float _Speed;
        
        private Transform _transform;
        
        private void Awake()
        {
            _transform = transform;
            _Input.DidDrag += InputOnDidDrag;
            _Input.DidDragEnd += InputOnDidDragEnd;
        }
        
        private void InputOnDidDrag(Vector3 direction)
        {
            var pos = _transform.position;
            var newX = pos.x + direction.x * _Speed;
            var newPos = new Vector3(newX, pos.y, pos.z);
            
            _transform.position = newPos;
        }
        
        private void InputOnDidDragEnd()
        {
            Debug.Log("Release");
        }
    }
}
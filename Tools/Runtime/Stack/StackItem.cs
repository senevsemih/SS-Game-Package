using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePackage.Runtime.Stack
{
    public class StackItem : MonoBehaviour
    {
        private const float UPWARD_MOVEMENT_FOLLOW_SPEED_MULTIPLIER = 4;
        
        [ShowInInspector, ReadOnly] private Transform _target;
        [ShowInInspector, ReadOnly] private float _speed;
        [ShowInInspector, ReadOnly] private StackDirection _stackDirection;
        [ShowInInspector, ReadOnly] private float _offset;
        
        private Transform _transform;
        private StackFormation _stackFormation;

        private void Awake() => _transform = transform;

        public void SetStackSettings(Transform target, float speed, StackDirection stackDirection, float offset, StackFormation stack)
        {
            _target = target;
            _speed = speed;
            _stackDirection = stackDirection;
            _offset = offset;
            _stackFormation = stack;
        }
        
        private void Update() => StackMovement();

        private void StackMovement()
        {
            var position = _transform.position;
            var rotation = _transform.eulerAngles;
            
            var targetTransform = _target.transform;
            var targetPosition = targetTransform.position;
            var targetRotation = targetTransform.eulerAngles;

            var positionTargetZ = _stackDirection switch
            {
                StackDirection.Forward => targetPosition.z + _offset,
                StackDirection.Upward => targetPosition.z,
                _ => throw new ArgumentOutOfRangeException()
            };

            position.x = Mathf.Lerp(position.x, targetPosition.x, _speed * Time.deltaTime);
            position.z = _stackDirection switch
            {
                StackDirection.Forward => positionTargetZ + _offset,
                StackDirection.Upward => Mathf.Lerp(position.z, positionTargetZ,
                    _speed * UPWARD_MOVEMENT_FOLLOW_SPEED_MULTIPLIER * Time.deltaTime),
                _ => throw new ArgumentOutOfRangeException()
            };

            rotation.y = Mathf.Lerp(rotation.y, targetRotation.y, _speed * Time.deltaTime);
            
            _transform.position = position;
            _transform.eulerAngles = rotation;
        }
        
        private void OnTriggerEnter(Collider other) => _stackFormation.CheckCollider(other);
    }
}
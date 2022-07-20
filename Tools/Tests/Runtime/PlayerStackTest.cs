using GamePackage.Runtime.Physics;
using GamePackage.Runtime.Stack;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePackage.Tests.Runtime
{
    public class PlayerStackTest : MonoBehaviour
    {
        [SerializeField, Required] private StackConfig _StackConfig = new()
        {
            StackCapacity = 100,
            StackDirection = StackDirection.Forward,
            StackOffset = 1,
            StackMaxSpeed = 20,
            StackSpeedDecreaseRate = 1
        };
        
        [SerializeField] private Transform _StackStartPosition;
        [SerializeField, Required] private PhysicsListener _PhysicsListener;
        
        private StackFormation _forwardStackFormation;

        private void Start()
        {
            _forwardStackFormation = new StackFormation(
                _StackConfig,
                _StackStartPosition,
                _PhysicsListener);
        }
    }
}
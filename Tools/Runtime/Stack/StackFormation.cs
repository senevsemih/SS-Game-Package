using System;
using System.Collections.Generic;
using GamePackage.Runtime.Physics;
using UnityEngine;

namespace GamePackage.Runtime.Stack
{
    public class StackFormation
    {
        private readonly StackDirection _stackDirection;
        private readonly float _stackOffset;
        private readonly int _stackCapacity;
        private readonly float _stackMaxSpeed;
        private readonly float _stackSpeedDecreaseRate;
        private readonly Transform _stackStartPosition;
        private readonly List<StackItem> _items = new();

        public StackFormation(
            StackConfig config,
            Transform stackStartPosition,
            PhysicsListener physicsListener)
        {
            _stackDirection = config.StackDirection;
            _stackOffset = config.StackOffset;
            _stackCapacity = config.StackCapacity;
            _stackMaxSpeed = config.StackMaxSpeed;
            _stackSpeedDecreaseRate = config.StackSpeedDecreaseRate;
            _stackStartPosition = stackStartPosition;
            physicsListener.TriggerEnter += CheckCollider;
        }

        private void Increase(StackCollectible newCollectible)
        {
            var stackCount = _items.Count;
            if (stackCount >= _stackCapacity) return;

            Debug.Log($"Increase, collectible: {newCollectible}");
            var target = GetTargetTransformForItemIndex(stackCount);
            var targetPos = target.position;
            var newItemPos = _stackDirection switch
            {
                StackDirection.Forward => targetPos + new Vector3(0f, 0f, _stackOffset),
                StackDirection.Upward => targetPos + new Vector3(0f, _stackOffset, 0f),
                _ => throw new ArgumentOutOfRangeException()
            };

            var newItem = newCollectible.gameObject.AddComponent<StackItem>();
            newItem.SetStackSettings(target, GetSpeedByItemIndex(stackCount), _stackDirection, _stackOffset, this);
            newItem.name = $"Collectible - {stackCount}";
            newItem.transform.position = newItemPos;
            _items.Add(newItem);

            newCollectible.SetIsCollectible(false);
        }

        private void Decrease()
        {
            Debug.Log("Decrease");
            
            var stackCount = _items.Count;
            if (stackCount <= 0) return;
            _items[stackCount - 1].gameObject.SetActive(false);
            _items.Remove(_items[stackCount - 1]);
        }

        private float GetSpeedByItemIndex(int index)
        {
            var speed = _stackMaxSpeed - (index - 1) * _stackSpeedDecreaseRate;
            if (speed <= 0)  speed = 1;
            
            return speed;
        }

        private Transform GetTargetTransformForItemIndex(int i) => i == 0 ? _stackStartPosition : _items[i - 1].transform;
        
        public void CheckCollider(Collider other)
        {
            var collectible = other.gameObject.GetComponent<StackCollectible>();
            if(collectible && collectible.IsCollectible) Increase(collectible);

            var obstacle = other.gameObject.GetComponent<StackObstacle>();
            if(obstacle) Decrease();
        }
    }
}
using System;
// ReSharper disable InconsistentNaming

namespace GamePackage.Runtime.Stack
{
    [Serializable]
    public class StackConfig
    {
        public StackDirection StackDirection = StackDirection.Forward;
        public float StackOffset = 1;
        public int StackCapacity = 100;
        public float StackMaxSpeed = 20;
        public float StackSpeedDecreaseRate = 1;
    }
}
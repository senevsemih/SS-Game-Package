using UnityEngine;

namespace GamePackage.Runtime.Stack
{
    public class StackCollectible : MonoBehaviour
    {
        public bool IsCollectible { get; private set; } = true;
        public void SetIsCollectible(bool b) => IsCollectible = b;
    }
}
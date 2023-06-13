using UnityEngine;

namespace CodeBase.StaticData.Player
{
    [CreateAssetMenu(menuName = "Static Data/Player Static Data", order = 0)]
    public class PlayerStaticData : ScriptableObject
    {
        [field: SerializeField] public float JumpForce { get; private set; } = 2f;
        [field: SerializeField] public float ConstantForceY { get; private set; } = 2f;
    }
}
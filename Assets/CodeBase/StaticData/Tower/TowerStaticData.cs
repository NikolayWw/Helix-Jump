using UnityEngine;

namespace CodeBase.StaticData.Tower
{
    [CreateAssetMenu(menuName = "Static Data/Tower Static Data", order = 0)]
    public class TowerStaticData : ScriptableObject
    {
        [field: SerializeField] public float RotateSpeed { get; private set; }
    }
}
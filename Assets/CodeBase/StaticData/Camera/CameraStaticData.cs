using UnityEngine;

namespace CodeBase.StaticData.Camera
{
    [CreateAssetMenu(menuName = "Static Data/Camera Static Data")]
    public class CameraStaticData : ScriptableObject
    {
        [field: SerializeField] public float LevelMapMoveSpeed { get; private set; } = 5f;
    }
}
using UnityEngine;

namespace CodeBase.Tower
{
    [ExecuteInEditMode]
    public class TowerInitialPoint : MonoBehaviour
    {
#if UNITY_EDITOR

        private void Update()
        {
            transform.position = Vector3.zero;
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying == false)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawCube(transform.position, new Vector3(1, 2, 1));
            }
        }
    }

#endif
}
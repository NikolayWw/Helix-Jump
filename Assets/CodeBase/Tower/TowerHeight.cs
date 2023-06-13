using UnityEngine;

namespace CodeBase.Tower
{
    public class TowerHeight : MonoBehaviour
    {
        [SerializeField] private Transform _towerTransform;

        public void SetHeight(float height)
        {
            const int cylinderDefaultHeight = 2;
            height /= cylinderDefaultHeight;
            height += 0.1f; //offset
            _towerTransform.localScale = new Vector3(_towerTransform.localScale.x, height, _towerTransform.localScale.z);
            _towerTransform.position = new Vector3(_towerTransform.position.x, -(height - 1), _towerTransform.position.z);
        }
    }
}
using CodeBase.Data;
using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class PlayerTriggerReporter : MonoBehaviour
    {
        public Action OnEnter;
        public Collider Collider { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(GameConstants.PlayerTag))
            {
                Collider = other;
                OnEnter?.Invoke();
            }
        }
    }
}
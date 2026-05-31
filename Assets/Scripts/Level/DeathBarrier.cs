using SuperMario.Core;
using UnityEngine;

namespace SuperMario.Level
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class DeathBarrier : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.gameObject.SetActive(false);
                GameEvents.LevelResetRequested(3f);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}

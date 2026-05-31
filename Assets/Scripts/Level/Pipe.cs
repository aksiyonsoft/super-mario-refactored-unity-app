using System.Collections;
using SuperMario.Core;
using MarioPlayer = SuperMario.Player.Player;
using UnityEngine;

namespace SuperMario.Level
{
    public class Pipe : MonoBehaviour
    {
        public Transform connection;
        public Vector3 enterDirection = Vector3.down;
        public Vector3 exitDirection = Vector3.zero;

        private SideScrollingCamera sideScrollingCamera;
        private InputReader inputReader;

        private void Awake()
        {
            sideScrollingCamera = Camera.main.GetComponent<SideScrollingCamera>();
            inputReader = InputReader.Instance ?? FindAnyObjectByType<InputReader>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (connection != null && other.CompareTag("Player"))
            {
                if (inputReader != null && inputReader.EnterPipeHeld && other.TryGetComponent(out MarioPlayer player)) {
                    StartCoroutine(Enter(player));
                }
            }
        }

        private IEnumerator Enter(MarioPlayer player)
        {
            player.movement.enabled = false;

            Vector3 enteredPosition = transform.position + enterDirection;
            Vector3 enteredScale = Vector3.one * 0.5f;

            yield return Move(player.transform, enteredPosition, enteredScale);
            yield return new WaitForSeconds(1f);

            sideScrollingCamera.SetUnderground(connection.position.y < sideScrollingCamera.undergroundThreshold);

            if (exitDirection != Vector3.zero)
            {
                player.transform.position = connection.position - exitDirection;
                yield return Move(player.transform, connection.position + exitDirection, Vector3.one);
            }
            else
            {
                player.transform.position = connection.position;
                player.transform.localScale = Vector3.one;
            }

            player.movement.enabled = true;
        }

        private IEnumerator Move(Transform player, Vector3 endPosition, Vector3 endScale)
        {
            float elapsed = 0f;
            float duration = 1f;

            Vector3 startPosition = player.position;
            Vector3 startScale = player.localScale;

            while (elapsed < duration)
            {
                float t = elapsed / duration;

                player.position = Vector3.Lerp(startPosition, endPosition, t);
                player.localScale = Vector3.Lerp(startScale, endScale, t);
                elapsed += Time.deltaTime;

                yield return null;
            }

            player.position = endPosition;
            player.localScale = endScale;
        }
    }
}

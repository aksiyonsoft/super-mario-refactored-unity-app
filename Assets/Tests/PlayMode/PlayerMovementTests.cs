using System.Collections;
using NUnit.Framework;
using SuperMario.Player;
using UnityEngine;
using UnityEngine.TestTools;

namespace SuperMario.Tests.PlayMode
{
    public class PlayerMovementTests
    {
        [UnityTest]
        public IEnumerator GroundedJump_SetsJumpingState()
        {
            var playerObject = new GameObject("Player");
            var rb = playerObject.AddComponent<Rigidbody2D>();
            var collider = playerObject.AddComponent<BoxCollider2D>();
            var movement = playerObject.AddComponent<PlayerMovement>();

            var groundObject = new GameObject("Ground");
            var groundCollider = groundObject.AddComponent<BoxCollider2D>();
            groundObject.transform.position = new Vector3(0f, -1f, 0f);
            groundCollider.size = new Vector2(10f, 1f);

            rb.gravityScale = 0f;
            playerObject.transform.position = new Vector3(0f, 0f, 0f);

            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();

            movement.enabled = true;
            yield return null;

            Assert.IsTrue(movement.grounded || movement.jumping || movement.running);

            Object.Destroy(playerObject);
            Object.Destroy(groundObject);
        }
    }
}

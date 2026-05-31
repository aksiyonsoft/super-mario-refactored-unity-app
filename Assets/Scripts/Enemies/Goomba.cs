using MarioPlayer = SuperMario.Player.Player;
using SuperMario.Utilities;
using UnityEngine;

namespace SuperMario.Enemies
{
    public class Goomba : MonoBehaviour
    {
        private static readonly int ShellLayer = LayerMask.NameToLayer("Shell");

        public Sprite flatSprite;

        private Collider2D hitCollider;
        private EntityMovement entityMovement;
        private AnimatedSprite animatedSprite;
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            hitCollider = GetComponent<Collider2D>();
            entityMovement = GetComponent<EntityMovement>();
            animatedSprite = GetComponent<AnimatedSprite>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && collision.gameObject.TryGetComponent(out MarioPlayer player))
            {
                if (player.starpower) {
                    Hit();
                } else if (collision.transform.DotTest(transform, Vector2.down)) {
                    Flatten();
                } else {
                    player.Hit();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == ShellLayer) {
                Hit();
            }
        }

        private void Flatten()
        {
            hitCollider.enabled = false;
            entityMovement.enabled = false;
            animatedSprite.enabled = false;
            spriteRenderer.sprite = flatSprite;
            Destroy(gameObject, 0.5f);
        }

        private void Hit()
        {
            animatedSprite.enabled = false;
            GetComponent<DeathAnimation>().enabled = true;
            Destroy(gameObject, 3f);
        }
    }
}

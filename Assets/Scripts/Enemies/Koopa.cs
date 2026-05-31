using SuperMario.Player;
using SuperMario.Utilities;
using UnityEngine;

namespace SuperMario.Enemies
{
    public class Koopa : MonoBehaviour
    {
        private static readonly int ShellLayer = LayerMask.NameToLayer("Shell");

        public Sprite shellSprite;
        public float shellSpeed = 12f;

        private bool shelled;
        private bool pushed;

        private SpriteRenderer spriteRenderer;
        private AnimatedSprite animatedSprite;
        private EntityMovement entityMovement;
        private Rigidbody2D rigidbody;
        private DeathAnimation deathAnimation;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animatedSprite = GetComponent<AnimatedSprite>();
            entityMovement = GetComponent<EntityMovement>();
            rigidbody = GetComponent<Rigidbody2D>();
            deathAnimation = GetComponent<DeathAnimation>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!shelled && collision.gameObject.CompareTag("Player") && collision.gameObject.TryGetComponent(out Player player))
            {
                if (player.starpower) {
                    Hit();
                } else if (collision.transform.DotTest(transform, Vector2.down)) {
                    EnterShell();
                }  else {
                    player.Hit();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (shelled && other.CompareTag("Player") && other.TryGetComponent(out Player player))
            {
                if (!pushed)
                {
                    Vector2 direction = new(transform.position.x - other.transform.position.x, 0f);
                    PushShell(direction);
                }
                else
                {
                    if (player.starpower) {
                        Hit();
                    } else {
                        player.Hit();
                    }
                }
            }
            else if (!shelled && other.gameObject.layer == ShellLayer)
            {
                Hit();
            }
        }

        private void EnterShell()
        {
            shelled = true;

            spriteRenderer.sprite = shellSprite;
            animatedSprite.enabled = false;
            entityMovement.enabled = false;
        }

        private void PushShell(Vector2 direction)
        {
            pushed = true;

            rigidbody.bodyType = RigidbodyType2D.Dynamic;

            entityMovement.direction = direction.normalized;
            entityMovement.speed = shellSpeed;
            entityMovement.enabled = true;

            gameObject.layer = ShellLayer;
        }

        private void Hit()
        {
            animatedSprite.enabled = false;
            deathAnimation.enabled = true;
            Destroy(gameObject, 3f);
        }

        private void OnBecameInvisible()
        {
            if (pushed) {
                Destroy(gameObject);
            }
        }
    }
}

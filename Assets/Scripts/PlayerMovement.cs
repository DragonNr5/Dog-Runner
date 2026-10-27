using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public Sprite[] sprites;
    private Vector3 direction;
    public float jumpStrength = 5f;
    public float gravity = -9.81f;
    private SpriteRenderer spriteRenderer;
    private int spriteIndex;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), .06f, .06f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.linearVelocity = Vector2.zero;
            body.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        }

    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0)
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
        else if (other.gameObject.CompareTag("Scoring"))
        {
            GameManager.Instance.IncreaseScore();
        }
    }




}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spritesDown; // Array de 3 sprites para moverse hacia abajo
    public Sprite[] spritesLeft; // Array de 3 sprites para moverse hacia la izquierda
    public Sprite[] spritesRight; // Array de 3 sprites para moverse hacia la derecha
    public Sprite[] spritesUp;    // Array de 3 sprites para moverse hacia arriba

    private Rigidbody2D rb;
    private Vector2 movement;
    private float animationTimer = 0f;
    private float frameRate = 0.15f; // Tiempo en segundos para cambiar de sprite
    private int currentFrame = 0;
    private Vector2 lastMovementDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            lastMovementDirection = movement;
        }

        // Animación
        AnimateCharacter();
    }

    void FixedUpdate()
    {
        // Movimiento
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void AnimateCharacter()
    {
        if (movement != Vector2.zero)
        {
            animationTimer += Time.deltaTime;
            if (animationTimer >= frameRate)
            {
                currentFrame = (currentFrame + 1) % 3; // Cambiar entre 0, 1 y 2
                animationTimer = 0f;

                UpdateSprite();
            }
        }
        else
        {
            // Detener la animación y mantener la última pose cuando el personaje está inactivo
            if (currentFrame != 0)
            {
                currentFrame = 0;
                UpdateSprite();
            }
        }
    }

    private void UpdateSprite()
    {
        if (lastMovementDirection.x > 0) // derecha
            spriteRenderer.sprite = spritesRight[currentFrame];
        else if (lastMovementDirection.x < 0) // izquierda
            spriteRenderer.sprite = spritesLeft[currentFrame];
        else if (lastMovementDirection.y > 0) // arriba
            spriteRenderer.sprite = spritesUp[currentFrame];
        else if (lastMovementDirection.y < 0) // abajo
            spriteRenderer.sprite = spritesDown[currentFrame];
    }
}

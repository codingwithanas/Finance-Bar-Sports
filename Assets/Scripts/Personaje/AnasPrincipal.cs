using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public SpriteRenderer spriteRenderer;
    public Sprite spriteDown; // Anas_1.1
    public Sprite spriteLeft; // Anas_2.1
    public Sprite spriteRight; // Anas_3.1
    public Sprite spriteUp;    // Anas_4.2

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Cambiar sprite según la dirección
        if (movement.x > 0) // derecha
            spriteRenderer.sprite = spriteRight;
        else if (movement.x < 0) // izquierda
            spriteRenderer.sprite = spriteLeft;
        else if (movement.y > 0) // arriba
            spriteRenderer.sprite = spriteUp;
        else if (movement.y < 0) // abajo
            spriteRenderer.sprite = spriteDown;
    }

    void FixedUpdate()
    {
        // Movimiento
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

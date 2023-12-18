using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    public GameObject personajePrincipal; // Para asignar desde el Inspector
    public Sprite spriteDown; // Asignar desde el Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == personajePrincipal)
        {
            FindObjectOfType<MessageController>().OcultarMensajesYPanel();
            // Congelar al personaje (detener su movimiento)
            Rigidbody2D rb = personajePrincipal.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.constraints = RigidbodyConstraints2D.FreezeAll; // Congela la posición y la rotación
            }

            // Cambiar el sprite del personaje principal
            SpriteRenderer spriteRenderer = personajePrincipal.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && spriteDown != null)
            {
                spriteRenderer.sprite = spriteDown;
            }

            // Destruir el objeto PuntoMision
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class MissionInteraction : MonoBehaviour
{
    public GameObject panelConv;
    public GameObject initialElements; // Contenedor para ImageJeque y TextoJeque
    public GameObject buttonNSc; // Botón que quieres que aparezca

    private void Start()
    {
        // Desactivar todos los elementos al inicio
        panelConv.SetActive(false);
        initialElements.SetActive(false);
        buttonNSc.SetActive(false); // Asegúrate de que el botón también está desactivado
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PersonajePrincipal"))
        {
            // Mostrar los elementos iniciales y el botón
            panelConv.SetActive(true);
            initialElements.SetActive(true);
            buttonNSc.SetActive(true); // Activar el botón
        }
    }

    // Opcional: Puedes agregar un método público para ocultar todos los elementos si es necesario
    public void HideAllElements()
    {
        panelConv.SetActive(false);
        initialElements.SetActive(false);
        buttonNSc.SetActive(false);
    }
}


using UnityEngine;

public class MissionInteraction : MonoBehaviour
{
    public GameObject panelConv;
    public GameObject initialElements; // Contenedor para ImageJeque y TextoJeque
    public GameObject buttonNSc; // Bot�n que quieres que aparezca

    private void Start()
    {
        // Desactivar todos los elementos al inicio
        panelConv.SetActive(false);
        initialElements.SetActive(false);
        buttonNSc.SetActive(false); // Aseg�rate de que el bot�n tambi�n est� desactivado
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PersonajePrincipal"))
        {
            // Mostrar los elementos iniciales y el bot�n
            panelConv.SetActive(true);
            initialElements.SetActive(true);
            buttonNSc.SetActive(true); // Activar el bot�n
        }
    }

    // Opcional: Puedes agregar un m�todo p�blico para ocultar todos los elementos si es necesario
    public void HideAllElements()
    {
        panelConv.SetActive(false);
        initialElements.SetActive(false);
        buttonNSc.SetActive(false);
    }
}


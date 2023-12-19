using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Instrucciones : MonoBehaviour
{
    private Button Volver;

    void Start()
    {
        // Buscar el Canvas "Fondo" que contiene el Panel con los botones
        GameObject fondoCanvas = GameObject.Find("Canvas");

        // Verificar si se encontró el Canvas
        if (fondoCanvas != null)
        {
            // Buscar el botón "Volver" dentro del Canvas
            Volver = fondoCanvas.transform.Find("Volver").GetComponent<Button>();

            // Verificar si se encontró el botón "Volver"
            if (Volver != null)
            {
                // Asignar el método que se ejecutará al hacer clic en el botón "Volver"
                Volver.onClick.AddListener(OnVolverButtonClicked);
            }
            else
            {
                Debug.LogError("No se encontró el botón 'Volver'. Asegúrate de que está correctamente nombrado en la escena.");
            }
        }
        else
        {
            Debug.LogError("No se encontró el Canvas 'Fondo'. Asegúrate de que está correctamente nombrado en la escena.");
        }
    }

    // Método que se ejecutará al hacer clic en el botón "Volver"
    public void OnVolverButtonClicked()
    {
        SceneManager.LoadScene("MenúPrincipal");
    }

    void Update()
    {
        // Puedes agregar lógica adicional aquí si es necesario
    }
}

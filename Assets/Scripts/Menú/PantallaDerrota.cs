using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PantallaDerrota : MonoBehaviour
{
    private Button Volver;

    void Start()
    {
        // Buscar el Canvas "Fondo" que contiene el Panel con los botones
        GameObject fondoCanvas = GameObject.Find("Canvas");

        // Verificar si se encontr� el Canvas
        if (fondoCanvas != null)
        {
            // Buscar el bot�n "Volver" dentro del Canvas
            Volver = fondoCanvas.transform.Find("Volver").GetComponent<Button>();

            // Verificar si se encontr� el bot�n "Volver"
            if (Volver != null)
            {
                // Asignar el m�todo que se ejecutar� al hacer clic en el bot�n "Volver"
                Volver.onClick.AddListener(OnVolverButtonClicked);
            }
            else
            {
                Debug.LogError("No se encontr� el bot�n 'Volver'. Aseg�rate de que est� correctamente nombrado en la escena.");
            }
        }
        else
        {
            Debug.LogError("No se encontr� el Canvas 'Fondo'. Aseg�rate de que est� correctamente nombrado en la escena.");
        }
    }

    // M�todo que se ejecutar� al hacer clic en el bot�n "Volver"
    public void OnVolverButtonClicked()
    {
        SceneManager.LoadScene("Men�Principal");
    }

    void Update()
    {
        // Puedes agregar l�gica adicional aqu� si es necesario
    }
}
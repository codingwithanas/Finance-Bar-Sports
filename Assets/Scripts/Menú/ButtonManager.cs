using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button volverButton; // Referencia al botón, asignar desde el Inspector

    // Start se llama antes del primer frame
    void Start()
    {
        // Cambiar el texto del botón
        volverButton.GetComponentInChildren<Text>().text = "Volver";

        // Añadir listener al botón para detectar el evento OnClick
        volverButton.onClick.AddListener(() => LoadMainMenu());
    }

    // Método para cargar la escena del menú principal
    void LoadMainMenu()
    {
        SceneManager.LoadScene("MenúPrincipal");
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button volverButton; // Referencia al bot�n, asignar desde el Inspector

    // Start se llama antes del primer frame
    void Start()
    {
        // Cambiar el texto del bot�n
        volverButton.GetComponentInChildren<Text>().text = "Volver";

        // A�adir listener al bot�n para detectar el evento OnClick
        volverButton.onClick.AddListener(() => LoadMainMenu());
    }

    // M�todo para cargar la escena del men� principal
    void LoadMainMenu()
    {
        SceneManager.LoadScene("Men�Principal");
    }
}

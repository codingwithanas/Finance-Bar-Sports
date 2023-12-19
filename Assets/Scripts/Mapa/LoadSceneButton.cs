using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Asegúrate de incluir este espacio de nombres para trabajar con UI

public class LoadSceneButton : MonoBehaviour
{
    private void Start()
    {
        // Obtener el componente Button y añadir un listener para el evento OnClick
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(() => LoadScene("PrimeraPag"));
        }
        else
        {
            Debug.LogError("No se encontró el componente Button en este GameObject.");
        }
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

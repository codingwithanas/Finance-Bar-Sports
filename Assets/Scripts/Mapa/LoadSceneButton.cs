using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Aseg�rate de incluir este espacio de nombres para trabajar con UI

public class LoadSceneButton : MonoBehaviour
{
    private void Start()
    {
        // Obtener el componente Button y a�adir un listener para el evento OnClick
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(() => LoadScene("PrimeraPag"));
        }
        else
        {
            Debug.LogError("No se encontr� el componente Button en este GameObject.");
        }
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

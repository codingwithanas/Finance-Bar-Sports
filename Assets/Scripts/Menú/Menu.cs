using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private Button Jugar;
    private Button Instrucciones;
    private Button Salir;

    void Start()
    {
        // Buscar el Canvas "Fondo" que contiene el Panel con los botones
        GameObject fondoCanvas = GameObject.Find("Fondo");

        // Verificar si se encontró el Canvas
        if (fondoCanvas != null)
        {
            GameObject panel = fondoCanvas.transform.Find("Panel").gameObject;

            Jugar = panel.transform.Find("Jugar").GetComponent<Button>();
            Instrucciones = panel.transform.Find("Instrucciones").GetComponent<Button>();
            Salir = panel.transform.Find("Salir").GetComponent<Button>();

            Jugar.onClick.AddListener(OnStartButtonClicked);
            Instrucciones.onClick.AddListener(OnInstructionsButtonClicked);
            Salir.onClick.AddListener(OnExitButtonClicked);
        }
        else
        {
            Debug.LogError("No se encontró el Canvas 'Fondo'. Asegúrate de que está correctamente nombrado en la escena.");
        }
    }

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("2_BarInicial");
    }

    public void OnInstructionsButtonClicked()
    {
        SceneManager.LoadScene("Instrucciones");
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }

    void Update()
    {

    }
}

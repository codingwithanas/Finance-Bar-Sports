using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject FondoCanvas; // Variable para el Canvas "Fondo"

    private Button Jugar;
    private Button Instrucciones;
    private Button Salir;

    void Start()
    {
        // Accede al Canvas "Fondo" para encontrar el Panel y sus botones
        GameObject panel = FondoCanvas.transform.Find("Panel").gameObject;
        
        Jugar = panel.transform.Find("Jugar").GetComponent<Button>();
        Instrucciones = panel.transform.Find("Instrucciones").GetComponent<Button>();
        Salir = panel.transform.Find("Salir").GetComponent<Button>();

        Jugar.onClick.AddListener(OnStartButtonClicked);
        Instrucciones.onClick.AddListener(OnInstructionsButtonClicked);
        Salir.onClick.AddListener(OnExitButtonClicked);
    }

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Mapa");
    }

    public void OnInstructionsButtonClicked()
    {
        // Lógica para mostrar instrucciones
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }

    void Update()
    {

    }
}

using UnityEngine;
using System.Collections;

public class MessageController : MonoBehaviour
{
    public GameObject primerMensaje;
    public GameObject segundoMensaje;
    public GameObject panel; // Referencia al panel que contiene los mensajes

    void Start()
    {
        // Mostrar el primer mensaje y ocultar el segundo
        primerMensaje.SetActive(true);
        segundoMensaje.SetActive(false);
        StartCoroutine(MostrarMensajesSecuencia());
    }

    private IEnumerator MostrarMensajesSecuencia()
    {
        // Esperar 2 segundos
        yield return new WaitForSeconds(2);

        // Ocultar el primer mensaje y mostrar el segundo
        primerMensaje.SetActive(false);
        segundoMensaje.SetActive(true);
    }

    public void OcultarMensajesYPanel()
    {
        // Ocultar los mensajes y el panel completo
        segundoMensaje.SetActive(false);
        panel.SetActive(false);
    }
}


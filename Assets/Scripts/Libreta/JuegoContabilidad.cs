using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class JuegoContabilidad : MonoBehaviour
{
    public TextMeshProUGUI preguntaTexto;
    public Button[] respuestaBotones;
    public Color correctoColor; // Color para la respuesta correcta
    public string gameOverSceneName = "GameOver"; // Nombre de la escena de Game Over

    private System.Random random = new System.Random();
    private double respuestaCorrecta;
    private List<string> productosDisponibles = new List<string> { "Coca Cola", "cerveza", "agua mineral", "zumo de naranja", "caf�" }; // Lista inicial de productos

    void Start()
    {
        GenerarPregunta();
    }

    void GenerarPregunta()
    {
        if (productosDisponibles.Count == 0)
        {
            Debug.LogError("No hay m�s productos disponibles para generar preguntas.");
            // Aqu� puedes llamar a una funci�n para manejar el fin del juego o reiniciar la lista de productos
            return;
        }

        int cantidad = random.Next(200, 501); // Cantidad entre 200-500 euros
        respuestaCorrecta = Math.Round(cantidad * 0.20, 2);

        // Selecciona un producto aleatoriamente y lo elimina de la lista para evitar repeticiones
        int productoIndex = random.Next(productosDisponibles.Count);
        string productoSeleccionado = productosDisponibles[productoIndex];
        productosDisponibles.RemoveAt(productoIndex);

        List<double> respuestas = new List<double> { respuestaCorrecta };

        // A�ade respuestas incorrectas
        while (respuestas.Count < 3)
        {
            double offset = random.Next(-50, 51); // Offset ajustado para el rango m�s peque�o
            double respuestaIncorrecta = Math.Round(respuestaCorrecta + offset, 2);
            if (offset != 0 && respuestaIncorrecta > 0 && !respuestas.Contains(respuestaIncorrecta))
            {
                respuestas.Add(respuestaIncorrecta);
            }
        }

        // Mezcla las respuestas
        respuestas.Sort((a, b) => random.Next(-1, 2));

        preguntaTexto.text = $"Veo que tienes que calcular el 20% de {cantidad} euros en {productoSeleccionado}. �Cu�nto es?";

        // Configura los botones con las respuestas
        for (int i = 0; i < respuestaBotones.Length; i++)
        {
            TextMeshProUGUI buttonText = respuestaBotones[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = $"{respuestas[i]} �";
            respuestaBotones[i].gameObject.SetActive(true); // Aseg�rate de que el bot�n est� activo
            respuestaBotones[i].onClick.RemoveAllListeners();
            int index = i; // Variable local para usar en la expresi�n lambda
            respuestaBotones[i].onClick.AddListener(() => ComprobarRespuesta(respuestas[index], respuestaBotones));
        }
    }

    void ComprobarRespuesta(double seleccionada, Button[] botones)
    {
        // Desactiva todos los botones para evitar m�ltiples clicks
        foreach (var boton in botones)
        {
            boton.interactable = false;
        }

        if (Math.Abs(seleccionada - respuestaCorrecta) < Double.Epsilon)
        {
            Debug.Log("Respuesta correcta!");
            // Cambia el color del bot�n correcto y desactiva los incorrectos
            foreach (var boton in botones)
            {
                TextMeshProUGUI buttonText = boton.GetComponentInChildren<TextMeshProUGUI>();
                if (Double.TryParse(buttonText.text.Replace(" �", ""), out double buttonTextValue))
                {
                    if (Math.Abs(buttonTextValue - respuestaCorrecta) < Double.Epsilon)
                    {
                        boton.GetComponent<Image>().color = correctoColor;
                    }
                    else
                    {
                        boton.gameObject.SetActive(false); // Desactiva los botones incorrectos
                    }
                }
            }
            // Aqu� puedes a�adir cualquier otra l�gica que desees ejecutar despu�s de una respuesta correcta
        }
        else
        {
            Debug.Log("Respuesta incorrecta.");
            // Cambia a la escena de Game Over
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}

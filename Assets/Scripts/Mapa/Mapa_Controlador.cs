using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
// Obtén el componente RectTransform del objeto del mapa
        RectTransform mapRectTransform = GetComponent<RectTransform>();

        // Obtén el tamaño de la pantalla
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Ajusta el ancho y el alto del RectTransform al tamaño de la pantalla
        mapRectTransform.sizeDelta = new Vector2(screenWidth, screenHeight);

        // Ajusta la posición para que el objeto esté centrado en la pantalla
        mapRectTransform.anchoredPosition = Vector2.zero;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

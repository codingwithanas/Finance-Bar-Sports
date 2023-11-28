using UnityEngine;
using UnityEngine.UI;

public class LibretaManager : MonoBehaviour
{
    // Referencias a campos de texto para cada producto
    public InputField nombreProducto1;
    public InputField precioProducto1;

    public InputField nombreProducto2;
    public InputField precioProducto2;

    public InputField nombreProducto3;
    public InputField precioProducto3;

    public InputField nombreProducto4;
    public InputField precioProducto4;

    public InputField nombreProducto5;
    public InputField precioProducto5;

    public InputField nombreProducto6;
    public InputField precioProducto6;

    // Repite para los productos 3, 4, 5, y 6

    // Método para guardar los datos
    public void GuardarDatos()
    {
        // Guarda los datos ingresados por el jugador para cada producto
        string nombre1 = nombreProducto1.text;
        float precio1 = float.Parse(precioProducto1.text);

        string nombre2 = nombreProducto2.text;
        float precio2 = float.Parse(precioProducto2.text);

        string nombre3 = nombreProducto3.text;
        float precio3 = float.Parse(precioProducto3.text);

        string nombre4 = nombreProducto4.text;
        float precio4 = float.Parse(precioProducto4.text);

        string nombre5 = nombreProducto5.text;
        float precio5 = float.Parse(precioProducto5.text);

        string nombre6 = nombreProducto6.text;
        float precio6 = float.Parse(precioProducto6.text);

        // Repite para los productos 3, 4, 5, y 6

        // Puedes imprimir los datos en la consola para verificar
        Debug.Log("Producto 1: " + nombre1 + ", Precio: " + precio1);
        Debug.Log("Producto 2: " + nombre2 + ", Precio: " + precio2);
        // Repite para los productos 3, 4, 5, y 6

        // Puedes realizar operaciones adicionales según tus necesidades
    }
}

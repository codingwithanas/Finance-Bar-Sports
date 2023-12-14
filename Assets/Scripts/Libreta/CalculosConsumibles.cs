using UnityEngine;
using UnityEngine.UI;

public class CalculosConsumibles : MonoBehaviour
{
    public Text[] textNombres;
    public Text[] textPrecios;
    public InputField[] inputPorcentaje;
    public InputField inputSumaTotal;
    public Text textResultadoTotal;

    public Button btnCalcular;
    public Button btnSiguiente;

    // ...

    private void ValidarYCalcular()
    {
        // Lógica de validación antes de calcular

        // Iterar sobre los productos
        for (int i = 0; i < textPrecios.Length; i++)
        {
            // Obtener el precio del producto
            float precioProducto = float.Parse(textPrecios[i].text);

            // Calcular el 70% del precio y asignar al InputField_Porcentaje correspondiente
            float porcentaje = precioProducto * 0.7f;
            inputPorcentaje[i].text = porcentaje.ToString();
        }

        // Lógica para calcular la suma total y asignar al InputField_SumaTotal
        // ...

        // Después de validar, puedes permitir el siguiente paso
        btnSiguiente.interactable = true;
    }

    // ...
}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SegundaPag : MonoBehaviour
{
    public Text[] nombreProducto;
    public Text[] precioProducto;
    public InputField[] setentaPorCientoProducto;
    public InputField sumaTotal;
    public Text resultadoTotal;

    private void Start()
    {
        CargarDatos();
    }

    private void CargarDatos()
    {
        for (int i = 0; i < nombreProducto.Length; i++)
        {
            nombreProducto[i].text = PlayerPrefs.GetString("NombreProducto" + i);
            precioProducto[i].text = PlayerPrefs.GetFloat("PrecioProducto" + i).ToString();
        }
    }

    public void ValidarCalculos()
    {
        bool todosCorrectos = true;
        float suma = 0f;
        for (int i = 0; i < setentaPorCientoProducto.Length; i++)
        {
            float precio = PlayerPrefs.GetFloat("PrecioProducto" + i) * 0.7f;
            float inputPrecio;
            if (float.TryParse(setentaPorCientoProducto[i].text, out inputPrecio) && Mathf.Approximately(inputPrecio, precio))
            {
                suma += inputPrecio;
            }
            else
            {
                todosCorrectos = false;
                setentaPorCientoProducto[i].text = "";
            }
        }

        if (todosCorrectos && float.TryParse(sumaTotal.text, out float totalInput) && Mathf.Approximately(totalInput, suma))
        {
            resultadoTotal.text = sumaTotal.text;
            PlayerPrefs.SetFloat("SumaTotal", totalInput);
        }
        else
        {
            sumaTotal.text = "";
            resultadoTotal.text = "";
        }
    }

    public void CargarTerceraPag()
    {
        if (!string.IsNullOrEmpty(resultadoTotal.text))
        {
            SceneManager.LoadScene("TerceraPag");
        }
    }
}
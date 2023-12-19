using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PrimeraPag : MonoBehaviour
{
    public InputField[] nombreProducto;
    public InputField[] precioProducto;
    public Toggle maquinaArcade;
    public Toggle maquinaExpendedora;
    public Toggle maquinaRegalos;
    public Dropdown numeroEmpleados;

    private void Start()
    {
        CargarDatos();

        // Establecer las opciones del Dropdown
        numeroEmpleados.ClearOptions();
        List<string> opciones = new List<string>() { "0", "1", "2", "3", "4", "5" };
        numeroEmpleados.AddOptions(opciones);

        // Configurar la navegación de los InputFields
        ConfigurarNavegacionInputFields();
    }
    void ConfigurarNavegacionInputFields()
    {
        for (int i = 0; i < nombreProducto.Length - 1; i++)
        {
            // Establece la navegación hacia adelante
            Navigation nav = nombreProducto[i].navigation;
            nav.mode = Navigation.Mode.Explicit;
            nav.selectOnDown = precioProducto[i];
            nombreProducto[i].navigation = nav;

            // Establece la navegación hacia atrás
            Navigation navPrecio = precioProducto[i].navigation;
            navPrecio.mode = Navigation.Mode.Explicit;
            navPrecio.selectOnUp = nombreProducto[i];
            precioProducto[i].navigation = navPrecio;
        }
    }

    private void CargarDatos()
    {
        for (int i = 0; i < nombreProducto.Length; i++)
        {
            string nombre = PlayerPrefs.GetString("NombreProducto" + i, "");
            float precio = PlayerPrefs.GetFloat("PrecioProducto" + i, 0f);

            nombreProducto[i].text = nombre;
            precioProducto[i].text = precio.ToString();
        }

        maquinaArcade.isOn = PlayerPrefs.GetInt("MaquinaArcade", 0) == 1;
        maquinaExpendedora.isOn = PlayerPrefs.GetInt("MaquinaExpendedora", 0) == 1;
        maquinaRegalos.isOn = PlayerPrefs.GetInt("MaquinaRegalos", 0) == 1;
        numeroEmpleados.value = PlayerPrefs.GetInt("NumeroEmpleados", 0);
    }

    private bool EsEntradaValida(string entrada, string nombreCampo)
    {
        if (string.IsNullOrEmpty(entrada.Trim()))
        {
            Debug.LogError("El campo " + nombreCampo + " no puede estar vacío");
            return false;
        }
        return true;
    }

    private bool EsPrecioValido(string entrada, out float precio)
    {
        if (float.TryParse(entrada, out precio))
        {
            return true;
        }
        Debug.LogError("Error al convertir el precio a número");
        return false;
    }

    public void GuardarDatos()
    {
        for (int i = 0; i < nombreProducto.Length; i++)
        {
            string nombre = nombreProducto[i].text;
            string precioStr = precioProducto[i].text;

            if (EsEntradaValida(nombre, "NombreProducto" + i) && EsPrecioValido(precioStr, out float precio))
            {
                PlayerPrefs.SetString("NombreProducto" + i, nombre);
                PlayerPrefs.SetFloat("PrecioProducto" + i, precio);
            }
        }

        PlayerPrefs.SetInt("MaquinaArcade", maquinaArcade.isOn ? 1 : 0);
        PlayerPrefs.SetInt("MaquinaExpendedora", maquinaExpendedora.isOn ? 1 : 0);
        PlayerPrefs.SetInt("MaquinaRegalos", maquinaRegalos.isOn ? 1 : 0);
        PlayerPrefs.SetInt("NumeroEmpleados", numeroEmpleados.value);
    }

    public void CargarBarInicial()
    {
        GuardarDatos();
        SceneManager.LoadScene("BarInicial");
    }

    public void CargarSegundaPag()
    {
        GuardarDatos();
        Debug.Log("Cargando SegundaPag");
        SceneManager.LoadScene("SegundaPag");
    }
}

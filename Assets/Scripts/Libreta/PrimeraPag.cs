using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrimeraPag : MonoBehaviour
{
    public InputField[] nombreProducto;
    public InputField[] precioProducto;
    public Toggle maquinaArcade;
    public Toggle maquinaExpendedora;
    public Toggle maquinaRegalos;
    public Dropdown numeroEmpleados;

    public void GuardarDatos()
    {
        for (int i = 0; i < nombreProducto.Length; i++)
        {
            PlayerPrefs.SetString("NombreProducto" + i, nombreProducto[i].text);
            PlayerPrefs.SetFloat("PrecioProducto" + i, float.Parse(precioProducto[i].text));
        }

        PlayerPrefs.SetInt("MaquinaArcade", maquinaArcade.isOn ? 1 : 0);
        PlayerPrefs.SetInt("MaquinaExpendedora", maquinaExpendedora.isOn ? 1 : 0);
        PlayerPrefs.SetInt("MaquinaRegalos", maquinaRegalos.isOn ? 1 : 0);
        PlayerPrefs.SetInt("NumeroEmpleados", numeroEmpleados.value);

        // Puedes agregar aquí más lógica si es necesario
    }

    public void CargarBarInicial()
    {
        SceneManager.LoadScene("BarInicial");
    }

    public void CargarSegundaPag()
    {
        GuardarDatos();
        SceneManager.LoadScene("SegundaPag");
    }
}


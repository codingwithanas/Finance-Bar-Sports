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
        // Validar la entrada antes de guardar datos
        for (int i = 0; i < nombreProducto.Length; i++)
        {
            string nombre = nombreProducto[i].text.Trim();
            if (!string.IsNullOrEmpty(nombre))
            {
                PlayerPrefs.SetString("NombreProducto" + i, nombre);
                // Validar que el precio sea un número válido
                float precio;
                if (float.TryParse(precioProducto[i].text, out precio))
                {
                    PlayerPrefs.SetFloat("PrecioProducto" + i, precio);
                }
                else
                {
                    Debug.LogError("Error al convertir precio del producto " + i);
                }
            }
            else
            {
                Debug.LogError("El nombre del producto " + i + " no puede estar vacío");
            }
        }

        // Guardar las opciones de máquinas y empleados
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
        SceneManager.LoadScene("SegundaPag");
    }
}


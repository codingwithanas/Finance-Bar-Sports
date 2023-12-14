using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TerceraPag : MonoBehaviour
{
    public Text alquiler;
    public Text facturas;
    public Text consumibles;
    public Text regalos;
    public Text empleados;
    public InputField sumaTotal;
    public Text resultadoTotal;

    private void Start()
    {
        InicializarValores();
    }

    private void InicializarValores()
    {
        alquiler.text = "-60";
        facturas.text = "-40";
        //consumibles.text = (PlayerPrefs.GetInt("MaquinaExpendedora") == 1 ? -20 : 0) - PlayerPrefs.GetFloat("SumaTotal").ToString();
        regalos.text = PlayerPrefs.GetInt("MaquinaRegalos") == 1 ? "-150" : "0";
        empleados.text = (-50 * PlayerPrefs.GetInt("NumeroEmpleados")).ToString();
    }

    public void VerificarCalculos()
    {
        float totalCalculado = -60 - 40 + PlayerPrefs.GetFloat("SumaTotal") + (PlayerPrefs.GetInt("MaquinaExpendedora") == 1 ? -20 : 0) + (PlayerPrefs.GetInt("MaquinaRegalos") == 1 ? -150 : 0) - (50 * PlayerPrefs.GetInt("NumeroEmpleados"));
        float totalInput;

        if (float.TryParse(sumaTotal.text, out totalInput) && Mathf.Approximately(totalInput, totalCalculado))
        {
            resultadoTotal.text = sumaTotal.text;
        }
        else
        {
            sumaTotal.text = "";
            resultadoTotal.text = "";
        }
    }

    public void CargarBarInicial()
    {
        SceneManager.LoadScene("BarInicial");
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContadorDeClicks : MonoBehaviour
{
    private int contadorDeClicks = 0;
    public string pantallaVictoria = "PantallaVictoria"; // Asegúrate de cambiar esto por el nombre real de tu escena de victoria

    // Método público para incrementar el contador y comprobar si se alcanzó el límite
    public void IncrementarContador()
    {
        contadorDeClicks++; // Incrementa el contador de clicks
        if (contadorDeClicks >= 4) // Si se han hecho 4 clicks
        {
            // Carga la escena de victoria
            SceneManager.LoadScene(pantallaVictoria);
        }
    }
}

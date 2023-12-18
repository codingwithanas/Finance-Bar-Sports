using UnityEngine;

public class Salir : MonoBehaviour
{
    // Método público para cerrar el juego
    public void SalirDelJuego()
    {
        // Si estás corriendo el juego en el editor de Unity, esto detendrá la reproducción.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        // Si el juego está construido y ejecutándose fuera del editor, esto cerrará la aplicación.
        Application.Quit();
    }
}

using UnityEngine;

public class Salir : MonoBehaviour
{
    // M�todo p�blico para cerrar el juego
    public void SalirDelJuego()
    {
        // Si est�s corriendo el juego en el editor de Unity, esto detendr� la reproducci�n.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        // Si el juego est� construido y ejecut�ndose fuera del editor, esto cerrar� la aplicaci�n.
        Application.Quit();
    }
}

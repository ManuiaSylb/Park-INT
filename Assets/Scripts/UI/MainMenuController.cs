using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Méthode pour le bouton "Play"
    public void PlayGame()
    {
        // Charger la scène avec l'ID 2 (choix de niveau)
        SceneManager.LoadScene(2);
    }

    // Méthode pour le bouton "Exit"
    public void ExitGame()
    {
        // Quitter l'application
        Application.Quit();

        // Ce code est utile uniquement dans l'éditeur pour tester
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
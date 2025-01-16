using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Help()
    {
        SceneManager.LoadScene(5);
    }

    public void ExitGame()
    {
        PlayerPrefs.SetInt("Level1Validated", 0);
        PlayerPrefs.SetInt("Level2Validated", 0);
        PlayerPrefs.SetInt("Level3Validated", 0);
        PlayerPrefs.SetInt("Level1Score", 0);
        PlayerPrefs.SetInt("Level2Score", 0);
        PlayerPrefs.SetInt("Level3Score", 0);
        PlayerPrefs.Save();
        Application.Quit();

        // Ce code est utile uniquement dans l'éditeur pour tester
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
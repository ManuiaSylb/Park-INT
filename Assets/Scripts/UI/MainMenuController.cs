using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject Canvas_0;
    public GameObject Canvas_1;
    public GameObject Canvas_2;
    public GameObject Canvas_3;
    public GameObject Canvas_4;
    public AudioSource ClickSound;

    void Start()
    {   
        Canvas_0.SetActive(true);
        Canvas_1.SetActive(true);
        Canvas_2.SetActive(false);
        Canvas_3.SetActive(false);
        Canvas_4.SetActive(false);
        ClickSound.Play();

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowSettingsMenu()
    {
        Canvas_1.SetActive(false);
        Canvas_2.SetActive(true);
        ClickSound.Play();
    }

    public void CloseSettingsMenu()
    {
        Canvas_1.SetActive(true);
        Canvas_2.SetActive(false);
        ClickSound.Play();
    }
    
    public void Help(){
        Canvas_1.SetActive(false);
        Canvas_3.SetActive(true);
        ClickSound.Play();
    }

    public void CloseHelp(){
        Canvas_1.SetActive(true);
        Canvas_4.SetActive(false);
        Canvas_3.SetActive(false);
        ClickSound.Play();
    }

    public void Commands(){
        Canvas_3.SetActive(false);
        Canvas_4.SetActive(true);
        ClickSound.Play();
    }

    public void Rules(){
        Canvas_1.SetActive(false);
        Canvas_4.SetActive(false);
        Canvas_3.SetActive(true);
        ClickSound.Play();
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
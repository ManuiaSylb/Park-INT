using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour
{
    public LevelButtonController level1Button;
    public LevelButtonController level2Button;
    public LevelButtonController level3Button;
    public GameObject Canvas_0;
    public GameObject Canvas_1;
    public GameObject Canvas_2;
    public AudioSource ClickSound;

    void Start()
    {   
        ClickSound.Play();
        Canvas_0.SetActive(true);
        Canvas_1.SetActive(true);
        Canvas_2.SetActive(false);
        if (!PlayerPrefs.HasKey("Level1Validated"))
        {
            PlayerPrefs.SetInt("Level1Validated", 0);
            PlayerPrefs.Save();

        }

        if (!PlayerPrefs.HasKey("Level2Validated"))
        {
            PlayerPrefs.SetInt("Level2Validated", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("Level3Validated"))
        {
            PlayerPrefs.SetInt("Level3Validated", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("Level1Score"))
        {
            PlayerPrefs.SetInt("Level1Score", 0);
            PlayerPrefs.Save();

        }

        if (!PlayerPrefs.HasKey("Level2Score"))
        {
            PlayerPrefs.SetInt("Level2Score", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("Level3Score"))
        {
            PlayerPrefs.SetInt("Level3Score", 0);
            PlayerPrefs.Save();
        }

        level1Button.UnlockLevel();
    }

    public void Update()
    {
        if (PlayerPrefs.GetInt("Level1Validated") == 1)
        {
            level1Button.ValidateLevel();
            level2Button.UnlockLevel();
        }
        if (PlayerPrefs.GetInt("Level2Validated") == 1)
        {
            level2Button.ValidateLevel();
            level3Button.UnlockLevel();
        }
        if (PlayerPrefs.GetInt("Level3Validated") == 1)
        {
            level3Button.ValidateLevel();
        }
    }

    public void Level1()
    {
        SceneManager.LoadScene(2);
    }

    public void Level2()
    {
        SceneManager.LoadScene(3); 
    }

    public void Level3()
    {
        SceneManager.LoadScene(4); 
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowSettingsMenu()
    {
        Canvas_0.SetActive(true);
        Canvas_1.SetActive(false);
        Canvas_2.SetActive(true);
        ClickSound.Play();

    }

    public void CloseSettingsMenu()
    {
        Canvas_0.SetActive(true);
        Canvas_1.SetActive(true);
        Canvas_2.SetActive(false);
        ClickSound.Play();
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Level1Validated", 0);
        PlayerPrefs.SetInt("Level2Validated", 0);
        PlayerPrefs.SetInt("Level3Validated", 0);
        PlayerPrefs.SetInt("Level1Score", 0);
        PlayerPrefs.SetInt("Level2Score", 0);
        PlayerPrefs.SetInt("Level3Score", 0);
        PlayerPrefs.Save();
    }
}
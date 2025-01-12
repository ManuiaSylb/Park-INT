using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour
{
    public LevelButtonController level1Button;
    public LevelButtonController level2Button;
    public LevelButtonController level3Button;

    void Start()
    {   
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

        level1Button.UnlockLevel();
    }

    public void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("Level1Validated"));
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

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Level1Validated", 0);
        PlayerPrefs.SetInt("Level2Validated", 0);
        PlayerPrefs.SetInt("Level3Validated", 0);
        PlayerPrefs.Save();
    }
}
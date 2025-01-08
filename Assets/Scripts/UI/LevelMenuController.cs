using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour
{
    public LevelButtonController level1Button;
    public LevelButtonController level2Button;
    public LevelButtonController level3Button;

    void Start()
    {
        level1Button.isLevelUnlocked = true;
        level1Button.UpdateButtonState();

        level2Button.previousLevelButton = level1Button;
        level3Button.previousLevelButton = level2Button;
        
        level1Button.UnlockLevel();
    }

    public void ValidateLevel1()
    {
        level1Button.ValidateLevel();
        level2Button.UnlockLevel();
    }

    public void ValidateLevel2()
    {
        level2Button.ValidateLevel();
        level3Button.UnlockLevel();
    }

    public void ValidateLevel3()
    {
        level3Button.ValidateLevel();
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
}
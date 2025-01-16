using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarsManager : MonoBehaviour
{
    private int score;
    public InGame inGameScript;
    public LifeManager lifeManager; 
    public Sprite[] starSprites; 
    private Image imageComponent; 

    public void Stars()
    {
        score = 1;
        imageComponent = GetComponent<Image>();

        if (inGameScript != null)
        {
            float chrono = inGameScript.GetElapsedTime();
            if (chrono <= 60f)
            {
                score = Mathf.Min(score + 1, 3); 
            }
        }

        if (lifeManager != null && lifeManager.PV == 100)
        {
            score = Mathf.Min(score + 1, 3); 
        }

        if (imageComponent != null)
        {
            if (score == 1)
            {
                imageComponent.sprite = starSprites[0];
            }
            else if (score == 2)
            {
                imageComponent.sprite = starSprites[1];
            }
            else if (score == 3)
            {
                imageComponent.sprite = starSprites[2];
            }
        }

        int currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        int PrevScore=0;
        if (PlayerPrefs.HasKey("Level" + currentLevel + "Score")){
            PrevScore=PlayerPrefs.GetInt("Level" + currentLevel + "Score");
        }
        if (score>=PrevScore){
            PlayerPrefs.SetInt("Level" + currentLevel + "Score", score);
            PlayerPrefs.Save();
        }
        
    }
}
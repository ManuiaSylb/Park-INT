using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{
    public Button levelButton;
    public Image buttonImage;  
    public Sprite lockedSprite;
    public Sprite unlockedSprite;
    public Sprite validatedSprite;
    
    public bool isLevelUnlocked = false;  
    public bool isLevelValidated = false; 
    public LevelButtonController previousLevelButton; 

    void Start()
    {
        if (levelButton != null)
        {
            UpdateButtonState();
        }
    }

  
    public void UpdateButtonState()
    {
        if (isLevelValidated)
        {
            buttonImage.sprite = validatedSprite;
            levelButton.interactable = true; 
        }
        else if (isLevelUnlocked)
        {
            buttonImage.sprite = unlockedSprite;
            levelButton.interactable = true; 
        }
        else
        {
            buttonImage.sprite = lockedSprite;
            levelButton.interactable = false; 
        }
    }


    public void UnlockLevel()
    {
        if (previousLevelButton != null && previousLevelButton.isLevelValidated)
        {
            isLevelUnlocked = true;
            UpdateButtonState();
        }
    }


    public void ValidateLevel()
    {
        isLevelValidated = true;
        UpdateButtonState();
    }
}
using UnityEngine;
using UnityEngine.UI;

public class UpdateCarLife : MonoBehaviour
{
    public LifeManager lifeManager;
    public Sprite[] carLifeSprites;
    private Image carLifeImage;

    void Start()
    {
        carLifeImage = GetComponent<Image>();

        if (carLifeSprites.Length < 5)
        {
            Debug.LogError("You must assign 5 sprites in the array!");
        }
    }

    void Update()
    {
        if (lifeManager != null)
        {
            UpdateSprite(lifeManager.PV);
        }
    }

    void UpdateSprite(int pv)
    {
        if (pv > 80)
            carLifeImage.sprite = carLifeSprites[0];
        else if (pv > 60)
            carLifeImage.sprite = carLifeSprites[1];
        else if (pv > 40)
            carLifeImage.sprite = carLifeSprites[2];
        else if (pv > 20)
            carLifeImage.sprite = carLifeSprites[3];
        else
            carLifeImage.sprite = carLifeSprites[4];
    }
}
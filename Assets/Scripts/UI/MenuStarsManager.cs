using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importer pour travailler avec l'UI

public class MenuStarsManager : MonoBehaviour
{
    // Tableau de sprites pour les 4 états d'étoiles
    public Sprite[] starsSprites; // 0 étoiles, 1 étoile, 2 étoiles, 3 étoiles

    // Références aux images des étoiles dans l'UI
    private Image star1Image;
    private Image star2Image;
    private Image star3Image;

    void Start()
    {
        // Récupérer les composants Image des enfants Stars1, Stars2, Stars3
        star1Image = transform.Find("Stars1").GetComponent<Image>();
        star2Image = transform.Find("Stars2").GetComponent<Image>();
        star3Image = transform.Find("Stars3").GetComponent<Image>();

        // Mettre à jour les sprites des étoiles au démarrage
        UpdateStars();
    }

    void UpdateStars()
    {
        // Récupérer les scores (remplace par tes propres clés PlayerPrefs)
        int score1 = PlayerPrefs.GetInt("Level1Score", 0);
        int score2 = PlayerPrefs.GetInt("Level2Score", 0);
        int score3 = PlayerPrefs.GetInt("Level3Score", 0);

        // Assigner les sprites en fonction des scores
        star1Image.sprite = starsSprites[score1];
        star2Image.sprite = starsSprites[score2];
        star3Image.sprite = starsSprites[score3];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusItem : MonoBehaviour
{
    public Button skin2Btn;


    private int daysPlayed;

    void Start()
    {
        daysPlayed = PlayerPrefs.GetInt("DaysPlayed");

        if (daysPlayed >= 3)
        {
            PlayerPrefs.SetInt("Skin2_Unlocked", 1);        // Entier de valeur 0 ou 1 pour savoir si le Skin 2 est débloqué
            skin2Btn.interactable = true;       // Permet de pouvoir cliquer sur le bouton du skin 2 pour pouvoir le selectionner
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DateCalcul : MonoBehaviour
{
    DateTime startDate;
    DateTime today;

    private void Awake()
    {

        SetStartDate();
    }

    /// <summary>
    /// Enregistre la Date de première connexion au jeu
    /// </summary>
    void SetStartDate()
    {
        if (PlayerPrefs.HasKey("StartDate"))
            startDate = System.Convert.ToDateTime(PlayerPrefs.GetString("StartDate"));
        else
        {
            startDate = DateTime.Now;
            PlayerPrefs.SetString("StartDate", startDate.ToString());
        }
        // Stock en mémoire le nombre de jours qui s'est écoulé
        PlayerPrefs.SetInt("DaysPlayed", GetDaysPlayed());
    }

    private int GetDaysPlayed()
    {
        today = DateTime.Now;
        // elapsed = temps écoulé entre DateTime.Now et la première de connexion Dateenregistré
        TimeSpan elapsed = today.Subtract(startDate);
        return int.Parse(elapsed.TotalDays.ToString("0"));
    }
}

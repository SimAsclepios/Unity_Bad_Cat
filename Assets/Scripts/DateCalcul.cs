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
    /// Enregistre la Date de premi�re connexion au jeu
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
        // Stock en m�moire le nombre de jours qui s'est �coul�
        PlayerPrefs.SetInt("DaysPlayed", GetDaysPlayed());
    }

    private int GetDaysPlayed()
    {
        today = DateTime.Now;
        // elapsed = temps �coul� entre DateTime.Now et la premi�re de connexion Dateenregistr�
        TimeSpan elapsed = today.Subtract(startDate);
        return int.Parse(elapsed.TotalDays.ToString("0"));
    }
}

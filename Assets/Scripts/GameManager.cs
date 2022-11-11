using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level = 1;
    public GameObject[] Rooms;
    public GameObject[] Tutos;
    public GameObject ScreenEnd;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textScoreEnd;
    public TextMeshProUGUI textScoreLast;
    public TextMeshProUGUI textScoreMax;
    public TextMeshProUGUI textTimer;

    public int timerParty = 20;     // TODO : Pour l'instant en public pour tester plus rapidement inGame la fin du jeu

    public bool gameStarted = false;
    public bool gameEnded = false;

    void Awake()
    {
        // Parfois Bug Unity lors d'un (Re)LoadLevel : tout ne se réinitialise pas bien, une des façon de réinitialiser les variables est de les mettre dans le Awake OU avant le (Re)LoadLevel
        //timerParty = 30;

        for (int i = 1 ; i <= Rooms.Length; i++)
        {
            if (i <= level)
            {
                Rooms[i - 1].SetActive(true);
                // TODO : Faire pareil avec tableau des murs pour savoir quel mur et cadre porte faire apparaitre en fonction du nombre de pieces.
            }
        }
        textScoreMax.text = PlayerPrefs.GetInt("scoreMax", 0).ToString();
        textScoreLast.text = PlayerPrefs.GetInt("scoreLast", 0).ToString();
    }

    void Update()
    {
        
    }
    public void StartGame()
    {
        //if (Input.GetMouseButtonDown(0) && !gameStarted)
        //{
        textTimer.text = GetTimer().ToString();
        gameStarted = true;
        Tutos[0].SetActive(false);
        InvokeRepeating("SetTimer", 1, 1);
        //}
    }
    /// <summary>
    /// Chronomètre mis à jour
    /// </summary>
    public void SetTimer()
    {
        timerParty--;
        textTimer.text = timerParty.ToString();
        // Si c'est la fin de la partie
        if (timerParty <= 0)
        {
            int scoreEnd = int.Parse(textScore.text);
            PlayerPrefs.SetInt("scoreLast", scoreEnd);
            // Donne par défaut la valeur 0 si le score Maximum enregistré n'est pas trouvé (1ere partie)
            int scoreMax = PlayerPrefs.GetInt("scoreMax", 0);
            if (scoreEnd > scoreMax)
                PlayerPrefs.SetInt("scoreMax", scoreEnd);


            gameEnded = true;
            // Annule toutes les méthodes invoke de notre classe
            CancelInvoke();
            ScreenEnd.SetActive(true);
            textScoreEnd.text = textScore.text;
        }
    }
    /// <summary>
    /// Bouton Rejouer après la fin de la partie
    /// </summary>
    public void RestartGame()
    {
        //timerParty = 30;

        // Rechargement de la scene nommé 'SampleScene' dans la fenètre Project -> Assets -> Scenes
        // Parfois Bug Unity lors d'un (Re)LoadLevel : tout ne se réinitialise pas bien, une des façon de réinitialiser les variables est de les mettre dans le Awake OU avant le (Re)LoadLevel
        SceneManager.LoadScene("SampleScene");      //Application.LoadLevel(Application.loadedLevelName);
    }

    public void WatchExtraTimeVideo()
    {
        //TODO : Afficher Pub Vidéo
        //TODO : Détecter si pub est vu
        GetExtraTime();
    }
    public void GetExtraTime()
    {
        timerParty = 15;
        textTimer.text = timerParty.ToString();     // Sinon affiche 0 puis la valeur donner juste en haut - 1 après 1 seconde
        gameEnded = false;
        ScreenEnd.SetActive(false);
        InvokeRepeating("SetTimer", 1, 1);
    }
    public int GetTimer()
    {
        int TimerLVL = PlayerPrefs.GetInt("TimerLVL", 0);
        int BonusTime;
        if (TimerLVL > 10)
        {
            int TimeTwoPoint = TimerLVL - 10;
            BonusTime = 10 + TimeTwoPoint * 2;
        }
        else
            BonusTime = TimerLVL;
        return (timerParty + BonusTime);
    }
}

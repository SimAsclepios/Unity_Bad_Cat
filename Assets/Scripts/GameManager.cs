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
    public TextMeshProUGUI textTimer;

    public int timerParty = 30;     // TODO : Pour l'instant en public pour tester plus rapidement inGame la fin du jeu

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
    }

    void Update()
    {
        // Jeu démarré
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            gameStarted = true;
            Tutos[0].SetActive(false);
            InvokeRepeating("SetTimer", 1, 1);
        }
    }
    /// <summary>
    /// Chronomètre mis à jour
    /// </summary>
    public void SetTimer()
    {
        timerParty--;
        textTimer.text = timerParty.ToString();
        if (timerParty <= 0)
        {
            gameEnded = true;
            // Annule toutes les méthodes invoke de notre classe
            CancelInvoke();
            ScreenEnd.SetActive(true);
        }
    }
    /// <summary>
    /// Bouton Rejouer après la fin de la partie
    /// </summary>
    public void RestartGame()
    {
        // Parfois Bug Unity lors d'un (Re)LoadLevel : tout ne se réinitialise pas bien, une des façon de réinitialiser les variables est de les mettre dans le Awake OU avant le (Re)LoadLevel
        //timerParty = 30;

        // Rechargement de la scene nommé 'SampleScene' dans la fenètre Project -> Assets -> Scenes
        SceneManager.LoadScene("SampleScene");      //Application.LoadLevel(Application.loadedLevelName);
    }
}

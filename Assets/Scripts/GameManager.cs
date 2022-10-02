using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int level = 1;
    public GameObject[] Rooms;
    public GameObject[] Tutos;

    private bool gameStarted = false;

    void Awake()
    {
        for (int i = 1 ; i <= Rooms.Length; i++)
        {
            if (i <= level)
            {
                Rooms[i - 1].SetActive(true);
                // TODO : Faire pareil avec tableau des murs pour savoir quel mur et cadre porte faire apparaitre en fonction du nombre de pieces.
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            gameStarted = true;
            Tutos[0].SetActive(false);
        }
    }
}

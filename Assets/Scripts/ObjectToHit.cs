using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToHit : MonoBehaviour
{
    ///// <summary>
    ///// Points que rapporte un objet = masse. Quand masse > 10 ne pas comptabiliser
    ///// </summary>
    //public int points = 1;

    public int coins;

    private void Awake()
    {
        coins = PlayerPrefs.GetInt("coins", 1);
    } 
}

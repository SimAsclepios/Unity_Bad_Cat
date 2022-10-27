using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    public GameObject Shop;

    public void SelectSkin(int SkinId)
    {
        print("Le joueur a cliqué sur le skin : " + SkinId);
        //TODO : à coder
        Shop.SetActive(false);
    }

}

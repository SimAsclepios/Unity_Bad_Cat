using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    public GameObject Shop;

    public void SelectSkin(int SkinId)
    {
        print("Le joueur a cliqu� sur le skin : " + SkinId);
        //TODO : � coder
        Shop.SetActive(false);
    }

}

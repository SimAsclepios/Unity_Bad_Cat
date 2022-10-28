using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    public GameObject Shop;

    public void SelectSkin(int skinId)
    {
        print("Le joueur a cliqu� sur le skin : " + skinId);
        PlayerPrefs.SetInt("selectedSkin", skinId);
        //TODO : � coder
        Shop.SetActive(false);
    }

}

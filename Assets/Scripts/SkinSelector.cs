using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    public GameObject Shop;
    public CatSkin CS;

    public void SelectSkin(int skinId)
    {
        print("Le joueur a cliqué sur le skin : " + skinId);
        PlayerPrefs.SetInt("selectedSkin", skinId);
        CS.SetSkin(skinId);
        Shop.SetActive(false);
    }

}

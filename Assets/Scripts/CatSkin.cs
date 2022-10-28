using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSkin : MonoBehaviour
{
    public Texture2D[] Skins;
    /// <summary>
    /// Pour modifier la texture du matérial pour lui appliquer un skin
    /// </summary>
    public Material CatMaterial;
    public int CatSkinId;

    private void Awake()
    {
        // PlayerPrefs pour sauvegarder / récupérer des données sauvegarder en local sur PC utilisateur. (même principe que la 'session' en Java Web, sauf que les données persistent après déconnexion pour PlayerPrefs sur son SSD)
        // Va chercher l'entier sauvegardé nommé "selectedSkin", si il ne le trouve pas, affecte la valeur par défaut = 0
        CatSkinId = PlayerPrefs.GetInt("selectedSkin", 0);
        CatMaterial.mainTexture = Skins[CatSkinId];
    }
}

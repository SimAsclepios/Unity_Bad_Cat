using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSkin : MonoBehaviour
{
    public Texture2D[] Skins;
    /// <summary>
    /// Pour modifier la texture du mat�rial pour lui appliquer un skin
    /// </summary>
    public Material CatMaterial;
    public int CatSkinId;

    private void Awake()
    {
        // PlayerPrefs pour sauvegarder / r�cup�rer des donn�es sauvegarder en local sur PC utilisateur. (m�me principe que la 'session' en Java Web, sauf que les donn�es persistent apr�s d�connexion pour PlayerPrefs sur son SSD)
        // Va chercher l'entier sauvegard� nomm� "selectedSkin", si il ne le trouve pas, affecte la valeur par d�faut = 0
        CatSkinId = PlayerPrefs.GetInt("selectedSkin", 0);
        CatMaterial.mainTexture = Skins[CatSkinId];
    }
}

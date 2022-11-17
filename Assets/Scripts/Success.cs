using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Success : MonoBehaviour
{
    public string SuccessName;
    public GameObject Check_GO;


    private void Start()
    {
        if (PlayerPrefs.GetInt(SuccessName, 0) == 1)
        {
            Check_GO.SetActive(true);       // Check le succes
            //GameObject.Find(SuccessName).SetActive(true);      // rend visible la récompense  (dans les skins
            //GameObject.Find(SuccessName).GetComponent<Button>().interactable = true;    // Rend le bouton du nom de l'objet dans lequel il est, interactable
        }
    }

}

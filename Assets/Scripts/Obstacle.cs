using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Obstacle : MonoBehaviour
{
    public float speed;
    //protected TextMeshProUGUI TMP;
    protected GameObject Score;  // text
    protected GameObject ScoreMax;
    protected GameObject ScoreLast;
    protected static int i_ScoreMax;
    protected static int i_ScoreLast;

    [HideInInspector]       // Cacher dans l'inspecteur. La variable est public car utilisé dans la classe Player
    public static bool b_Player_Dead;       // ne pas initialiser à false ici ?     C'est le start de la classe player qui s'en occupe


    public GameObject WinEffect;
    protected Transform WinEffectPos;
    public GameObject LoseEffect;
    protected Transform LoseEffectPos;


    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.up, 180);      // Pour Pop les mobs dans la bonne direction
        Score = GameObject.Find("Score"); //.GetComponent<TextMeshProUGUI>() // (Ancienne méthode : Va chercher un Composant de Type TMP d'un GameObject) qui s'appelle "Score" (Notre texte créé avant est avant tout un GameObject comprenant un composant TMP)
        print("ScoreLast Start : " + i_ScoreLast);
        try
        {
            WinEffectPos = GameObject.Find("WinEffectPos").transform;
            LoseEffectPos = GameObject.Find("LoseEffectPos").transform;
        }
        catch (Exception e)
        {
            print(e.Message);
        }
        try
        {
            ScoreMax = GameObject.Find(nameof(ScoreMax));       //  maj : va chercher un gameobject qui s'appelle ScoreMax
            ScoreLast = GameObject.Find(nameof(ScoreLast));       //  maj : va chercher un gameobject qui s'appelle ScoreLast
            ScoreMax.GetComponent<TextMeshProUGUI>().text = i_ScoreMax.ToString();
            print("ScoreLast Start 2 : " + i_ScoreLast);
            ScoreLast.GetComponent<TextMeshProUGUI>().text = i_ScoreLast.ToString();
            print("ScoreLast Start 3 : " + i_ScoreLast);
            print("ScoreLast_Screen 4 : " + ScoreLast.GetComponent<TextMeshProUGUI>().text);

        }
        catch (Exception e)
        {

            print(e);
        }
        finally
        {
            //i_ScoreLast = 0;
            //i_ScoreMax = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);      // back = Direction arrière : Cliquer sur le GameObject pour le déplacer. le back correspond au sens opposé de la flèche bleue (forward)
                                                                 // Time.deltaTime = permet de calibrer la vitesse sur tous les PC
                                                                 // (Un ordi surpuissant peu faire beaucoup plus de fois le calcul qu'un pc lent et donc fera avancer l'objet plus vite)
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Invoke(nameof(ChangeScoreMax), 1.9f);

            b_Player_Dead = true;

            Instantiate(LoseEffect, LoseEffectPos.position, Quaternion.identity);
            iTween.PunchScale(collision.gameObject, new Vector3(1.0f, 1.0f, 1.0f), 0.3f);
            Destroy(collision.gameObject, 0.3f);       // Détruit le joueur après 1 seconde
            //Destroy(gameObject);
            Invoke("ReloadScene", 2);         // Appel la méthode ReloadScene après 3 secondes d'attente  
                                              // ! Attention ! Si on détruit le gameObject qui contient ce script avant, alors le script disparaitra avec (1 script par GameObject/Monstre),
                                              // et la detruction du gameObject sera sa dernière action appelée ..
        }
        if (collision.gameObject.name == "OutWall" && !b_Player_Dead)
        {
            try
            {
                iTween.PunchScale(Score, new Vector3(2, 2, 2), 0.4f);
                Instantiate(WinEffect, WinEffectPos.position, Quaternion.identity);
                int newScore = int.Parse(Score.GetComponent<TextMeshProUGUI>().text) + 1;
                Score.GetComponent<TextMeshProUGUI>().text = newScore.ToString();
            }
            catch (Exception e)
            {
                print(e.Message);
            }
            Destroy(gameObject);
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ChangeScoreMax()
    {
        //ScoreMax = GameObject.Find(nameof(ScoreMax));       //  maj : va chercher un gameobject qui s'appelle ScoreMax
        //ScoreLast = GameObject.Find(nameof(ScoreLast));       //  maj : va chercher un gameobject qui s'appelle ScoreLast
        print("ScoreLast ChangeScore 1 : " + i_ScoreLast);
        i_ScoreLast = int.Parse(Score.GetComponent<TextMeshProUGUI>().text);
        print("ScoreLast ChangeScore 2 : " + i_ScoreLast);

        if (i_ScoreLast > int.Parse(ScoreMax.GetComponent<TextMeshProUGUI>().text))
        {
            i_ScoreMax = i_ScoreLast;
        }
    }
}

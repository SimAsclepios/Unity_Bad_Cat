using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Déplacement du joueur par touch + slide du doigt
/// </summary>
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Obstacle.b_Player_Dead = false;
    }


    private Touch touch;
    /// <summary>
    /// Sensibilité pour bouger le joueur lorsqu'on fait glisser le doigt sur l'écran
    /// </summary>
    public float sensibility;
    public float posXmin;
    public float posXmax;
    // Update is called once per frame
    void Update()
    {
        //  Si le joueur a eu moins 1 doigt sur l'écran
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);  // prend les données du premier doigt posé sur l'écran (index = 0) Les autres seront donc ignorés puisqu'ils ne sont pas stockés dans un autre attribut

            if (touch.phase == TouchPhase.Moved)     // si le doigt bouge
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * sensibility/1000,
                    transform.position.y,
                    transform.position.z
                    );      // Change les positions de(s) l'objet(s) dans lequel est placé le script
            }
            if (transform.position.x < posXmin)
            {
                transform.position = new Vector3(
                    posXmin,
                    transform.position.y,
                    transform.position.z
                    );      // Si le posiion de l'objet est hors limite, le retéléporte à la position limite
            }
            if (transform.position.x > posXmax)
            {
                transform.position = new Vector3(
                    posXmax,
                    transform.position.y,
                    transform.position.z
                    );      // Si le posiion de l'objet est hors limite, le retéléporte à la position limite
            }
        }
    }
}

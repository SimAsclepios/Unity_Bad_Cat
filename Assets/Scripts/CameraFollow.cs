using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /// <summary>
    /// Distance � laquelle est positionn� la cam�ra par rapport au personnage
    /// </summary>
    public float distance;
    /// <summary>
    /// Hauteur de la cam�ra par rapport � notre personnage
    /// </summary>
    public float height;
    /// <summary>
    /// Fluidit� du suivi de la cam�ra
    /// </summary>
    public float smoothness;
    public Transform Target;

    Vector3 velocity;

    void Start()
    {
        
    }

    // Tourne avec un frameRate fixe (ex : 60 img/sec) : �vite l'utilisation du Time.deltaTime ? | Utilis� surtout lorsqu'il y a des calculs de physique, gravit�, rigidBody.
    void FixedUpdate()
    {
        
    }
    // LateUpdate est une mise � jour juste apr�s Update 
    private void LateUpdate()
    {
        Vector3 pos = Vector3.zero;
        pos.x = Target.position.x;
        pos.y = Target.position.y + height;
        pos.z = Target.position.z - distance;

        // mot cl� 'ref' en param�tre de m�thode se rapproche fortement de 'out' : Passe la r�f�rence au lieu de passer la valeur = modification apport�e � cet argument dans la m�thode sera refl�t�e dans la variable
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothness/10);  // /10 pour pouvoir entrer des valeur *10 en smoothness


    }
}

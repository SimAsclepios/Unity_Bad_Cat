using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /// <summary>
    /// Distance à laquelle est positionné la caméra par rapport au personnage
    /// </summary>
    public float distance;
    /// <summary>
    /// Hauteur de la caméra par rapport à notre personnage
    /// </summary>
    public float height;
    /// <summary>
    /// Fluidité du suivi de la caméra
    /// </summary>
    public float smoothness;
    public Transform Target;

    Vector3 velocity;

    void Start()
    {
        
    }

    // Tourne avec un frameRate fixe (ex : 60 img/sec) : évite l'utilisation du Time.deltaTime ? | Utilisé surtout lorsqu'il y a des calculs de physique, gravité, rigidBody.
    void FixedUpdate()
    {
        
    }
    // LateUpdate est une mise à jour juste après Update 
    private void LateUpdate()
    {
        Vector3 pos = Vector3.zero;
        pos.x = Target.position.x;
        pos.y = Target.position.y + height;
        pos.z = Target.position.z - distance;

        // mot clé 'ref' en paramètre de méthode se rapproche fortement de 'out' : Passe la référence au lieu de passer la valeur = modification apportée à cet argument dans la méthode sera reflétée dans la variable
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothness/10);  // /10 pour pouvoir entrer des valeur *10 en smoothness


    }
}

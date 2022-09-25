using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToMove : MonoBehaviour
{
    public float speed;
    /// <summary>
    /// plein de caractéristiques, pour savoir par exemple quel % de pente le joueur a le droit de monter.
    /// </summary>
    public CharacterController characterController;
    Touch touch;
    /// <summary>
    /// Position 2D : Capte la position quand le joueur touch l'écran
    /// </summary>
    Vector2 initPos;
    /// <summary>
    /// Direction 3D : Pour quznd le chat saute
    /// </summary>
    Vector3 moveDirection;
    float gravity = -10f;
    
    void Start()
    {
       
    }


    void Update()
    {
        // savoir si le joueur a touché l'écran ou non
        if (Input.touchCount > 0)
        {
            // calcul du mouvement du personnage
            touch = Input.GetTouch(0);
            // au moment ou le joueur touche l'écran
            if (touch.phase == TouchPhase.Began)
            {
                initPos = touch.position;
            }
            // Lorsque le joueur déplace son doigt sur l'écran
            if (touch.phase == TouchPhase.Moved)
            {
                //direction = touch.deltaPosition;
            }
            if (characterController.isGrounded)
            {
                // calcul de la direction de déplacement
                moveDirection = new Vector3(touch.position.x - initPos.x, 0, touch.position.y - initPos.y);
                // Calcul de la rotation
                Quaternion targetRotation = moveDirection != Vector3.zero ? Quaternion.LookRotation(moveDirection) : transform.rotation;
                // On applique la rotation
                transform.rotation = targetRotation;
                moveDirection *= speed;     // moveDirection * Speed
            }
        }
        else
        {
            moveDirection = Vector3.zero;
        }
        // calculer la gravité 
        moveDirection.y = moveDirection.y + (gravity * Time.deltaTime);
        // On applique le mouvement au personnage
        characterController.Move(moveDirection * Time.deltaTime);
    }
}

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
    public float jumpForce;
    public float freinForce;
    private bool b_IsRunning = false;
    public Animator animator;
    public GameObject jumpEffect;
    public GameManager gm;

    void Start()
    {

    }


    void Update()
    {

        if (!gm.gameEnded && gm.gameStarted)
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

                    // Active Animation Run
                    b_IsRunning = true;
                }
                else
                    b_IsRunning = false;
                // Après avoir changer notre bool "b_IsRunning", affecter sa valeur au bool de l'animation "Running" pour qu'elle change également
                animator.SetBool("Running", b_IsRunning);
                if (characterController.isGrounded)
                {
                    // calcul de la direction de déplacement
                    moveDirection = new Vector3(touch.position.x - initPos.x, 0, touch.position.y - initPos.y);
                    // Calcul de la rotation
                    Quaternion targetRotation = moveDirection != Vector3.zero ? Quaternion.LookRotation(moveDirection) : transform.rotation;
                    // On applique la rotation
                    transform.rotation = targetRotation;
                    // normalized permet d'avoir toujours la même taille de vector3 quelque soit la distance du slide avec le doigt = petit ou grand slide donne le même vector3 pour avoir la même vitesse.
                    moveDirection = moveDirection.normalized * speed/100;     
                }
            }
            else
            {
                moveDirection = Vector3.Lerp(moveDirection, Vector3.zero, Time.deltaTime * freinForce);
            }
            // Gestion du saut permis uniquement lorsque le personnage est au sol
            if(Input.GetMouseButtonUp(0) && characterController.isGrounded)
            {
                Instantiate(jumpEffect, transform.position, Quaternion.identity);   // Quaternion.identity = Conservation de la rotation
                // Faire sauter le personnage
                moveDirection.y += jumpForce;

                // Applique une impulsion vers l'avant pour propulser le personnage plus loin vers l'avant
                moveDirection += transform.forward;
            }

            // calculer la gravité 
            moveDirection.y = moveDirection.y + (gravity * Time.deltaTime);
            // On applique le mouvement au personnage
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;
    private void Update()
    {
        // Pour que le score s'oriente en fonction de la caméra, pour rester toujours face à elle et donc face à l'écran
        transform.LookAt(cam);
    }
}

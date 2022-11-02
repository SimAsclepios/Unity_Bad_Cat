using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;
    private void Update()
    {
        // Pour que le score s'oriente en fonction de la cam�ra, pour rester toujours face � elle et donc face � l'�cran
        transform.LookAt(cam);
    }
}

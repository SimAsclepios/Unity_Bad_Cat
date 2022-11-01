using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHitter : MonoBehaviour
{
    public float f_explosionForce;
    /// <summary>
    /// Liste de particules a générer quand une nouvelle collision est détectée
    /// </summary>
    public GameObject[] hitParticles;
    protected string[] hitVerbs = new string[]
    {
        "piétine", "détruit", "frappe", "a cassé", "fonce sur", "explose", "fait voler"
    };
    /// <summary>
    /// Obliger de mettre System.Random dans projet Unity, car Unity a son propre Random également et sinon va capter en priorité le Random Unity
    /// Ici Random de Microsoft
    /// </summary>
    protected readonly System.Random random = new System.Random();

    // Méthode Unity !!!  Comme les méthodes Start et Update en fait ! ...
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody obj_rb = hit.gameObject.GetComponent<Rigidbody>();
        if (hit.gameObject.CompareTag("Hittable") && obj_rb.mass <= 10 && !hit.gameObject.name.Contains("Plane") && !hit.gameObject.name.Contains("Wall"))
        {
            // Max value - 1 pour la vrai valeur maximale possible ..
            print("Le renard " + hitVerbs[random.Next(0, 7)] + " " + hit.gameObject.name);
            // Change le Tag du GameObject pour ne gagner qu'une fois les points à sa collision
            hit.gameObject.tag = "Hitted";
            // Retire le static de l'objet pour qu'il puisse de nouveau être bougé par des forces extérieurs
            obj_rb.isKinematic = false;
            print(hit.gameObject.name + " : tag = " + hit.gameObject.tag + "    | kinetic = " + obj_rb.isKinematic.ToString());
            // Simule une explosion physique type grenade ;   Vector3.down = baisse l'épicentre de l'explosion pour que les objets se propulse plus vers le haut ;   upwardsModifier = ? ;    ForceMode = ?
            obj_rb.AddExplosionForce(f_explosionForce, transform.position + Vector3.down, 15);
            // Instancier un effet de particule à la collision
            Instantiate(hitParticles[Random.Range(0, hitParticles.Length)], hit.gameObject.transform.position, Quaternion.identity);
            //obj_rb = null;
        }
    }
}

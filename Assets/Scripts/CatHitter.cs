using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatHitter : MonoBehaviour
{
    public float f_explosionForce;
    public GameObject ScoreAdd;
    public GameObject TextScore;
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
    // Entre dans la méthode quand une collision du GameObject dans lequel on a mis ce script est detecté avec un autre GameObject (capté en paramètre de méthode)
    private void OnControllerColliderHit(ControllerColliderHit obj_Collider)
    {
        Rigidbody objCol_RB = obj_Collider.gameObject.GetComponent<Rigidbody>();
        if (obj_Collider.gameObject.CompareTag("Hittable") && objCol_RB.mass <= 10 && !obj_Collider.gameObject.name.Contains("Plane") && !obj_Collider.gameObject.name.Contains("Wall"))
        {
            // Max value - 1 pour la vrai valeur maximale possible ..
            print("Le renard " + hitVerbs[random.Next(0, 7)] + " " + obj_Collider.gameObject.name);
            // Change le Tag du GameObject pour ne gagner qu'une fois les points à sa collisionq
            obj_Collider.gameObject.tag = "Hitted";

            HitEffect(obj_Collider, objCol_RB);
            Score3DEffect(objCol_RB);
            GetCoins(objCol_RB);
        }
    }

    public void HitEffect(ControllerColliderHit obj_Collider, Rigidbody objCol_RB)
    {
        // Retire le static de l'objet pour qu'il puisse de nouveau être bougé par des forces extérieurs
        objCol_RB.isKinematic = false;
        print(obj_Collider.gameObject.name + " : tag = " + objCol_RB.gameObject.tag + "    | kinetic = " + objCol_RB.isKinematic.ToString());
        // Simule une explosion physique type grenade ;   Vector3.down = baisse l'épicentre de l'explosion pour que les objets se propulse plus vers le haut ;   upwardsModifier = ? ;    ForceMode = ?
        objCol_RB.AddExplosionForce(f_explosionForce, transform.position + Vector3.down, 15);
        // Instancier un effet de particule à la collision
        Instantiate(hitParticles[Random.Range(0, hitParticles.Length)], obj_Collider.gameObject.transform.position, Quaternion.identity);
        // Effet Punch sur le score, vector est l'extension / force du punch, puis la durée de l'effet sur la durée
        iTween.PunchScale(TextScore, new Vector3(2f, 2f, 2f), 0.75f);
    }

    /// <summary>
    /// Va chercher la mass de l'objet pour donner le score de l'objet
    /// </summary>
    /// <param name="objCol_RB"></param>
    public void Score3DEffect(Rigidbody objCol_RB)
    {
        int scoreAdd = (int)objCol_RB.mass * 10;
        int scoreTot = int.Parse(TextScore.GetComponent<TextMeshProUGUI>().text) + scoreAdd;
        TextScore.GetComponent<TextMeshProUGUI>().text = scoreTot.ToString();
        ScoreAdd.GetComponent<TextMesh>().text = "+" + scoreAdd.ToString();
        iTween.PunchScale(ScoreAdd, new Vector3(4f, 4f, 4f), 0.75f);
        Invoke("ResetScoreAdd", 0.75f);
    }

    public void GetCoins(Rigidbody objCol_RB)
    {
        int actualCoins = PlayerPrefs.GetInt("nbCoins", 0);

        // Limiter à 999 999 999 l'argent que peut contenir le joueur
        if (actualCoins + (int)objCol_RB.mass > 999999999)
            PlayerPrefs.SetInt("nbCoins", 999999999);
        else
            PlayerPrefs.SetInt("nbCoins", actualCoins + (int)objCol_RB.mass);
    }

    public void ResetScoreAdd()
    {
        ScoreAdd.GetComponent<TextMesh>().text = "";
    }
}

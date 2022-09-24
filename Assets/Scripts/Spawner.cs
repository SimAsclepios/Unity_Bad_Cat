using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Ennemy;
    public Transform[] t_Positions;
    protected static float f_FrequenceSpeed;
    protected static int i_LastSpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        //print(f_FrequenceSpeed);
        i_LastSpawnPos = -1;
        f_FrequenceSpeed = 1f;
        Invoke(nameof(SpawnEnnemy), 1);       // Ex�cute une m�thode � interval r�gulier (dernier param�tre), et d�mararre au 2e param�tre
        InvokeRepeating(nameof(Update_Spawn_Frequence), 5, 5);
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void SpawnEnnemy()
    {
        Instantiate(Ennemy, t_Positions[Get_NewSpawnPos()].position, Quaternion.identity);            // .position pour parse en vector3 et non avoir un Transform si on ne le fait pas
        Invoke(nameof(SpawnEnnemy), f_FrequenceSpeed);
    }

    public void Update_Spawn_Frequence()
    {
        if (f_FrequenceSpeed > 0.3f)
            f_FrequenceSpeed -= 0.1f;
        print("frequence = " + f_FrequenceSpeed.ToString());
    }

    public int Get_NewSpawnPos()
    {
        int i_newSpawnPos = i_LastSpawnPos;
        while (i_newSpawnPos == i_LastSpawnPos)
        {
            i_newSpawnPos = Random.Range(0, t_Positions.Length);
        }
        i_LastSpawnPos = i_newSpawnPos;
        return i_newSpawnPos;
    }

}

using UnityEngine;
using System.Collections;

public class SpawnUnit : MonoBehaviour
{
    public GameObject[] SpawnList = new GameObject[10]; // спавн лист
    public GameObject[] AttackUnit = new GameObject[3]; //массив юнитов на поле
    public GameObject[] PosUnit = new GameObject[3]; // позиция юнита

    public GameObject spawnUnit; // юнит который появляется
   
	void Start ()
    {
        Spawn();
    }
	

	void Update ()
    {
	}

    void Spawn()
    {
        for (int i = 0; i < SpawnList.Length; i++)
        {
            for (int j = 0; j < AttackUnit.Length; j++)
            {
                if (AttackUnit[j] == null)
                {
                    GameObject EnemyUnit = (GameObject)Instantiate(SpawnList[i], PosUnit[j].transform.position, PosUnit[j].transform.rotation);
                    SpawnList[i] = null;
                    AttackUnit[j] = EnemyUnit;
                    break;
                }
            }
        }
    }
}

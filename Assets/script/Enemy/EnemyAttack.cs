using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
    public bool attack; // юнит атакует
    public GameObject player;
    public int attackDamege; // Урон
    public float AttackSpead; // скорость атаки
    public float Timer;

    public GameObject shell; //снаряд
    public Transform StartPos; //позиция появления снаряда

    void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	

	void Update () {
        if (attack)
        {
            Timer += Time.deltaTime;
            if (Timer >= AttackSpead)
            {
               // Attack();
            }
        }
	
	}

    public void Attack()
    {
        if (player.GetComponent<PlayerStats>().CurHp > 0)
        {
            Timer = 0;
            GameObject bul = (GameObject)Instantiate(shell, StartPos.transform.position, transform.rotation);
            bul.GetComponent<Shell>().target = player.transform;
            bul.GetComponent<Shell>().damege = attackDamege;
            bul.GetComponent<Shell>().targetAttack = player;
        }
    }
}

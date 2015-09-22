using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    public bool attack; // юнит атакует
    public GameObject enemy;
    public PlayerStats PS;
    public int attackDamege; // Урон
    public float AttackSpead; // скорость атаки
    public float Timer;

    public GameObject shell; //снаряд
    public Transform StartPos; //позиция появления снаряда

    void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Player");
        PS = enemy.GetComponent<PlayerStats>();
    }


    void Update()
    {
        if (attack)
        {
            Timer += Time.deltaTime;
            if (Timer >= AttackSpead)
            {
                Attack();
            }
        }

    }

    void Attack()
    {
        Timer = 0;
        GameObject bul = (GameObject)Instantiate(shell, StartPos.transform.position, transform.rotation);
        bul.GetComponent<Shell>().target = enemy.transform;
        bul.GetComponent<Shell>().damege = attackDamege;
    }
}

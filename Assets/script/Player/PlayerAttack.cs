using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    public bool attack; // юнит атакует
    public GameObject target; // цель атаки
    public int attackDamege; // Урон
    public float AttackSpead; // скорость атаки
    public float Timer;

    public SpawnUnit SU;

    public GameObject shell; //снаряд
    public Transform StartPos; //позиция появления снаряда

    void Start()
    {
     //   SU = GameObject.Find("StartBattle").GetComponent<SpawnUnit>();
      //  target = SU.AttackUnit[1];
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
        bul.GetComponent<Shell>().target = target.transform;
        bul.GetComponent<Shell>().damege = attackDamege;
        bul.GetComponent<Shell>().targetAttack = target;
    }
}

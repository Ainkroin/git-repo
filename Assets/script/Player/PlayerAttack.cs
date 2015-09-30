using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    public bool redoublement; // повторная атака
    public bool attack; // юнит атакует
    public GameObject target; // цель атаки
    public float attackDamege; // Урон
    public float AttackSpead; // скорость атаки
    public float Timer;

    public SpawnUnit SU;

    public GameObject shell; //снаряд
    public Transform StartPos; //позиция появления снаряда

    void Start()
    {
        redoublement = false;
        SU = GameObject.Find("StartBattle").GetComponent<SpawnUnit>();
        target = SU.AttackUnit[0];
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (target == null)
        {
            attack = false;
            for (int i = 0; i < SU.AttackUnit.Length; i++)
                if (SU.AttackUnit[i] != null)
                {
                    target = SU.AttackUnit[i];
                    attack = true;
                    SU.AttackUnit[i].GetComponent<TargetSelection>().TargetSelect();
                    break;
                }
        }
        if (attack)
        {
            Timer += Time.deltaTime;
            if (Timer >= AttackSpead)
            {
                anim.SetBool("Attack", true);
                
            }        
        }

    }

    public void Attack()
    {
       
        Timer = 0;
        GameObject bul = (GameObject)Instantiate(shell, StartPos.transform.position, transform.rotation);
        bul.GetComponent<Shell>().target = target.transform;
        bul.GetComponent<Shell>().damege = attackDamege;
        bul.GetComponent<Shell>().targetAttack = target;
        anim.SetBool("Attack", false);
        
        if (!redoublement)
        {
            anim.SetBool("BlendAttack", true);
        }
        else
        {
            anim.SetBool("BlendAttack", false);
        }
        redoublement = !redoublement;
    }

}

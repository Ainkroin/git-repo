using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour
{
    Animator anim;

    public int MaxHp; // максимальное здоровье
    public int CurHp; // текущее здоровье

    void Start()
    {
        CurHp = MaxHp;
        anim = GetComponent<Animator>();
    }


    void Update()
    {


    }

    public void TakeDamage(int amount)
    {
        if (CurHp > 0)
        {
            CurHp -= amount;
        }
        if (CurHp <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        anim.SetTrigger("IsDead");
    }
}

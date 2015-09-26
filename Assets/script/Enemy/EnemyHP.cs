using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour
{
    Animator anim;

    public int MaxHp; // максимальное здоровье
    public int CurHp; // текущее здоровье

    public EnemyAttack EA;
    public SpawnUnit SU;

    void Start()
    {
        SU = GameObject.Find("StartBattle").GetComponent<SpawnUnit>();
        EA = this.gameObject.GetComponent<EnemyAttack>();
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
        EA.attack = false;
        anim.SetTrigger("IsDead");
        Destroy(gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    Animator anim;

    public int MaxHp; // максимальное здоровье
    public int CurHp; // текущее здоровье
    public int MaxConcentration; //максимальная концентрация
    public int CurConcentration; //текущая концентрация
    public int MaxRage; // максимальная ярость
    public int CurRage; // текущая ярость

    public PlayerAttack PA;
    public TargetSelection TS;

    void Start ()
    {

        PA = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
        CurHp = MaxHp;
        CurConcentration = MaxConcentration;
        CurRage = MaxRage;

        anim = GetComponent<Animator>();
    }
	
	void Update ()
    {
      //  MainAttack();
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
        PA.attack = false;
    }
}

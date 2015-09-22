using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    Animator anim;

    public int MaxHp; // максимальное здоровье
    public int CurHp; // текущее здоровье
    public int MaxConcentration; //максимальная концентрация
    public int CurConcentration; //текущая концентрация
    public int MaxRage; // максимальная ярость
    public int CurRage; // текущая ярость

    public bool attack; // находится в состоянии атаки

    void Start () {
        CurHp = MaxHp;
        CurConcentration = MaxConcentration;
        CurRage = MaxRage;

        anim = GetComponent<Animator>();
	}
	
	void Update () {
        MainAttack();
    }

    void MainAttack() {
        if (attack)
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }

    public void TakeDamage(int amount) {
        if (CurHp > 0)
        {
            CurHp -= amount;
        }
        if (CurHp <= 0)
        {
            Dead();
        }
    }

    void Dead() {
        anim.SetTrigger("IsDead");
    }
}

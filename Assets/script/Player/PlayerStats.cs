using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    Animator anim;

    public int MaxHp; // максимальное здоровье
    public int CurHp; // текущее здоровье
    public int MaxConcentration; //максимальная концентрация
    public float CurConcentration; //текущая концентрация
    public int MaxRage; // максимальная ярость
    public int CurRage; // текущая ярость
    public float ShildProtection; // модификатор защиты

    public Slider Rage; // бар ярости
    public Slider Concentration; // бар концентрации

    public Text RageText; // счетчик ярости
    public Text ConcentrationText; // счетчик концентрации

    public bool ShildActiv; // Щит активен

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
        if (ShildActiv)
        {
            ActivationShield();      
        }
        if (!ShildActiv)
        {
            RegenShild();
        }

        Concentration.value = CurConcentration / MaxConcentration * 100;
        ConcentrationText.text = ((int)CurConcentration).ToString();
    }

    public void TakeDamage(float amount)
    {
        if (CurHp > 0)
        {
            if (ShildActiv)
            {
                CurHp -= (int)(amount * ShildProtection);
            }
            else
            {
                CurHp -= (int)amount;
            }
        }

        if (CurHp <= 0)
        {
            Dead();
        }
    }

    //смерть
    void Dead()
    {
        anim.SetTrigger("IsDead");
        PA.attack = false;
    }

    // работа щита
    void ActivationShield()
    {
        float a = 10; // трата энергии на щит       
        if (CurConcentration > CurConcentration - a * Time.deltaTime && CurConcentration - a * Time.deltaTime > 0)
        {
            PA.Timer = 0;
            CurConcentration -= a * Time.deltaTime;
        }
        else
        {
            PA.attack = true;
            ShildActiv = false;
            anim.SetBool("shield", false);
        }     

    }

    // Регенерация щита
    void RegenShild()
    {
        if (CurConcentration < MaxConcentration)
        {
            CurConcentration = CurConcentration + 5.0f * Time.deltaTime;
        }
        else
        { 
            CurConcentration = MaxConcentration;
        }

    }

}

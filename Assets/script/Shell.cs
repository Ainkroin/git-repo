using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour
{
    public GameObject targetAttack; // цель атаки. Передается из player/enemyAttack
    public Transform target;
    public int damege; //урон от взрыва
    public int moveSpeed = 1; // скорость снаряда

    PlayerStats HpPlayer; // нр игрока
    EnemyHP HpEnemy; // нр врага

    void Start()
    {
  
    } 

    void Update ()
    {
        if (target != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 5 * Time.deltaTime);
            if (Vector3.Distance(target.position, transform.position) >= 0.5)
            {
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
            else
            {
                if (target.tag == "Player")
                {
                    HpPlayer = target.GetComponent<PlayerStats>();
                    Destroy(gameObject);
                    HpPlayer.TakeDamage(damege);
                }
                else
                {
                    HpEnemy = target.GetComponent<EnemyHP>();
                    Destroy(gameObject);
                    HpEnemy.TakeDamage(damege);
                }
            }
        }
        if (target == null)
        {
            Destroy(gameObject);
        }
	}
}

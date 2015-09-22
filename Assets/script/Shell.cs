using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    public int damege; //урон от взрыва
    public int moveSpeed = 1; // скорость снаряда

    PlayerStats PlayerHp;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerHp = player.GetComponent<PlayerStats>();
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
                Destroy(gameObject);
                PlayerHp.TakeDamage(damege);
            }
        }
	}
}

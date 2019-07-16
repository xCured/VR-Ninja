using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public static int BulletDmg = 15;
    public static int RocketDmg = 25;

    //public GameObject body;
    //public GameObject head;
    public static int CurrentsHealth;

    // Start is called before the first frame update
    void Start()
    {
         //HealthSystem.currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(HealthSystem.currentHealth);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Players")
        {

            HealthSystem.currentHealth = HealthSystem.currentHealth - BulletDmg;


        }
    }
}

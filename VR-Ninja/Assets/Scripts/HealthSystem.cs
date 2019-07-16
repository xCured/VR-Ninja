using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class HealthSystem : MonoBehaviour
{

    public int Startinghealth = 100;
    public static int currentHealth;



    //use -4 p/s
    // not used for 1 second recover 10 p/s


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = Startinghealth;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}

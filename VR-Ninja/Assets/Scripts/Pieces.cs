using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{

    public float Timeout = 10;
    public float Timeout2 = 1;

    private void Start()
    {
        GameManager.Instance.hullManager.HullPieces.Add(this.gameObject);
        this.gameObject.AddComponent<Rigidbody>();
        this.gameObject.AddComponent<BoxCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if ((Timeout2 -= Time.deltaTime) <= 0f)
        {
            this.gameObject.tag = "Box";
            // GameManager.Instance.hullManager.HullPieces.Remove(this.gameObject);
            // Destroy(this.gameObject);
        }



        if ((Timeout -= Time.deltaTime) <= 0f)
        {
            GameManager.Instance.hullManager.HullPieces.Remove(this.gameObject);
            Destroy(this.gameObject);
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ShurikenThrows : MonoBehaviour
{
    public float speed = 1f;
    // public GameObject Shuriken;
    public bool IsSticky = false;

    [SerializeField]
    // public GameObject[] DisableComponents;
    public VRTK_InteractableObject Object;
    public GameObject Shuriken;
    public Rigidbody RBShuriken;


    void OnCollisionEnter(Collision Coll)
    {
       
            if (Coll.gameObject.tag == "Box")
            {
                this.transform.parent = Coll.transform;
                Rigidbody ShurikenRigid = this.GetComponent<Rigidbody>();
                ShurikenRigid.velocity = Vector3.zero;
                ShurikenRigid.isKinematic = true;
                IsSticky = true;
                WaitPls();
                DisableStuff();
            }
        
    }

    IEnumerator WaitPls()
    {
       yield return new WaitForSeconds(2);
        Destroy(this.gameObject);

    }


    // Start is called before the first frame update
    void Setup()
    {
      Object = GetComponent<VRTK_InteractableObject>();       
       
    }
    private void Start()
    {
        RBShuriken = GetComponent<Rigidbody>();
    }

    void DisableStuff()
    {
        if (IsSticky == true)
        {
            Object.enabled = false;
            Destroy(gameObject, 10f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(RBShuriken.velocity.magnitude);
        if (RBShuriken.velocity.magnitude > 2)
        {
            transform.Rotate(Vector3.right * speed / Time.deltaTime);
        }
           
    }

}
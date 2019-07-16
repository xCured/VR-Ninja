using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Backpack : MonoBehaviour
{
    public GameObject spawnObject;
    public bool IsBoolOn;



    public void OnTriggerStay(Collider Coll)
    {
        VRTK_InteractGrab grabbingobject = (Coll.gameObject.GetComponent<VRTK_InteractGrab>() ? Coll.gameObject.GetComponent<VRTK_InteractGrab>() : Coll.gameObject.GetComponentInParent<VRTK_InteractGrab>());

        if(CanGrab(grabbingobject))
        {
            GameObject Spawned = Instantiate(spawnObject);
            grabbingobject.GetComponent<VRTK_InteractTouch>().ForceTouch(Spawned);
            grabbingobject.AttemptGrab();

            //if (IsBoolOn == true)
            //{
            //    Destroy(Spawned, 2f);
            //}
            
        }

    }

    public void Update()
    {
        //ShurikenThrows ShurikensBool = spawnObject.GetComponent<ShurikenThrows>();
        //ShurikensBool.IsSticky = IsBoolOn;
        //Debug.Log(IsBoolOn);
    }


    private bool CanGrab(VRTK_InteractGrab grabbingobject)
    {
        return (grabbingobject && grabbingobject.GetGrabbedObject() == null && grabbingobject.GetComponent<VRTK_ControllerEvents>().gripPressed);
    }
}

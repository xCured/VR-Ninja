using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Slicerz : MonoBehaviour
{

    public GameObject objectToSlice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public SlicedHull Slice(Vector3 planeWorldPosition, Vector3 planeWorldDirection)
    {
        return objectToSlice.Slice(this.transform.position, this.transform.forward);
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision Coll)
    {
        if(Coll.gameObject.tag == "Box" || Coll.gameObject.tag == "Shuriken")
        {
            objectToSlice = Coll.gameObject;
            objectToSlice.SliceInstantiate(this.transform.position, this.transform.forward);
            Destroy(objectToSlice);

        }

        //if(Coll.gameObject.tag == "Untagged")
        //{
        //    objectToSlice = Coll.gameObject;
        //    objectToSlice.SliceInstantiate(this.transform.position, this.transform.forward);
        //    Destroy(objectToSlice);

        //}
            
    }
}

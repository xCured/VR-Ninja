using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BeizerFollow : MonoBehaviour
{
    public GameObject curveObj;
    public List<Transform> curvePoints = new List<Transform>();
    public List<Vector3> cachedPointsPos = new List<Vector3>(); //saves above values 

    public Vector3 target; //Current lerp target
    public int targetIndex = 0;

    public float lerpSpeed = 35f;

    public bool allowMovement = false;

    public GameObject playerToMove;

    public bool validity = true;

    void Start()
    {
        Invoke("LateStart", 0.5f);
    }

    public void Update()
    {
        if (allowMovement)
        {
            Movement();
        }
    }

    public void LateStart()
    {
        curveObj = Resources.FindObjectsOfTypeAll<VRTK_CurveGenerator>()[0].gameObject;
    }

    public void IsValid()
    {
        validity = true;
    }

    public void IsInvalid()
    {
        validity = false;
    }

    public void StartBeizerMove()
    {
        if (validity)
        {
            GetPoints();
            allowMovement = true;
        }
    }

    public void GetPoints()
    {
        curvePoints.Clear();
        if (curvePoints.Count == 0)
        {
            for (int i = 0; i < curveObj.transform.childCount; i++)
            {
                curvePoints.Add(curveObj.transform.GetChild(i));
            }
        }

        //Cache
        cachedPointsPos.Clear();
        foreach (Transform curv in curvePoints)
        {
            cachedPointsPos.Add(curv.position);
        }
    }

    void Movement()
    {
        if (target == null)
        {
            GetNextWayPoint();
        }

        Vector3 dir = target - playerToMove.transform.position;
        playerToMove.transform.Translate(dir * lerpSpeed * Time.deltaTime, Space.World);
        if (Vector3.Distance(playerToMove.transform.position, target) <= 0.07f)
        {
            GetNextWayPoint();
        }
    }
    void GetNextWayPoint()
    {
        Debug.Log("NEXT TORGAET");
        if (targetIndex >= cachedPointsPos.Count - 1)
        {
            Debug.Log(targetIndex);
            ReachedDestination();
            targetIndex = 0;
        }
        else
        {
            targetIndex++;
        }
        target = cachedPointsPos[targetIndex];
    }

    public void ReachedDestination()
    {

        Debug.Log("reached");
        allowMovement = false;

        GetPoints();
    }

}

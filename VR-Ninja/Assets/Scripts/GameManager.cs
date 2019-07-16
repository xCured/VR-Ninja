using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    [HideInInspector]
    //public BulletManager bulletManager;
    public HullManager hullManager;

    private void Start()
    {
       // bulletManager = GetComponent<BulletManager>();
        hullManager = GetComponent<HullManager>();
    }

}

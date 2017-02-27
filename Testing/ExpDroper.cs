using UnityEngine;
using System.Collections;

public class ExpDroper : MonoBehaviour {

    //public GameObject self;
    GameEntity entity;
    private int exp_drop;



    public int Exp_drop
    {
        get{return exp_drop;}
        set{exp_drop = value;}
    }

    void Awake()
    {
        entity = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameEntity>();
    }

    void Start()
    {
        Destroy(gameObject, 120);
    }

    void OnTriggerEnter()
    {
        entity.EntityLevel.ModifyExp(Exp_drop);
        Destroy(gameObject);
    }
}

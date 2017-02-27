using UnityEngine;
using System.Collections;

public class EnemyVitals : MonoBehaviour {

    [SerializeField]private int curHP;
    private int maxHP = 100;

    public int CurHP
    {
        get
        {
            return curHP;
        }

        set
        {
            curHP = value;
        }
    }

    // Use this for initialization
    void Start () {
        CurHP = maxHP;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (CurHP <= 0)
        {
            Destroy(this.gameObject);
        }
	
	}

    public void AdjHP(int demage)
    {
        CurHP -= demage;
    }


}

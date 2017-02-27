using UnityEngine;
using System.Collections;

public class FireRain : MonoBehaviour {
    public GameObject[] startingPoint;
    public GameObject spell;

	// Use this for initialization
	void Start () {
        GameObject temp;
        for (int i = 0; i < startingPoint.Length; i++)
        {
            temp = (GameObject)Instantiate(spell, startingPoint[i].transform.position, startingPoint[i].transform.rotation);
            temp.GetComponent<EffectSettings>().IsHomingMove = true;
            temp.GetComponent<EffectSettings>().Target = GameObject.FindGameObjectWithTag("Player");
            Destroy(temp, 10);
        }
        

    }

    // Update is called once per frame
    void Update () {
	
	}
}

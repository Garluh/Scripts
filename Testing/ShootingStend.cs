using UnityEngine;
using System.Collections;

public class ShootingStend : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "DamageSpell")
        {
            //    Debug.Log("Hit by " + other.gameObject.GetComponent<SpellDatabase>().itemName +" and deal " + other.gameObject.GetComponent<SpellDatabase>().Damage + " " +other.gameObject.GetComponent<SpellDatabase>().type + " Damage ");
            Debug.Log("GHIT");
            

        }
    }
}

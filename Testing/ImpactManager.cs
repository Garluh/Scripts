using UnityEngine;
using System.Collections;

public class ImpactManager : MonoBehaviour {
    public GameObject self;

    BaseCharacter bc;

	// Use this for initialization
	void Start () {
        bc = GameObject.FindGameObjectWithTag("GameManager").GetComponent<BaseCharacter>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Debug.Log("Hit Self");
            //other.gameObject.GetComponent<EnemyVitals>().AdjHP(10);
            //Debug.Log(other.gameObject.GetComponent<EnemyVitals>().CurHP);
        }
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit Player");
            //Debug.Log((Random.Range(self.GetComponent<EnemyManager>().MinDamage(), self.GetComponent<EnemyManager>().MaxDamage())));
            //bc.DamageTake((int)(Random.Range(self.GetComponent<EnemyManager>().MinDamage(), self.GetComponent<EnemyManager>().MaxDamage())));
        }

        if (other.gameObject.tag == "DamageSpell")
        {
            Debug.Log("Hit by " + other.gameObject.GetComponent<SpellDatabase>().itemName + " and deal " + other.gameObject.GetComponent<SpellDatabase>().Damage + " " + other.gameObject.GetComponent<SpellDatabase>().type + " Damage ");
            bc.DamageTake((int)other.gameObject.GetComponent<SpellDatabase>().Damage);


        }
    }
}

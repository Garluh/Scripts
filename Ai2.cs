using UnityEngine;
using System.Collections;

public class Ai2 : MonoBehaviour {

    public Transform target;
    public Rigidbody bullet;
    public Transform barell;

    // Use this for initialization
    void Start() {
        StartCoroutine(myCor());
    }

    // Update is called once per frame
    void Update() {

        Vector3 Pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(Pos);
        transform.rotation = rotation;



    }


    IEnumerator myCor()
    {
        yield return new WaitForSeconds(2f);
        Rigidbody bulletInstance;
        bulletInstance = Instantiate(bullet, barell.position, barell.rotation) as Rigidbody;
        bulletInstance.AddForce(transform.forward * 100, ForceMode.Impulse);
        StartCoroutine(Timer());

    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(myCor());
    }
}

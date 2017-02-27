using UnityEngine;
using System.Collections;

public class Ai3 : MonoBehaviour {
    public Transform startPoint;
    public Transform target;
    public Transform SpellHand;
    public GameObject FireBall;
    NavMeshAgent agent;
    Animator anim;
    //SphereCollider call;
    int cnt = 0;


    FOV fov;

    float fireRate = 2;
    float nexFire = 2;

    Vector3 direction;
    float angel;

    [Header("Seen Varibale")]
    [SerializeField]
    float seenAngel = 30;
    [SerializeField]
    float chaseDistance = 21;
    [SerializeField]
    float hearRadius = 20;

    // Use this for initialization
    void Start () {
        
        fov = GetComponent<FOV>();
        anim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();


    }
	
	// Update is called once per frame
	void Update ()
    {
        SennTraget();
        if (target != null)
        {
            fov.viewAngel = 360;
            direction = target.position - this.transform.position;

            if (Vector3.Distance(target.position, this.transform.position) < chaseDistance)
            {
                direction.y = 0;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
                anim.SetBool("Idle", false);
                agent.SetDestination(target.position);
                if (direction.magnitude > 5)
                {
                    anim.SetBool("isWalking", true);
                    anim.SetBool("Attack1H", false);
                }
                else if(direction.magnitude < 5)
                {

                    anim.SetBool("isWalking", false);
                    anim.SetBool("Attack1H", true);
                    //CastFireBall();
                }
            }
        }
        else if(direction.magnitude > 20)
        {
            if (!fov.isAdded)
            {
                agent.ResetPath();
                agent.SetDestination(startPoint.position);
                fov.viewRadius = 20;
                fov.viewAngel = 60;
                anim.SetBool("Idle", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("Attack1H", false);
            }
            
            
        }
    }

    void SennTraget()
    {
        if (fov.isAdded)
        {
            target = fov.visibleTragets[0];
        }
        else
        {
            target = null;
        }
            
    }


    //void OnTriggerEnter(Collider other)
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "DamageSpell")
        {
            Debug.Log("Me hit");
            //target = GameObject.FindGameObjectWithTag("Player").transform;
            //cnt++;
            //if (cnt == 2)
            //{
            //    anim.SetBool("Death", true);
            //}

        }
    }


    void CastFireBall()
    {
        if (Time.time > nexFire)
        {
            GameObject spellInstance;
            FireBall.GetComponent<EffectSettings>().Target = target.gameObject;
            nexFire = Time.time + nexFire;
            spellInstance = Instantiate(FireBall, SpellHand.position, SpellHand.rotation) as GameObject;
        }
    }

    IEnumerator myCor()
    {
        GameObject spellInstance;
        yield return new WaitForSeconds(2f);
        FireBall.GetComponent<EffectSettings>().Target = target.gameObject;
        spellInstance = Instantiate(FireBall, SpellHand.position, SpellHand.rotation) as GameObject;
        StartCoroutine(Timer());

    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(myCor());
    }

}

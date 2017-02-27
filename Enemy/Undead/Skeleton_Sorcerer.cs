using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FOV))]
[RequireComponent(typeof(NavMeshAgent))]
public class Skeleton_Sorcerer : MonoBehaviour {

    // Use this for initialization
    public AnimationClip idle;
    public AnimationClip walk_clip;
    public AnimationClip cast_spell_clip;

    public Transform startPoint;
    public Transform target;
    public Transform SpellHand;
    public GameObject FireBall;
    EnemyManager e_manager;

    float fightDistance = 10;
    float chaseDistance = 40;

    Vector3 direction;
    float fireRate = 1;
    float nexFire = 1;
    float distance;
    Animation anim;



    NavMeshAgent agent;
    //Animator anim;
    FOV fov;

    void Start()
    {
        anim = GetComponent<Animation>();
        //anim = GetComponent<Animator>();
        fov = GetComponent<FOV>();
        agent = GetComponent<NavMeshAgent>();
        e_manager = GetComponent<EnemyManager>();
        anim.CrossFade(idle.name);

    }

    void Update()
    {

        SennTraget();
        if (target != null)
        {
            fov.viewAngel = 360;
            distance = Vector3.Distance(target.position, this.transform.position);
            direction = target.position - this.transform.position;
            if (distance < chaseDistance)
            {

                direction.y = 0;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
               // anim.SetBool("Idle", false);
                agent.SetDestination(target.position);
                if (distance > 21)
                {
                    //this.transform.Translate(0, 0, 0.05f);
                    //   anim.SetBool("isWalking", true);
                    //   anim.SetBool("CastSpell", false);
                    anim.CrossFade(walk_clip.name);
                    Debug.Log("Walk");
                 
                }
                else if (distance < 21 && target !=null)
                {
                    agent.ResetPath();
                    //agent.SetDestination(startPosition.position);
                    //   anim.SetBool("isWalking", false);
                    //  anim.SetBool("CastSpell", true);
                    //CastSpell();
                    anim.CrossFade(cast_spell_clip.name);
                }
            }
        }
        else if (distance > 30)
        {
            if (!fov.isAdded)
            {
                agent.ResetPath();
                agent.SetDestination(startPoint.position);
                fov.viewRadius = 20;
                fov.viewAngel = 60;
                anim.CrossFade(idle.name);
                //     anim.SetBool("Idle", true);
                //    anim.SetBool("isWalking", false);
                //  anim.SetBool("CastSpell", false);

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
            anim.CrossFade(idle.name);
        }

    }

    void CastSpell()
    {

      //  if (Time.time > nexFire)
      //  {
            Debug.Log("CAST!!!");
            if (target != null)
            {
                GameObject spellInstance;
                FireBall.GetComponent<EffectSettings>().Target = target.gameObject;
                FireBall.GetComponent<EffectSettings>().MoveSpeed = 20f;
                 nexFire = Time.time + nexFire;

                spellInstance = Instantiate(FireBall, SpellHand.position, SpellHand.rotation) as GameObject;
                spellInstance.GetComponent<SpellDatabase>().Damage = this.GetComponent<EnemyManager>().spellDamage;
                Destroy(spellInstance, 5f);
            }
       // }
    }

    private void OnCollisionEnter(Collision other)
    {
    }
}

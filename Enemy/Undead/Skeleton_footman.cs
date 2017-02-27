using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FOV))]
[RequireComponent(typeof(NavMeshAgent))]
public class Skeleton_footman : MonoBehaviour
{

    [SerializeField]
    // Use this for initialization
    public AnimationClip idle;
    public AnimationClip walk_clip;
    public AnimationClip[] attack_type;
    public AnimationClip death;

    public Transform startPoint;
    public Transform target;
    EnemyManager e_manager;

    float fightDistance = 2;
    float chaseDistance = 40;

    Vector3 direction;
    float fireRate = 1;
    float nexFire = 1;
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
        if (target !=null)
        {
            MoveTo(target.transform.position);
        }
        else if (target == null)
        {
            MoveToHome(startPoint.transform.position);
        }

    }

    void MoveTo(Vector3 target)
    {
            fov.viewAngel = 360;
            float distance = Vector3.Distance(target, this.transform.position);
            direction = target - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            agent.SetDestination(target);
            anim.CrossFade(walk_clip.name);
            if (distance < 2.1f && target != null)
            {
                Attack();
            }
    }

    void MoveToHome(Vector3 target)
    {
        fov.viewAngel = 44;
        float distance = Vector3.Distance(target, this.transform.position);
        direction = target - this.transform.position;
        direction.y = 0;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
        agent.SetDestination(target);
        anim.CrossFade(walk_clip.name);
        if (distance < 2.1f && target == null)
        {
            agent.ResetPath();
            anim.CrossFade(idle.name);
        }
    }

    void Attack()
    {
        anim.CrossFade(attack_type[Random.Range(0, attack_type.Length)].name);
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
            //_state = State.Retreat;
            //agent.SetDestination(startPoint.transform.position);
            //anim.CrossFade(idle.name);
        }

    }


    private void OnCollisionEnter(Collision other)
    {
    }
}

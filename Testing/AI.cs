using UnityEngine;
using System.Collections;


[RequireComponent(typeof(FOV))]
[RequireComponent(typeof(NavMeshAgent))]
public class AI : MonoBehaviour {

    public Transform startPoint;
    public Transform target;
    public Transform SpellHand;
    public GameObject FireBall;
    EnemyManager e_manager;

    float fightDistance;
    float chaseDistance;

    Vector3 direction;
    float fireRate = 1;
    float nexFire = 1;


    NavMeshAgent agent;
    Animator anim;
    FOV fov;

    void Start()
    {
        anim = GetComponent<Animator>();
        fov = GetComponent<FOV>();
        agent = GetComponent<NavMeshAgent>();
        e_manager = GetComponent<EnemyManager>();

        switch (e_manager.AttackType)
        {
            case EnemyMobAttackType.Unknown:
                break;
            case EnemyMobAttackType.Range:
                fightDistance = 10;
                chaseDistance = 21;
                break;
            case EnemyMobAttackType.CloseCombat:
                fightDistance = 2;
                chaseDistance = 21;
                break;
            case EnemyMobAttackType.Mage:
                fightDistance = 18;
                chaseDistance = 21;
                break;
        }

    }

    void Update()
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
                    //this.transform.Translate(0, 0, 0.05f);
                    anim.SetBool("isWalking", true);
                    if (e_manager.AttackType == EnemyMobAttackType.CloseCombat)
                    {
                        anim.SetBool("Fight", false);
                    }
                    else if (e_manager.AttackType == EnemyMobAttackType.Mage)
                    {
                        anim.SetBool("Attack1H", false);
                    }
                }
                else if (Vector3.Distance(target.position, this.transform.position) < fightDistance)
                {
                    agent.ResetPath();
                    //agent.SetDestination(startPosition.position);
                    anim.SetBool("isWalking", false);
                    if (e_manager.AttackType == EnemyMobAttackType.CloseCombat)
                    {
                        anim.SetBool("Fight", true);
                    }
                    else if (e_manager.AttackType == EnemyMobAttackType.Mage)
                    {
                        anim.SetBool("Attack1H", true);
                        CastSpell();
                    }
                    
                    
                }
            }
        }
        else if (direction.magnitude > 20)
        {
            if (!fov.isAdded)
            {
                agent.ResetPath();
                agent.SetDestination(startPoint.position);
                fov.viewRadius = 20;
                fov.viewAngel = 60;
                anim.SetBool("Idle", true);
                anim.SetBool("isWalking", false);
                if (e_manager.AttackType == EnemyMobAttackType.CloseCombat)
                {
                    anim.SetBool("Fight", false);
                }
                else if (e_manager.AttackType == EnemyMobAttackType.Mage)
                {
                    anim.SetBool("Attack1H", false);
                }
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

    void CastSpell()
    {
        
        if (Time.time > nexFire)
        {
            Debug.Log("CAST!!!");
            GameObject spellInstance;
            FireBall.GetComponent<EffectSettings>().Target = target.gameObject;
            nexFire = Time.time + nexFire;

            spellInstance = Instantiate(FireBall, SpellHand.position, SpellHand.rotation) as GameObject;
            spellInstance.GetComponent<SpellDatabase>().Damage = this.GetComponent<EnemyManager>().spellDamage;
            Destroy(spellInstance, 5f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
    }


}

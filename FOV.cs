using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FOV : MonoBehaviour {
    public float viewRadius;
    [Range(0,360)]
    public float viewAngel;
    public LayerMask targetMask;
    public LayerMask obsticleMask;
    public bool isAdded = false;

    public List<Transform> visibleTragets = new List<Transform>();

    void Start()
    {
        StartCoroutine("FindTargetsWithDealy", 1.0f);
    }

    IEnumerator FindTargetsWithDealy(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }


    void FindVisibleTargets()
    {
        visibleTragets.Clear();
        isAdded = false;
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward,dirToTarget) < viewAngel /2 )
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget,distToTarget,obsticleMask))
                {
                    isAdded = true;
                    visibleTragets.Add(target);
                }
            }
        }
    }

    public Vector3 DirFromAngel(float angelInDegrees, bool angelIsGlobal)
    {
        if (!angelIsGlobal)
        {
            angelInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angelInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angelInDegrees * Mathf.Deg2Rad));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxRugbier : MonoBehaviour
{
    [SerializeField]
    public Animator animator;
    [SerializeField]
    private string boolParameterName = "TargetInRange";
    public List<Transform> targetsInRange;
    private Transform      closestTarget;
    [SerializeField]
    private GameObject projectilePreafab;
    [SerializeField]
    private Transform shootingPoint;


    private void Awake()
    {
        targetsInRange = new List<Transform>();
    }


    void Update()
    {
        if (targetsInRange.Count > 0)
        {
            closestTarget = targetsInRange[0];
            float distanceToCurrentTarget = Vector3.Distance(transform.position, closestTarget.position);
            float distanceToNewTarget;
            for (int i = 0; i < targetsInRange.Count; i++)
            {
                distanceToNewTarget = Vector3.Distance(transform.position, targetsInRange[i].position);
                if (distanceToCurrentTarget > distanceToNewTarget)
                {
                    closestTarget = targetsInRange[i];
                    distanceToCurrentTarget = distanceToNewTarget;
                }
            }

            Vector3 targetPosition = closestTarget.position;
            targetPosition.y = transform.root.position.y;

            transform.root.LookAt(targetPosition);
        }
    }

    public void AttackClosestTarget()
    {
        if (targetsInRange.Count > 0)
        {
            GameObject createdProjectile = Instantiate(projectilePreafab, shootingPoint.position, shootingPoint.rotation);
            createdProjectile.transform.LookAt(closestTarget);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        targetsInRange.Add(other.transform);
        if (targetsInRange.Count == 1)
        {
            animator.SetBool(boolParameterName, true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        targetsInRange.Remove(other.transform);
        if (targetsInRange.Count < 1)
        {
            animator.SetBool(boolParameterName, false);
        }
    }

    private void Dead()
    {

    }






}

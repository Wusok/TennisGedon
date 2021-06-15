using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rugbier : MonoBehaviour
{
    
    
    public float speed;
    public GameObject player;
    public AttackBoxRugbier behaviorRefetence;

    private void Start()
    {
    }

    void Update()
    {
        if (behaviorRefetence.targetsInRange.Count > 0)
        {
            var direction = player.transform.position - transform.position;
            transform.position += direction * speed * Time.deltaTime;
            behaviorRefetence.animator.SetBool("Running", true);
        }
        else
        {
            behaviorRefetence.animator.SetBool("Running", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        float backup = speed;
        if (other.gameObject.tag == "PunchZone")
        {
            behaviorRefetence.animator.SetTrigger("Attack");
            speed = 0;
        }
        else
        {
            behaviorRefetence.animator.SetBool("Attack", false);
            speed = backup;
        }
        speed = backup;
    }

}

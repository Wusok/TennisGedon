using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rugbier : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public AttackBoxRugbier behaviorRefetence;
    private Animator animator;
    private int damp = 2;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 30 && Vector3.Distance(player.transform.position, transform.position) > 3)
        {
            var direction = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, direction, damp * Time.deltaTime);
            //transform.position += direction * speed * Time.deltaTime;
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        float backup = speed;
        if (other.gameObject.tag == "PunchZone")
        {
            animator.SetTrigger("Attack");
            speed = 0;
        }
        else
        {
            animator.SetBool("Attack", false);
            speed = backup;
        }
        speed = backup;
    }

}

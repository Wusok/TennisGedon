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
    private float enemyLife = 3;
    private AudioSource audiosource;
    public AudioClip normalhit;
    public AudioClip icehit;
    public AudioClip explosivehit;
    private bool NotFreezing = true;
    private float FreezeTime = 0;
    private bool CanFrezze = true;
    private float y;
    private float timeToHit = 0;
    private bool CanHit = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        enemyLife = 3;
        y = transform.position.y;
    }

    void Update()
    {
        if(NotFreezing == true)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < 30 && Vector3.Distance(player.transform.position, transform.position) > 3)
            {
                var direction = Quaternion.LookRotation(player.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, direction, damp * Time.deltaTime);
                transform.position += transform.forward * speed * Time.deltaTime;
                transform.position = new Vector3(transform.position.x, y, transform.position.z);
                animator.SetBool("Run", true);
                timeToHit = 0;
                if (CanFrezze == false)
                {
                    CanFrezze = true;
                }
            }
            else
            {
                animator.SetBool("Run", false);
            }
            if(Vector3.Distance(player.transform.position, transform.position) < 3)
            {
                CanHit = true;
                timeToHit += 1 * Time.deltaTime;
                if(timeToHit > 0.5 && CanHit == true)
                {
                    NewPJSMove.Life -= 1;
                    CanHit = false;
                }
            }
        }

        if (NotFreezing == false)
        {
            if (FreezeTime >= 3)
            {
                NotFreezing = true;
                FreezeTime = 0;
                //Rend.material = Normal;
            }
            FreezeTime += 1 * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pelota")
        {
            audiosource.PlayOneShot(normalhit);
            enemyLife += -1;
            Debug.Log(enemyLife);
        }
        if (other.gameObject.tag == "IceBall")
        {
            audiosource.PlayOneShot(icehit);
            //Rend.material = Freeze;
            enemyLife = enemyLife - 0.5f;
            Debug.Log(enemyLife);
            if (CanFrezze == true)
            {
                NotFreezing = false;
            }
        }

        if (other.gameObject.tag == "ExplosiveBall")
        {
            audiosource.PlayOneShot(explosivehit);
            enemyLife = enemyLife - 1.5f;
        }

        if (enemyLife <= 0)
        {
            Destroy(gameObject);
        }


        float backup = speed;
        if (other.gameObject.tag == "PunchZone")
        {
            NewPJSMove.Life -= 1;
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

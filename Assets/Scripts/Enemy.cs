using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int EnemyLife = 3;
    private Transform Player;
    public float ThisEnemy;
    public Material Normal;
    public Material Freeze;
    private Renderer Rend;
    private int damp = 2;
    private float CDR = 0;
    public GameObject EnemyBullet;
    private bool NotFreezing = true;
    private float FreezeTime = 0;
    private bool CanFrezze = true;
    private AudioSource audiosource;
    public AudioClip normalhit;
    public AudioClip icehit;
    public AudioClip explosivehit;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        EnemyLife = 3;
        ThisEnemy = EnemyLife;
        Rend = GetComponent<Renderer>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        
            if (Vector3.Distance(Player.position, transform.position) < 30)
            {
                var rotate = Quaternion.LookRotation(Player.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotate, damp * Time.deltaTime);
                if (CDR >= 2 && NotFreezing == true)
                {
                    GameObject OneBullet = Instantiate(EnemyBullet, transform.position + new Vector3(1, 0.5f, 0), transform.rotation);
                    Destroy(OneBullet, 5f);
                    if (CanFrezze == false)
                    {
                        CanFrezze = true;
                    }
                    CDR = 0;
                }
                CDR += 1 * Time.deltaTime;
            }
            if (NotFreezing == false)
            {
                if (FreezeTime >= 3)
                {
                    NotFreezing = true;
                    FreezeTime = 0;
                    Rend.material = Normal;
                }
                FreezeTime += 1 * Time.deltaTime;
            }
      
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pelota")
        {
            audiosource.PlayOneShot(normalhit);
            ThisEnemy += -2;
            //Debug.Log(ThisEnemy);
        }
        if (other.gameObject.tag == "IceBall")
        {
            audiosource.PlayOneShot(icehit);
            Rend.material = Freeze;
            ThisEnemy += -0.5f;
            if (CanFrezze == true)
            {
                NotFreezing = false;
            }
        }

        if (other.gameObject.tag == "ExplosiveBall")
        {
            audiosource.PlayOneShot(explosivehit);
            ThisEnemy += -1f;
        }

        if (ThisEnemy <= 0)
        {
            Destroy(gameObject);
        }
    }
}

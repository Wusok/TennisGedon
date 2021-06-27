using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform InicioDisp;
    public static bool HaveIceBullet = false;
    public static bool HaveExplosiveBullet = false;
    public static bool HaveBigBullet = false;

    public static bool RapidRacket = false;
    public static bool MeleRacket = false;
    public static bool MultiRacket = false;

    [Header("Shoot")]
    public List<GameObject> YourBullets;
    public static int UsingBullet = 0;
    public static int UsingWeapon = 0;

    private float CDR = 0;

    public AudioClip raqueteo;
    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        CDR = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuManager.CantMove == false)
        {
            if (Input.GetButtonDown("Fire1") && CDR>= 0.5 && UsingBullet == 0)
            {
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, InicioDisp.rotation);
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
            else if (Input.GetButtonDown("Fire1") && CDR >= 1 && UsingBullet == 1)
            {
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, InicioDisp.rotation);
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
            else if (Input.GetButtonDown("Fire1") && CDR >= 0.75 && UsingBullet == 2)
            {
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, InicioDisp.rotation);
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
            else if (Input.GetButtonDown("Fire1") && CDR >= 1 && UsingBullet == 3)
            {
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, InicioDisp.rotation);
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
        }
        CDR += 1 * Time.deltaTime;
    }
}

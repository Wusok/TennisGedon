using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public Transform InicioDisp;
    public static bool HaveIceBullet = false;
    public static bool HaveExplosiveBullet = false;
    public static bool HaveBigBullet = false;

    public static bool RapidRacket = false;
    public static bool MeleRacket = false;
    public static bool MultiRacket = false;

    public GameObject mycamera;
    public GameObject gameToPoint;
    public GameObject aimObject;

    [Header("Shoot")]
    public List<GameObject> YourBullets;
    public static int UsingBullet = 0;
    public static int UsingWeapon = 0;

    private float CDR = 0;

    public AudioClip raqueteo;
    private AudioSource audiosource;

    public static bool activateRapid = false;
    public static bool activateMulti = false;

    public static bool useRapid = false;
    public static bool useMulti = false;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "LVL1")
        {
            HaveIceBullet = false;
            HaveExplosiveBullet = false;
        }
        CDR = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (ControllCamera.cameraOn)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }

            if (activateMulti == true && UIManager.HaveMulti)
            {
                useMulti = true;
                Debug.Log("MultiOn");
            }
            else if(activateMulti == false)
            {
                useMulti = false;
            }
                
            if (activateRapid == true && UIManager.HaveMulti)
            {
                useRapid = true;
                Debug.Log("RapidOn");
            }
            else if (activateRapid == false)
            {
                useRapid = false;
            }

            CDR += 1 * Time.deltaTime;
        }
        
    }

    void Shoot()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(mycamera.transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            aimObject = Instantiate(gameToPoint, hit.point, Quaternion.identity);
        }

        if (useRapid == false && useMulti == false)
        {
            if (CDR >= 0.5 && UsingBullet == 0)
            {
                Debug.Log("Spawn");
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, Quaternion.LookRotation(aimObject.transform.position - mycamera.transform.position));
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
            else if (CDR >= 1.5 && UsingBullet == 1)
            {
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, Quaternion.LookRotation(aimObject.transform.position - mycamera.transform.position));
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
            else if (CDR >= 1 && UsingBullet == 2)
            {
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, Quaternion.LookRotation(aimObject.transform.position - mycamera.transform.position));
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
            else if (CDR >= 1 && UsingBullet == 3)
            {
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, Quaternion.LookRotation(aimObject.transform.position - mycamera.transform.position));
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
        }
        else if (useRapid && useMulti)
        {
            if (CDR >= 0.25 && UsingBullet == 0)
            {
                Debug.Log("Spawn");
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, Quaternion.LookRotation(aimObject.transform.position - mycamera.transform.position));
                GameObject TwoBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position + new Vector3(1, 0, 0), Quaternion.LookRotation(aimObject.transform.position - mycamera.transform.position));
                GameObject ThreeBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position + new Vector3(-1, 0, 0), Quaternion.LookRotation(aimObject.transform.position - mycamera.transform.position));
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
            else if (CDR >= 0.75 && UsingBullet == 1)
            {
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, Quaternion.LookRotation(aimObject.transform.position - mycamera.transform.position));
                GameObject TwoBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position + new Vector3(1, 0, 0), Quaternion.LookRotation(aimObject.transform.position - mycamera.transform.position));
                GameObject ThreeBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position + new Vector3(-1, 0, 0), Quaternion.LookRotation(aimObject.transform.position - mycamera.transform.position));
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
            else if (CDR >= 0.5 && UsingBullet == 2)
            {
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, Quaternion.LookRotation(aimObject.transform.position - mycamera.transform.position));
                GameObject TwoBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position + new Vector3(1, 0, 0), InicioDisp.rotation);
                GameObject ThreeBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position + new Vector3(-1, 0, 0), InicioDisp.rotation);
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
            else if (CDR >= 0.5 && UsingBullet == 3)
            {
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, InicioDisp.rotation);
                GameObject TwoBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position + new Vector3(1, 0, 0), InicioDisp.rotation);
                GameObject ThreeBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position + new Vector3(-1, 0, 0), InicioDisp.rotation);
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
        }
        else if (useMulti)
        {
            if (CDR >= 0.5 && UsingBullet == 0)
            {
                Debug.Log("Spawn");
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, InicioDisp.rotation);
                GameObject TwoBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position + new Vector3(1, 0, 0), InicioDisp.rotation);
                GameObject ThreeBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position + new Vector3(-1, 0, 0), InicioDisp.rotation);
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
            else if (CDR >= 1.5 && UsingBullet == 1)
            {
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, InicioDisp.rotation);
                GameObject TwoBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position + new Vector3(1, 0, 0), InicioDisp.rotation);
                GameObject ThreeBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position + new Vector3(-1, 0, 0), InicioDisp.rotation);
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
            else if (CDR >= 1 && UsingBullet == 2)
            {
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, InicioDisp.rotation);
                GameObject TwoBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position + new Vector3(1, 0, 0), InicioDisp.rotation);
                GameObject ThreeBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position + new Vector3(-1, 0, 0), InicioDisp.rotation);
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
            else if (CDR >= 1 && UsingBullet == 3)
            {
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, InicioDisp.rotation);
                GameObject TwoBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position + new Vector3(1, 0, 0), InicioDisp.rotation);
                GameObject ThreeBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position + new Vector3(-1, 0, 0), InicioDisp.rotation);
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }

        }
        else if (useRapid)
        {
            if (CDR >= 0.25 && UsingBullet == 0)
            {
                Debug.Log("Spawn");
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, InicioDisp.rotation);
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
            else if (CDR >= 0.75 && UsingBullet == 1)
            {
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, InicioDisp.rotation);
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
            else if (CDR >= 0.5 && UsingBullet == 2)
            {
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, InicioDisp.rotation);
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
            else if (CDR >= 0.5 && UsingBullet == 3)
            {
                GameObject OneBullet = Instantiate(YourBullets[UsingBullet], InicioDisp.position, InicioDisp.rotation);
                audiosource.PlayOneShot(raqueteo);
                Destroy(OneBullet, 4f);
                CDR = 0;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBoss : MonoBehaviour
{
    public GameObject player;
    public Vector3 playerlook;
    public float distanciaPlayer;
    public float lineofsite;
    public float dontMoveSite;
    public float life = 100;
    public bool freezing = false;
    public Animator anima;
    public int speed;
    public bool stay = false;
    public bool doHability = true;
    public GameObject areaGH;
    public GameObject particulasGolpe;
    public Image barraVida;
    public Renderer rend;
    public GameObject skins;
    public Material normal;
    public Material freeze;
    public Material dmg;
    private float timerspeed = 0;
    public GameObject particulasCorrer;
    private int habilityToDo;

    void Start()
    {
        rend = skins.GetComponent<Renderer>();
        barraVida.fillAmount = life / 100;
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.fillAmount = life / 100;
        if (freezing == false && life > 0 && stay == false)
        {
            /*timerspeed += 1 * Time.deltaTime;
            if (timerspeed > 3)
            {
                speed = Random.Range(10, 16);
                timerspeed = 0;
            }*/

            if (speed > 11)
                particulasCorrer.gameObject.SetActive(true);
            else
                particulasCorrer.gameObject.SetActive(false);

            playerlook = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
            distanciaPlayer = Vector3.Distance(player.transform.position, transform.position);

            if (distanciaPlayer < lineofsite && distanciaPlayer > dontMoveSite)
            {
                Run();
                transform.LookAt(playerlook);
                transform.position += transform.forward * speed * Time.deltaTime;
                //doHablity = true;
            }
            else if (distanciaPlayer <= dontMoveSite)
            {
                stay = true;
            }

            if(doHability == true)
            {
                doHability = false;
                habilityToDo = Random.Range(0, 3);
            }
            WhatImDoing();
        }
        /*
        if(stay == true && doHablity == true)
        {
            HammerHit();
        }*/
    }

    public void WhatImDoing()
    {
        if (habilityToDo == 0)
        {

        }
        else if (habilityToDo == 1 && distanciaPlayer <= dontMoveSite)
        {
            HammerHit();
            speed = 10;
        }
        else if (habilityToDo == 1 && distanciaPlayer >= dontMoveSite)
        {
            speed = 15;
        }
        else if (habilityToDo == 2)
        {

        }
        else if (habilityToDo == 3)
        {

        }
    }

    public void HammerHit()
    {
        Manos();
        doHability = false;
        StartCoroutine(Hiting());
        StartCoroutine(WaitAnimation());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lineofsite);
        Gizmos.DrawWireSphere(transform.position, dontMoveSite);
    }

    IEnumerator Hiting()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject area = Instantiate(areaGH, new Vector3(transform.position.x, transform.position.y - 4, transform.position.z - 3), transform.rotation);
        GameObject par1 = Instantiate(particulasGolpe, new Vector3(transform.position.x + 0.5f, transform.position.y - 4, transform.position.z + 1), transform.rotation);
        GameObject par2 = Instantiate(particulasGolpe, new Vector3(transform.position.x + 0.5f, transform.position.y - 4, transform.position.z - 1), transform.rotation);
        GameObject par3 = Instantiate(particulasGolpe, new Vector3(transform.position.x - 0.5f, transform.position.y - 4, transform.position.z + 1), transform.rotation);
        GameObject par4 = Instantiate(particulasGolpe, new Vector3(transform.position.x - 0.5f, transform.position.y - 4, transform.position.z - 1), transform.rotation);
        GameObject par5 = Instantiate(particulasGolpe, new Vector3(transform.position.x + 1f, transform.position.y - 4, transform.position.z), transform.rotation);
        GameObject par6 = Instantiate(particulasGolpe, new Vector3(transform.position.x - 1f, transform.position.y - 4, transform.position.z), transform.rotation);
        Destroy(par1, 1f);
        Destroy(par6, 1f);
        Destroy(par3, 1f);
        Destroy(par4, 1f);
        Destroy(par5, 1f);
        Destroy(area, 1f);
        Destroy(par2, 1f);
    }

    IEnumerator WaitAnimation()
    {
        yield return new WaitForSeconds(3);
        Idle();
        stay = false;
        doHability = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pelota")
        {
            if (other.GetComponent<BulletBeheivor>().WhatIsThisBall == 0)
            {
                Debug.Log("1");
                life -= 3;
                rend.material = dmg;
                StartCoroutine(ReturnMaterial());
            }
            else if (other.GetComponent<BulletBeheivor>().WhatIsThisBall == 1)
            {
                Debug.Log("2");
                life -= 1.5f;
                rend.material = freeze;
                StartCoroutine(ReturnMaterialAF());
            }
            else if (other.GetComponent<BulletBeheivor>().WhatIsThisBall == 2)
            {
                Debug.Log("3");
                life -= 2f;
                rend.material = dmg;
                StartCoroutine(ReturnMaterial());
            }
        }

        if (life <= 0)
        {
            anima.SetBool("death", true);
            Death();
        }
    }

    public void Death()
    {
        BoosWin.isDead = true;
        Destroy(gameObject, 3f);
    }

    IEnumerator ReturnMaterialAF()
    {
        Idle();
        particulasCorrer.gameObject.SetActive(false);
        freezing = true;
        yield return new WaitForSeconds(2f);
        freezing = false;
        rend.material = normal;
    }

    IEnumerator ReturnMaterial()
    {
        yield return new WaitForSeconds(0.3f);
        rend.material = normal;
    }

    void Run()
    {
        anima.SetBool("run", true);
        anima.SetBool("manos", false);
        anima.SetBool("idle", false);
        anima.SetBool("takle", false);
    }
    void Idle()
    {
        anima.SetBool("run", false);
        anima.SetBool("manos", false);
        anima.SetBool("idle", true);
        anima.SetBool("takle", false);
    }
    void Manos()
    {
        anima.SetBool("run", false);
        anima.SetBool("manos", true);
        anima.SetBool("idle", false);
        anima.SetBool("takle", false);
    }
    void Patada()
    {
        anima.SetBool("run", false);
        anima.SetBool("manos", false);
        anima.SetBool("idle", false);
        anima.SetBool("takle", true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aguatero : MonoBehaviour
{
    public List<GameObject> allys;
    private float timerHeal = 0;
    private float life = 3;

    private AudioSource audiosource;
    public AudioClip normalhit;
    public AudioClip icehit;
    public AudioClip explosivehit;

    public GameObject player;
    public GameObject skins;
    public Renderer rend;
    public Material normal;
    public Material freeze;
    public Material dmg;
    public Animator anima;
    public Vector3 playerlook;
    public float distanciaPlayer;
    public float lineofsite;
    public bool freezing = false;
    public GameObject puerta;
    private bool isDeath = false;

    public bool printVida = false;
    void Start()
    {
        rend = skins.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(freezing == false && life > 0)
        {
            playerlook = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
            distanciaPlayer = Vector3.Distance(player.transform.position, transform.position);

            if (distanciaPlayer < lineofsite)
            {
                timerHeal += 1 * Time.deltaTime;
                if (timerHeal > 1.5f)
                {
                    for (int i = 0; i < allys.Count; i++)
                    {
                        if (allys[i].GetComponent<QuemadosFull>().life < 5)
                        {
                            allys[i].GetComponent<QuemadosFull>().life++;
                        }
                    }
                    timerHeal = 0;
                }
                transform.LookAt(playerlook);
                anima.SetBool("Support", true);
            }
            else
            {
                anima.SetBool("Support", false);
            }

            
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pelota")
        {
            if (distanciaPlayer > lineofsite)
            {
                lineofsite = lineofsite * 2;
            }

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

        if (other.gameObject.tag == "Explosion")
        {
            life -= 1f;
        }

        if (life <= 0 && isDeath == false)
        {
            isDeath = true;
            anima.SetBool("Death", true);
            Death();
        }
    }

    public void Death()
    {
        puerta.gameObject.GetComponent<TriggerEnemys>().amount--;
        Destroy(gameObject, 2f);
    }

    IEnumerator ReturnMaterialAF()
    {
        freezing = true;
        //anima.Stop();
        yield return new WaitForSeconds(2f);
        freezing = false;
        rend.material = normal;
    }

    IEnumerator ReturnMaterial()
    {
        yield return new WaitForSeconds(0.3f);
        rend.material = normal;
    }
}

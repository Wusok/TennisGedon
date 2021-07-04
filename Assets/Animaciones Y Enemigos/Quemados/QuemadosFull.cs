using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuemadosFull : MonoBehaviour
{
    public GameObject player;
    public Renderer rend;
    public Material normal;
    public Material freeze;
    public Material dmg;
    public Animator anima;
    public Vector3 playerlook;
    public float distanciaPlayer;
    public float lineofsite;
    public float life = 10;
    public bool freezing = false;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerlook = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
        distanciaPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanciaPlayer < lineofsite)
        {
            //transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, (speed * Time.deltaTime));
            transform.LookAt(playerlook);
            Shoot();
        }
    }

    public void Shoot()
    {

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

        if (other.gameObject.tag == "Explosion")
        {
            life -= 1f;
        }

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ReturnMaterialAF()
    {
        freezing = true;
        yield return new WaitForSeconds(1f);
        freezing = false;
        rend.material = normal;
    }

    IEnumerator ReturnMaterial()
    {
        yield return new WaitForSeconds(0.3f);
        rend.material = normal;
    }
}

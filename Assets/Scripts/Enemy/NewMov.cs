using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMov : MonoBehaviour
{
    public GameObject player;
    Renderer rend;
    float life = 10f;
    public Material dmg;
    public Material freeze;
    public Material normal;

    bool freezing = false;

    public Vector3 playerlook;
    public float distanciaPlayer;

    public float lineofsite;
    public float bootcolision;

    public float walls;

    public GameObject ball;

    private bool canshoot = true;

    public float speed = 10;
    bool stay = false;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movemnt();
        if (canshoot == true)
        {
            canshoot = false;
            Shoot();
        }

    }

    private void Shoot()
    {
        Instantiate(ball, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), transform.rotation);
        StartCoroutine(CanShoot());
    }

    IEnumerator CanShoot()
    {
        yield return new WaitForSeconds(0.5f);
        canshoot = true;
    }

    private void movemnt()
    {
        playerlook = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
        distanciaPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanciaPlayer < lineofsite && distanciaPlayer > bootcolision)
        {
            stay = false;
        }

        if (distanciaPlayer < lineofsite && distanciaPlayer > bootcolision && stay == false)
        {
            //transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, (speed * Time.deltaTime));
            transform.LookAt(playerlook);
        }
        else if (distanciaPlayer <= bootcolision)
            stay = true;
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

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lineofsite);
        Gizmos.DrawWireSphere(transform.position, bootcolision);
        Gizmos.DrawWireSphere(transform.position, walls);
    }
}

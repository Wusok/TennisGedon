using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMov : MonoBehaviour
{
    public GameObject player;
    /*Renderer rend;
    float life = 10f;*/

    public Vector3 playerlook;
    public float distanciaPlayer;

    public float lineofsite;
    public float bootcolision;

    public float walls;

    public GameObject ball;

    private bool canshoot = true;

    public float speed = 10;
    //bool stay = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movemnt();
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

    /*private void movemnt()
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
    }*/

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lineofsite);
        Gizmos.DrawWireSphere(transform.position, bootcolision);
        Gizmos.DrawWireSphere(transform.position, walls);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quemadomov : MonoBehaviour
{
    private Vector3 playerlook;
    private float distanciaPlayer;
    public GameObject player;
    public float lineofsite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movemnt();
    }
    private void movemnt()
    {
        playerlook = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
        distanciaPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanciaPlayer < 30)
        {
            //transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, (speed * Time.deltaTime));
            transform.LookAt(playerlook);
        }
    }
}

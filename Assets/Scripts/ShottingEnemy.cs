using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShottingEnemy : MonoBehaviour
{
    private bool IsHere;
    public GameObject EnemyBullet;
    private float CDR;
    
    // Update is called once per frame
    void Update()
    {
        if(IsHere == true && CDR >= 0.5f)
        {
            GameObject OneBullet = Instantiate(EnemyBullet, transform.position, transform.rotation);
            Destroy(OneBullet, 4f);
            CDR = 0;
        }
        CDR += 1 * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            IsHere = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsHere = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class habilitymenu : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Multi()
    {
        Bullet.activateMulti = true;
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        Bullet.activateMulti = false;
    }

    public void Rapid()
    {
        Bullet.activateRapid = true;
        StartCoroutine(waitr());
    }

    IEnumerator waitr()
    {
        yield return new WaitForSeconds(3);
        Bullet.activateRapid = false;
    }
}

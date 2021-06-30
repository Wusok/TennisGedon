using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    void Update()
    {
        transform.localScale += new Vector3(1, 1, 1);
        StartCoroutine(Autodestruccion());
    }

    IEnumerator Autodestruccion()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}

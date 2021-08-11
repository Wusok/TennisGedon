using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboPruebas : MonoBehaviour
{
    public Renderer rend;
    public Material normal;
    public Material dmg;
    private void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pelota")
        {
            StartCoroutine(MaterialChange());
        }
    }

    IEnumerator MaterialChange()
    {
        rend.material = dmg;
        yield return new WaitForSeconds(1f);
        rend.material = normal;
    }
}

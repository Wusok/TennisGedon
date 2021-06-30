using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    GameObject player;
    float speed = 4;

    public GameObject triggerOne;
    public GameObject triggerTwo;
    public GameObject triggerThree;

    bool one = false;
    bool two = false;
    bool three = false;

    public GameObject areaGH;
    bool da = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        transform.position += transform.forward * speed * Time.deltaTime;
        PlusTriggers();
        Habilitys();
    }

    void Habilitys()
    {
        if(one == true)
        {
            HOne();
        }
        else if (two == true)
        {
            HTwo();
        }
        else if(three == true)
        {
            HThree();
        }
    }

    void HOne()
    {
        //shacke camera
        //animacion golpe
        StartCoroutine(GrowndHit());
    }

    IEnumerator GrowndHit()
    {
        yield return new WaitForSeconds(0.5f);
        if (da == true)
        {
            Instantiate(areaGH, new Vector3(transform.position.x + 0.5f, transform.position.y - 4, transform.position.z), transform.rotation);
            da = false;
        }
        
    }

    void HTwo()
    {

    }
    void HThree()
    {

    }

    void PlusTriggers()
    {
        if (triggerOne.GetComponent<Colliders>().triggerOn == true)
        {
            one = true;
        }
        if (triggerTwo.GetComponent<Colliders>().triggerOn == true)
        {
            two = true;
        }
        if (triggerThree.GetComponent<Colliders>().triggerOn == true)
        {
            three = true;
        }

        if (triggerOne.GetComponent<Colliders>().triggerOn == false)
        {
            one = false;
        }
        if (triggerTwo.GetComponent<Colliders>().triggerOn == false)
        {
            two = false;
        }
        if (triggerThree.GetComponent<Colliders>().triggerOn == false)
        {
            three = false;
        }
    }
}

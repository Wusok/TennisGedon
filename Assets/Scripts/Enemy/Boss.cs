using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    GameObject player;
    float speed = 4;

    public Animator anima;

    public GameObject triggerOne;
    public GameObject triggerTwo;
    public GameObject triggerThree;

    bool one = false;
    bool two = false;
    bool three = false;

    public GameObject particulasGolpe;

    public GameObject areaGH;
    bool move = true;

    bool doHablity = true;
    bool inRange = false;
    int hability;

    float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            Run();

            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

            transform.position += transform.forward * speed * Time.deltaTime;

            if (inRange == true)
            {
                if (timer > 2)
                {
                    hability = Random.Range(1, 4);
                    Debug.Log("timer");
                    doHablity = true;
                    timer = 0;
                }

                timer += 1 * Time.deltaTime;
            }
            else
            {
                timer = 0;
                Idle();
            }

            PlusTriggers();
            Habilitys();
        }
    }

    void Idle()
    {
        anima.SetBool("idle", true);
        anima.SetBool("2manos", false);
        anima.SetBool("run", false);
        anima.SetBool("patada", false);
    }

    void Mandoble()
    {
        anima.SetBool("idle", false);
        anima.SetBool("2manos", true);
        anima.SetBool("run", false);
        anima.SetBool("patada", false);
    }

    void Run()
    {
        anima.SetBool("idle", false);
        anima.SetBool("2manos", false);
        anima.SetBool("run", true);
        anima.SetBool("patada", false);
    }

    void Patada()
    {
        anima.SetBool("idle", false);
        anima.SetBool("2manos", false);
        anima.SetBool("run", false);
        anima.SetBool("patada", true);
    }

    void Habilitys()
    {
        if (one || two || three)
        {
            inRange = true;
        }
        else if(one == false && two == false && three == false)
        {
            inRange = false;
        }
        
        if(one == true && hability == 1)
        {
            HOne();
            hability = 0;
        }
        else if (two == true && hability == 2 || one && hability == 2)
        {
            HTwo();
            hability = 0;
        }
        else if(three == true && hability == 3 || two == true && hability == 3 || one && hability == 3)
        {
            HThree();
            hability = 0;
        }
    }

    void HOne()
    {
        //shacke camera
        //animacion golpe
        StartCoroutine(GrowndHit());
        StartCoroutine(movement());
       
    }

    IEnumerator movement()
    {
        move = false;
        yield return new WaitForSeconds(0.5f);
        move = true;
    }

    IEnumerator GrowndHit()
    {
        Mandoble();
        yield return new WaitForSeconds(1);
        if (doHablity == true)
        {
            Instantiate(areaGH, new Vector3(transform.position.x + 0.5f, transform.position.y - 4, transform.position.z), transform.rotation);
            GameObject par1 = Instantiate(particulasGolpe, new Vector3(transform.position.x + 0.5f, transform.position.y - 4, transform.position.z + 1), transform.rotation);
            GameObject par2 = Instantiate(particulasGolpe, new Vector3(transform.position.x + 0.5f, transform.position.y - 4, transform.position.z - 1), transform.rotation);
            Destroy(par1, 1f);
            Destroy(par2, 1f);
        }
        Debug.Log("habilideda1");
        yield return new WaitForSeconds(4);
        doHablity = false;
        Debug.Log("habilideda1fin");
    }

    void HTwo()
    {
        Debug.Log("habilidad2");
    }
    void HThree()
    {
        Debug.Log("habilidad3");
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

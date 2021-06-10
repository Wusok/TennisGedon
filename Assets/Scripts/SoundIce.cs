using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundIce : MonoBehaviour
{
    public AudioClip icebreack;
    private AudioSource audiosource;
    private float timer = 0;
    private bool sound = false;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if(timer >= 2 && sound == false)
        {
            audiosource.PlayOneShot(icebreack);
            sound = true;
        }
        if(timer >= 3)
        {
            Destroy(gameObject);
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPJSMove : MonoBehaviour
{
    public float HorizontalMove;
    public float VerticalMove;
    public float fallvelocity;
    public CharacterController player;
    private float speed = 5;
    private float runspeed = 2f;
    public float gravity = 20f;
    public float jumpforce = 8f;
    public static int Life = 6;
    public static int MoveSide;
    private float resettimer = 0;

    public AudioClip hitsound;
    private AudioSource audiosource;

    private Vector3 playerInput;

    private void Awake()
    {
        Life = 6;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Start()
    {
        player = GetComponent<CharacterController>();
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (MenuManager.CantMove == false)
        {
            HorizontalMove = Input.GetAxisRaw("Horizontal");
            VerticalMove = Input.GetAxisRaw("Vertical");

            Vector3 move = transform.right * HorizontalMove + transform.forward * VerticalMove;

            playerInput = move;

            playerInput = playerInput * speed;

            if (Input.GetAxis("Horizontal") > 0)
            {
                MoveSide = 1;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                MoveSide = -1;
            }
            else if (Input.GetAxis("Horizontal") == 0)
            {
                MoveSide = 0;
            }

            SetGravity();

            PlayerSkills();

            player.Move(playerInput * Time.deltaTime);

            if (Life <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            } 
        }

        if (Input.GetKey("p"))
        {
            if (resettimer>= 1)
            {
                resettimer = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            resettimer += 1 * Time.deltaTime;
        }
        if (Input.GetKeyUp("p"))
        {
            resettimer = 0;
        }
    }

    void SetGravity()
    {
        if (player.isGrounded)
        {
            fallvelocity = -gravity * Time.deltaTime;
            playerInput.y = fallvelocity;
        }
        else
        {
            fallvelocity -= gravity * Time.deltaTime;
            playerInput.y = fallvelocity;
        }
    }

    void PlayerSkills()
    {
        if(player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallvelocity = jumpforce;
            playerInput.y = fallvelocity;
        }

        if (Input.GetButton("Sprint"))
        {
            playerInput = playerInput * runspeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (other.gameObject.tag == "EnemyBullet")
        {
            audiosource.PlayOneShot(hitsound);
            Life--;
            Debug.Log(Life);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPJSMove : MonoBehaviour
{
    //[SerializeField] Acceder como publica a privada
    //[Range(-5, 5)] Hacer un slider de una variable
    //Shift f12 Buscadr donde se usa cada variable
    //other

    public float HorizontalMove;
    public float VerticalMove;
    public float fallvelocity;
    public CharacterController player;
    private float speed = 5;
    private float runspeed = 2.5f;
    public float gravity = 20f;
    private float jumpforce = 10f;
    public static int Life = 6;
    public static int MoveSide;
    private float resettimer = 0;
    public static int LastCheckpoint = 0;
    Transform ThisCheckPoint;
    public static bool EnableCheckPoints = false;
    public static int NextLVL = 1;
    private int ThisLVL = -1;

    public static float x;
    public static float z;

    public AudioClip hitsound;
    private AudioSource audiosource;

    private Vector3 playerInput;

    private void Awake()
    {
        CheckPoint();
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
            if (ThisLVL != NextLVL)
            {
                EnableCheckPoints = false;
                ThisLVL = NextLVL;
            }

            HorizontalMove = Input.GetAxisRaw("Horizontal");
            VerticalMove = Input.GetAxisRaw("Vertical");

            Vector3 move = transform.right * HorizontalMove + transform.forward * VerticalMove;

            playerInput = move;

            playerInput = playerInput * speed;

            if (Input.GetAxis("Horizontal") > 0)
                MoveSide = 1;
            else if (Input.GetAxis("Horizontal") < 0)
                MoveSide = -1;
            else if (Input.GetAxis("Horizontal") == 0)
                MoveSide = 0;

            SetGravity();

            PlayerSkills();

            x = playerInput.x;
            z = playerInput.z;

            player.Move(playerInput * Time.deltaTime);
        }

        if (Input.GetKey("p"))
        {
            if (resettimer >= 1)
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
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallvelocity = jumpforce;
            playerInput.y = fallvelocity;
        }

        if (Input.GetButton("Sprint"))
        {
            playerInput.x = playerInput.x * runspeed;
            playerInput.z = playerInput.z * runspeed;
        }
    }

    void CheckPoint()
    {
        if (EnableCheckPoints == true)
        {
            ThisCheckPoint = GameObject.FindGameObjectWithTag("CheckPoint" + LastCheckpoint).transform;
            transform.position = ThisCheckPoint.position;
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
            if (Life <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            Debug.Log(Life);
        }
        if (other.gameObject.tag == "Enemy")
        {
            //other.GetComponent<Enemy>().EnemyLife
        }
    }
}


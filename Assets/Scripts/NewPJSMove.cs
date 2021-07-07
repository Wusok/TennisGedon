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
    private float speed;
    private float runSpeed = 16;
    private float walkSpeed = 7;
    public float gravity = 0.5f;

    [SerializeField]
    private float jumpforce = 10f;


    public static int Life = 6;
    public static int MoveSide;
    private float resettimer = 0;
    public static int LastCheckpoint = 0;
    public static bool EnableCheckPoints = false;
    public static int NextLVL = 1;
    public static float dash = 1.6f;
    private bool canDash = true;
    private bool isDashing = false;
    private float movementMagnitud;
    private Rigidbody rb;
    bool isGrounded;
    public static bool canDJ = false;
    float jumpBoostForce = 30;

    public int numberRespawn = 0;

    public static float x;

    private int jump = 2;

    public AudioClip hitsound;
    private AudioSource audiosource;

    private Vector3 playerInput;

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "LVL1")
        {
            canDJ = false;
        }
        Life = 6;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isDashing == false)
        {
            /*if (ThisLVL != NextLVL)
            {
                EnableCheckPoints = false;
                ThisLVL = NextLVL;
            }*/

            HorizontalMove = Input.GetAxisRaw("Horizontal");
            VerticalMove = Input.GetAxisRaw("Vertical");

            movementMagnitud = playerInput.magnitude;

            playerInput = transform.right * HorizontalMove + transform.forward * VerticalMove * Mathf.Abs(VerticalMove);

            playerInput.y = 0;

        }

        if (movementMagnitud > 1)
        {
            rb.MovePosition(transform.position + playerInput.normalized * (speed * Time.deltaTime));
            movementMagnitud = 1;
        }
        else
            rb.MovePosition(transform.position + playerInput * (speed * Time.deltaTime));

        if (canDash == false)
        {
            dash += 1 * Time.deltaTime;
            if (dash > 1.5f)
            {
                canDash = true;
            }
        }
        else
            dash = 0;

        PlayerSkills();

        x = HorizontalMove;

        if (isGrounded == false)
        {
            rb.AddForce(transform.up * -1 * gravity, ForceMode.Acceleration);
        }
    }

    void PlayerSkills()
    {
        if (Input.GetButtonDown("Jump") && jump > 1)
        {
            rb.AddForce(transform.up * jumpforce, ForceMode.Impulse);
            jump--;
            Debug.Log("Saltar");
        }
        else if(Input.GetButtonDown("Jump") && jump > 0 && canDJ)
        {
            rb.AddForce(transform.up * jumpforce, ForceMode.Impulse);
            jump--;
        }

        if (isDashing == false)
        {
            if (Input.GetButton("Sprint"))
            {
                speed = runSpeed;
            }
            else
            {
                speed = walkSpeed;
            }
        }

        if (Input.GetButtonDown("Dash") && canDash == true)
        {
            Debug.Log("dash");
            canDash = false;
            isDashing = true;
            StartCoroutine(Dash());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            jump = 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            audiosource.PlayOneShot(hitsound);
            Life--;
            if (Life <= 0)
            {
                SceneManager.LoadScene("LoseScreen");
            }
            Debug.Log(Life);
        }

        if(other.gameObject.tag == "PunchZone")
        {
            audiosource.PlayOneShot(hitsound);
            Life -= 3;
            Destroy(other);
            if (Life <= 0)
            {
                SceneManager.LoadScene("LoseScreen");
            }
            Debug.Log(Life);
        }

        if (other.gameObject.tag == "Boots")
        {
            canDJ = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "JumpBoost")
        {
            rb.velocity -= 1f * rb.velocity;
            rb.AddForce(transform.up * jumpBoostForce, ForceMode.Impulse);
            jump--;
        }
    }

    

    IEnumerator Dash()
    {
        Debug.Log("Corutine");
        //speed = speed * 15;
        rb.AddForce(playerInput * 2000, ForceMode.Force);
        yield return new WaitForSeconds(0.1f);
        rb.velocity -= 1f * rb.velocity;
        Debug.Log("termino cr");
        //speed = speed / 15;
        isDashing = false;
    }
}


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
    private float runSpeed = 14;
    private float walkSpeed = 7;
    public float gravity = 0.5f;
    private float jumpforce = 10f;
    public static int Life = 6;
    public static int MoveSide;
    private float resettimer = 0;
    public static int LastCheckpoint = 0;
    Transform ThisCheckPoint;
    public static bool EnableCheckPoints = false;
    public static int NextLVL = 1;
    private int ThisLVL = -1;
    public static float dash = 1.6f;
    private bool canDash = true;
    private bool isDashing = false;
    private float movementMagnitud;
    private Rigidbody rb;
    bool isGrounded;
    bool dobleJump = false;
    bool canDJ = false;
    float jumpBoostForce = 30;

    public static float x;

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

        if (isGrounded == false)
        {
            rb.AddForce(transform.up * -1 * gravity, ForceMode.Acceleration);
        }
        //Debug.Log(Life);
    }

    void PlayerSkills()
    {
        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(transform.up * jumpforce, ForceMode.Impulse);
            Debug.Log("Saltar");
        }

        if (Input.GetButtonDown("Jump") && isGrounded == false && dobleJump == true)
        {
            rb.AddForce(transform.up * jumpforce, ForceMode.Impulse);
            dobleJump = false;
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
        /*if (other.gameObject.tag == "Enemy")
        {
            //other.GetComponent<Enemy>().EnemyLife
        }*/
        if (other.gameObject.tag == "Boots")
        {
            canDJ = true;
            dobleJump = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "JumpBoost")
        {
            rb.velocity -= 1f * rb.velocity;
            rb.AddForce(transform.up * jumpBoostForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            if (canDJ)
            {
                dobleJump = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject GreenLife;
    public GameObject YellowLife;
    public GameObject RedLife;

    public static int Ball;
    private bool While = false;

    [Header("Primer Slot")]
    [Header("Pelotas")]
    public GameObject FirstNB;
    public GameObject FirstIB;
    public GameObject FirstEB;
    public GameObject FirstHB;
    [Header("Segundo Slot")]
    public GameObject SecondNB;
    public GameObject SecondIB;
    public GameObject SecondEB;
    public GameObject SecondHB;
    [Header("Tercer Slot")]
    public GameObject ThirdNB;
    public GameObject ThirdIB;
    public GameObject ThirdEB;
    public GameObject ThirdHB;
    [Header("Cuarto Slot")]
    public GameObject FourNB;
    public GameObject FourIB;
    public GameObject FourEB;
    public GameObject FourHB;

    public Image circleTimer;
    public static bool dontHave;
    public static bool usingHability;

    public Image MultiG;
    public GameObject Multi;
    public Image RapidG;
    public GameObject Rapid;

    public GameObject habilitiesPanel;

    public static bool HaveMulti = false;
    public static bool HaveRapid = false;

    private bool oneHM = false;
    private bool oneHR = false;


    public float timerRapid = 3;
    public float timerMulti = 3;

    private bool do1 = false;
    private bool do2 = false;

    void Start()
    {

    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "LVL1")
        {
            HaveMulti = false;
            HaveRapid = false;
        }

        RapidG.fillAmount = 1;
        MultiG.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (NewPJSMove.Life > 4)
        {
            GreenLife.gameObject.SetActive(true);
            YellowLife.gameObject.SetActive(false);
            RedLife.gameObject.SetActive(false);
        }
        if (NewPJSMove.Life <= 4 && NewPJSMove.Life > 2)
        {
            GreenLife.gameObject.SetActive(false);
            YellowLife.gameObject.SetActive(true);
            RedLife.gameObject.SetActive(false);
        }
        if (NewPJSMove.Life <= 2)
        {
            GreenLife.gameObject.SetActive(false);
            YellowLife.gameObject.SetActive(false);
            RedLife.gameObject.SetActive(true);
        }

        Hability();

        /*if(circleTimer.fillAmount != 1f)
        {
            circleTimer.fillAmount += 0.0001f;
        }*/

        if (Input.GetKeyDown("e"))
        {
            if (Ball < 3)
                Ball += 1;
            else
                Ball = 0;
            BallsUp();
        }

        if (Input.GetKeyDown("q"))
        {
            if (Ball > 0)
                Ball += -1;
            else
                Ball = 3;
            BallsDown();
        }

    }


    void Hability()
    {
        if (HaveMulti && oneHM == false)
        {
            timerMulti = 0;
            Multi.gameObject.SetActive(true);
            MultiG.fillAmount = timerMulti / 3;
            oneHM = true;
        }

        if (Bullet.activateMulti)
        {
            if (do1 == false)
            {
                timerMulti = 3;
                do1 = true;
            }
            timerMulti = timerMulti - 1 * Time.deltaTime;
            MultiG.fillAmount = timerMulti / 3;
        }
        else
        {
            timerMulti = 0;
            MultiG.fillAmount = timerMulti / 3;
            do1 = false;
        }

        if (HaveRapid && oneHR == false)
        {
            timerRapid = 0;
            Rapid.gameObject.SetActive(true);
            RapidG.fillAmount = timerRapid / 3;
            oneHR = true;
        }

        if (Bullet.activateRapid)
        {
            if (do2 == false)
            {
                timerRapid = 3;
                do2 = true;
            }
            timerRapid = timerRapid - 1 * Time.deltaTime;
            RapidG.fillAmount = timerRapid / 3;
        }
        else
        {
            timerRapid = 0;
            RapidG.fillAmount = timerRapid / 3;
            do2 = false;
        }


        if (Input.GetKey("tab"))
        {
            habilitiesPanel.gameObject.SetActive(true);
            ControllCamera.cameraOn = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0.5f;

        }
        else if (Input.GetKeyUp("tab"))
        {
            habilitiesPanel.gameObject.SetActive(false);
            ControllCamera.cameraOn = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
        }
    }

    void BallsDown()
    {


        while (While == false)
        {
            if (Ball == 0)
            {
                FirstNB.gameObject.SetActive(true);
                FirstIB.gameObject.SetActive(false);
                FirstEB.gameObject.SetActive(false);
                FirstHB.gameObject.SetActive(false);

                SecondNB.gameObject.SetActive(false);
                SecondIB.gameObject.SetActive(true);
                SecondEB.gameObject.SetActive(false);
                SecondHB.gameObject.SetActive(false);

                ThirdNB.gameObject.SetActive(false);
                ThirdIB.gameObject.SetActive(false);
                ThirdEB.gameObject.SetActive(true);
                ThirdHB.gameObject.SetActive(false);

                FourNB.gameObject.SetActive(false);
                FourIB.gameObject.SetActive(false);
                FourEB.gameObject.SetActive(false);
                FourHB.gameObject.SetActive(true);

                While = true;
            }
            if (Ball == 1 && Bullet.HaveIceBullet)
            {
                FirstNB.gameObject.SetActive(false);
                FirstIB.gameObject.SetActive(true);
                FirstEB.gameObject.SetActive(false);
                FirstHB.gameObject.SetActive(false);

                SecondNB.gameObject.SetActive(true);
                SecondIB.gameObject.SetActive(false);
                SecondEB.gameObject.SetActive(false);
                SecondHB.gameObject.SetActive(false);

                ThirdNB.gameObject.SetActive(false);
                ThirdIB.gameObject.SetActive(false);
                ThirdEB.gameObject.SetActive(true);
                ThirdHB.gameObject.SetActive(false);

                FourNB.gameObject.SetActive(false);
                FourIB.gameObject.SetActive(false);
                FourEB.gameObject.SetActive(false);
                FourHB.gameObject.SetActive(true);

                While = true;
            }
            else if (Ball == 1 && Bullet.HaveIceBullet == false)
            {
                Ball--;
            }

            if (Ball == 2 && Bullet.HaveExplosiveBullet)
            {
                FirstNB.gameObject.SetActive(false);
                FirstIB.gameObject.SetActive(false);
                FirstEB.gameObject.SetActive(true);
                FirstHB.gameObject.SetActive(false);

                SecondNB.gameObject.SetActive(false);
                SecondIB.gameObject.SetActive(true);
                SecondEB.gameObject.SetActive(false);
                SecondHB.gameObject.SetActive(false);

                ThirdNB.gameObject.SetActive(true);
                ThirdIB.gameObject.SetActive(false);
                ThirdEB.gameObject.SetActive(false);
                ThirdHB.gameObject.SetActive(false);

                FourNB.gameObject.SetActive(false);
                FourIB.gameObject.SetActive(false);
                FourEB.gameObject.SetActive(false);
                FourHB.gameObject.SetActive(true);

                While = true;
            }
            else if (Ball == 2 && Bullet.HaveExplosiveBullet == false)
            {
                Ball--;
            }

            if (Ball == 3 && Bullet.HaveBigBullet)
            {
                FirstNB.gameObject.SetActive(false);
                FirstIB.gameObject.SetActive(false);
                FirstEB.gameObject.SetActive(false);
                FirstHB.gameObject.SetActive(true);

                SecondNB.gameObject.SetActive(false);
                SecondIB.gameObject.SetActive(true);
                SecondEB.gameObject.SetActive(false);
                SecondHB.gameObject.SetActive(false);

                ThirdNB.gameObject.SetActive(false);
                ThirdIB.gameObject.SetActive(false);
                ThirdEB.gameObject.SetActive(true);
                ThirdHB.gameObject.SetActive(false);

                FourNB.gameObject.SetActive(true);
                FourIB.gameObject.SetActive(false);
                FourEB.gameObject.SetActive(false);
                FourHB.gameObject.SetActive(false);

                While = true;
            }
            else if (Ball == 3 && Bullet.HaveBigBullet == false)
            {
                Ball--; ;
            }
            Debug.Log(Ball);
        }

        While = false;
        Bullet.UsingBullet = Ball;
    }

    void BallsUp()
    {


        while (While == false)
        {
            if (Ball == 0)
            {
                FirstNB.gameObject.SetActive(true);
                FirstIB.gameObject.SetActive(false);
                FirstEB.gameObject.SetActive(false);
                FirstHB.gameObject.SetActive(false);

                SecondNB.gameObject.SetActive(false);
                SecondIB.gameObject.SetActive(true);
                SecondEB.gameObject.SetActive(false);
                SecondHB.gameObject.SetActive(false);

                ThirdNB.gameObject.SetActive(false);
                ThirdIB.gameObject.SetActive(false);
                ThirdEB.gameObject.SetActive(true);
                ThirdHB.gameObject.SetActive(false);

                FourNB.gameObject.SetActive(false);
                FourIB.gameObject.SetActive(false);
                FourEB.gameObject.SetActive(false);
                FourHB.gameObject.SetActive(true);

                While = true;
            }
            if (Ball == 1 && Bullet.HaveIceBullet)
            {
                FirstNB.gameObject.SetActive(false);
                FirstIB.gameObject.SetActive(true);
                FirstEB.gameObject.SetActive(false);
                FirstHB.gameObject.SetActive(false);

                SecondNB.gameObject.SetActive(true);
                SecondIB.gameObject.SetActive(false);
                SecondEB.gameObject.SetActive(false);
                SecondHB.gameObject.SetActive(false);

                ThirdNB.gameObject.SetActive(false);
                ThirdIB.gameObject.SetActive(false);
                ThirdEB.gameObject.SetActive(true);
                ThirdHB.gameObject.SetActive(false);

                FourNB.gameObject.SetActive(false);
                FourIB.gameObject.SetActive(false);
                FourEB.gameObject.SetActive(false);
                FourHB.gameObject.SetActive(true);

                While = true;
            }
            else if (Ball == 1 && Bullet.HaveIceBullet == false)
            {
                Ball++;
            }

            if (Ball == 2 && Bullet.HaveExplosiveBullet)
            {
                FirstNB.gameObject.SetActive(false);
                FirstIB.gameObject.SetActive(false);
                FirstEB.gameObject.SetActive(true);
                FirstHB.gameObject.SetActive(false);

                SecondNB.gameObject.SetActive(false);
                SecondIB.gameObject.SetActive(true);
                SecondEB.gameObject.SetActive(false);
                SecondHB.gameObject.SetActive(false);

                ThirdNB.gameObject.SetActive(true);
                ThirdIB.gameObject.SetActive(false);
                ThirdEB.gameObject.SetActive(false);
                ThirdHB.gameObject.SetActive(false);

                FourNB.gameObject.SetActive(false);
                FourIB.gameObject.SetActive(false);
                FourEB.gameObject.SetActive(false);
                FourHB.gameObject.SetActive(true);

                While = true;
            }
            else if (Ball == 2 && Bullet.HaveExplosiveBullet == false)
            {
                Ball++;
            }

            if (Ball == 3 && Bullet.HaveBigBullet)
            {
                FirstNB.gameObject.SetActive(false);
                FirstIB.gameObject.SetActive(false);
                FirstEB.gameObject.SetActive(false);
                FirstHB.gameObject.SetActive(true);

                SecondNB.gameObject.SetActive(false);
                SecondIB.gameObject.SetActive(true);
                SecondEB.gameObject.SetActive(false);
                SecondHB.gameObject.SetActive(false);

                ThirdNB.gameObject.SetActive(false);
                ThirdIB.gameObject.SetActive(false);
                ThirdEB.gameObject.SetActive(true);
                ThirdHB.gameObject.SetActive(false);

                FourNB.gameObject.SetActive(true);
                FourIB.gameObject.SetActive(false);
                FourEB.gameObject.SetActive(false);
                FourHB.gameObject.SetActive(false);

                While = true;
            }
            else if (Ball == 3 && Bullet.HaveBigBullet == false)
            {
                Ball = 0;
            }
            Debug.Log(Ball);
        }

        While = false;
        Bullet.UsingBullet = Ball;
    }
}

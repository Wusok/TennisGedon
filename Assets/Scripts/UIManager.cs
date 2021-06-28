using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

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

    public GameObject MultiG;
    public GameObject Multi;
    public GameObject RapidG;
    public GameObject Rapid;

    public GameObject habilitiesPanel;

    public static bool HaveMulti;
    public static bool HaveRapid;

    void Start()
    {

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
            Balls();
    }


    void Hability()
    {
        if (HaveMulti)
        {
            Multi.gameObject.SetActive(true);
            MultiG.gameObject.SetActive(false);
        }

        if (HaveRapid)
        {
            Rapid.gameObject.SetActive(true);
            RapidG.gameObject.SetActive(false);
        }


        if (Input.GetKey("tab"))
        {
            habilitiesPanel.gameObject.SetActive(true);
            ControllCamera.cameraOn = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else if (Input.GetKeyUp("tab"))
        {
            habilitiesPanel.gameObject.SetActive(false);
            ControllCamera.cameraOn = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Balls()
    {
        if (Ball < 3)
            Ball += 1;
        else
            Ball = 0;

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

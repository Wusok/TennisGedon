using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class UIManager : MonoBehaviour
{
    public GameObject GreenLife;
    public GameObject YellowLife;
    public GameObject RedLife;

    public static int Weapon;
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

    [Header("Primer Slot")]
    [Header("Armas")]
    public GameObject FWeapon1;
    public GameObject FWeapon2;
    public GameObject FWeapon3;
    public GameObject FWeapon4;
    [Header("Segundo Slot")]
    public GameObject SWeapon1;
    public GameObject SWeapon2;
    public GameObject SWeapon1G;

    [Header("Tercer Slot")]
    public GameObject TWeapon1;
    public GameObject TWeapon2;
    public GameObject TWeapon1G;

    [Header("Cuarto Slot")]
    public GameObject FoWeapon1;
    public GameObject FoWeapon2;
    public GameObject FoWeapon1G;


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

        if (Input.GetKeyDown("e"))
            Balls();
        if (Input.GetKeyDown("q"))
            Weapons();
    }


    void Weapons()
    {
        if (Weapon < 3)
            Weapon += 1;
        else
            Weapon = 0;

        while (While == false)
        {
            if (Weapon == 0)
            {
                FWeapon1.gameObject.SetActive(true);
                FWeapon2.gameObject.SetActive(false);
                FWeapon3.gameObject.SetActive(false);
                FWeapon4.gameObject.SetActive(false);

                SWeapon1.gameObject.SetActive(true);
                SWeapon2.gameObject.SetActive(false);

                TWeapon1.gameObject.SetActive(true);
                TWeapon2.gameObject.SetActive(false);

                FoWeapon1.gameObject.SetActive(true);
                FoWeapon2.gameObject.SetActive(false);

                While = true;
            }

            if (Weapon == 1 && Bullet.MeleRacket == true)
            {
                FWeapon1.gameObject.SetActive(false);
                FWeapon2.gameObject.SetActive(true);
                FWeapon3.gameObject.SetActive(false);
                FWeapon4.gameObject.SetActive(false);

                SWeapon1.gameObject.SetActive(false);
                SWeapon2.gameObject.SetActive(true);

                TWeapon1.gameObject.SetActive(true);
                TWeapon2.gameObject.SetActive(false);

                FoWeapon1.gameObject.SetActive(true);
                FoWeapon2.gameObject.SetActive(false);

                While = true;
            }
            else if (Weapon == 1 && Bullet.MeleRacket == false)
            {
                Weapon++;
            }

            if (Weapon == 2 && Bullet.MultiRacket == true)
            {
                FWeapon1.gameObject.SetActive(false);
                FWeapon2.gameObject.SetActive(false);
                FWeapon3.gameObject.SetActive(true);
                FWeapon4.gameObject.SetActive(false);

                SWeapon1.gameObject.SetActive(true);
                SWeapon2.gameObject.SetActive(false);

                TWeapon1.gameObject.SetActive(false);
                TWeapon2.gameObject.SetActive(true);

                FoWeapon1.gameObject.SetActive(true);
                FoWeapon2.gameObject.SetActive(false);

                While = true;
            }
            else if (Weapon == 2 && Bullet.MultiRacket == false)
            {
                Weapon++;
            }

            if (Weapon == 3 && Bullet.RapidRacket == true)
            {
                FWeapon1.gameObject.SetActive(false);
                FWeapon2.gameObject.SetActive(false);
                FWeapon3.gameObject.SetActive(false);
                FWeapon4.gameObject.SetActive(true);

                SWeapon1.gameObject.SetActive(true);
                SWeapon2.gameObject.SetActive(false);

                TWeapon1.gameObject.SetActive(true);
                TWeapon2.gameObject.SetActive(false);

                FoWeapon1.gameObject.SetActive(false);
                FoWeapon2.gameObject.SetActive(true);

                While = true;
            }
            else if (Weapon == 3 && Bullet.RapidRacket == false)
            {
                Weapon=0;
            }
        }

        While = false;
        Bullet.UsingWeapon = Weapon;
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

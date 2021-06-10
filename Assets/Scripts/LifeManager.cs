using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class LifeManager : MonoBehaviour
{
    public GameObject GreenLife;
    public GameObject YellowLife;
    public GameObject RedLife;

    public GameObject NormalBall;
    public GameObject IceBall;
    public GameObject ExplosiveBall;
    public GameObject HeavyBall;

    public GameObject FirstNB;
    public GameObject FirstIB;
    public GameObject FirstEB;
    public GameObject FirstHB;

    public GameObject SecondNB;
    public GameObject SecondIB;
    public GameObject SecondEB;
    public GameObject SecondHB;

    public GameObject ThirdNB;
    public GameObject ThirdIB;
    public GameObject ThirdEB;
    public GameObject ThirdHB;

    public GameObject FourNB;
    public GameObject FourIB;
    public GameObject FourEB;
    public GameObject FourHB;


    /*public RectTransform NormalB;
    public RectTransform IceB;
    public RectTransform ExplosiveB;
    public RectTransform HeavyB;

    private RectTransform usingnormal;
    private RectTransform firstnormal;
    private RectTransform secondnormal;
    private RectTransform thirdnormal;*/
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(NewPJSMove.Life > 4)
        {
            GreenLife.gameObject.SetActive(true);
            YellowLife.gameObject.SetActive(false);
            RedLife.gameObject.SetActive(false);
        }
        if (NewPJSMove.Life <= 4 && NewPJSMove.Life >2)
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

        if(Bullet.UsingBullet == 0)
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
        }
        if (Bullet.UsingBullet == 1)
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
        }
        if (Bullet.UsingBullet == 2)
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
        }
        if (Bullet.UsingBullet == 3)
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
        }
    }
}

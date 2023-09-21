using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitchButton : MonoBehaviour
{
    public Button left;
    public Button right;

    public RectTransform rect;
    public Image digunakanButton;
    public Sprite[] digunakanSprite;

    public float slidingSpeed;
    public int maxCharacter;
    public int characterId = 0;

    public bool slidingLeft;
    public bool slidingRight;

    private float deltaMove;
    private float currentPosX;

    
    public Sapi[] listSapi;
    public Transform parent;
    public CurrentPlayerProperties currentPlayerProperties;

    private void Awake()
    {

        for (int i = 0; i < listSapi.Length; i++)
        {
            if (i == 0)
            {
                Instantiate(listSapi[i].prefabSapi, parent, false);

            }
            else
            {
                var a = Instantiate(listSapi[i].prefabSapi, parent, false).GetComponent<RectTransform>();
                a.anchoredPosition = new Vector2(a.anchoredPosition.x + (1000 * i), a.anchoredPosition.y);
            }


        }

    }

    public void slideLeft()
    {
        characterId -= 1;
        if (characterId < 0 || slidingLeft)
        {
            characterId = 0;
            return;
        }

        slidingLeft = true;

        if (currentPlayerProperties.currentSapi.id == characterId)
        {
            digunakanButton.sprite = digunakanSprite[0];
        }
        else
        {
            digunakanButton.sprite = digunakanSprite[1];

        }

        Gunakan();
    }

    public void Gunakan()
    {

        currentPlayerProperties.currentSapi = listSapi[characterId];
    }

    public void slideRight()
    {
        characterId += 1;
        if (characterId > maxCharacter || slidingRight)
        {
            characterId = maxCharacter;
            return;
        }

        slidingRight = true;

        if (currentPlayerProperties.currentSapi.id == characterId)
        {
            digunakanButton.sprite = digunakanSprite[0];
        }
        else
        {
            digunakanButton.sprite = digunakanSprite[1];

        }
    }

    private void Update()
    {
        if (slidingLeft)
        {
            deltaMove += slidingSpeed * Time.deltaTime;
            currentPosX += deltaMove;
            if (currentPosX > 1000)
            {
                slidingLeft = false;

                currentPosX = 0;

                deltaMove = 0;
                rect.anchoredPosition = new Vector2(-(characterId * 1000) - 55, rect.anchoredPosition.y);

            }
            else
            {
                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x + deltaMove, rect.anchoredPosition.y);

            }



        }

        if (slidingRight)
        {
            deltaMove += slidingSpeed * Time.deltaTime;

            currentPosX += deltaMove;
            if (currentPosX > 1000)
            {
                slidingRight = false;
                currentPosX = 0;
                deltaMove = 0;

                rect.anchoredPosition = new Vector2(-(characterId * 1000) - 55, rect.anchoredPosition.y);

            }
            else
            {
                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x - deltaMove, rect.anchoredPosition.y);

            }
        }


    }

}

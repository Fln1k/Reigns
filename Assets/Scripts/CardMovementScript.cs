using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CardMovementScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Camera MainCamera;
    Vector3 offset;
    public Transform DefaultParent, DefaultTempCardParent;
    public TextMeshProUGUI Decision_Left;
    public TextMeshProUGUI Decision_Right;
    public string movement;
    public Image gameObject;
    public Image army_bar;
    public Image food_bar;
    public Image money_bar;
    public Image people_bar;
    public TextMeshProUGUI Rotation;
    public TextMeshProUGUI AvailableCards;
    public TextMeshProUGUI ReignsDaysInfo;
    Card card;
    private int CardCounter;
    public string[] availablecard;
    private int ReignsCounter;
    private float Center_X;
    private float Center_Y;
    private bool Game;
    

    void Awake()
    {
        Game = true;
        Center_X = gameObject.transform.position.x;
        Center_Y = gameObject.transform.position.y;
        ReignsCounter = 23;
        MainCamera = Camera.allCameras[0];
        CardCounter = 1;
        Decision_Right.text = "";
        Decision_Left.text = "";
        availablecard = new string[10];
        int counter = 0;
        army_bar.fillAmount = 0.5F;
        food_bar.fillAmount = 0.5F;
        money_bar.fillAmount = 0.5F;
        people_bar.fillAmount = 0.5F;
        while (counter<10)
        {
            availablecard[counter] = "";
            counter += 1;
        }
        availablecard[3] = "Крестьянин";
        availablecard[4] = "Священник";
        availablecard[5] = "Повар";
        availablecard[6] = "Рыцарь";
    }

    void Update()
    {
        if (Game)
        {
            CardInfoScript.AllCards[0] = CardInfoScript.AllCards[CardCounter];
            AvailableCards.text = "";
            foreach (string st in availablecard)
            {
                AvailableCards.text += st;
                if (st != "")
                    AvailableCards.text += "|";
            }
            ReignsDaysInfo.text = "Reigns days: ";
            ReignsDaysInfo.text += ReignsCounter;
        }
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (Game)
        {
            offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);
            DefaultParent = DefaultTempCardParent = transform.parent;
            transform.SetParent(DefaultParent.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (Game)
        {
            float position = gameObject.transform.position.x;
            Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);
            transform.position = newPos * 10 + offset;
            if (position < Center_X - 15 && movement != "left")
            {
                movement = "left";
            }
            if (position > Center_X + 15 && movement != "right")
            {
                movement = "right";
            }
            if (position == Center_X && movement != "center")
            {
                movement = "center";
            }
            if (movement == "left" && gameObject.transform.rotation.z <= 0.2 || movement == "right" && gameObject.transform.rotation.z >= -0.2)
            {
                if (movement == "left")
                    transform.Rotate(new Vector3(0f, 0f, 10));
                else
                    transform.Rotate(new Vector3(0f, 0f, -10));
            }
            else
            {
                transform.Rotate(new Vector3(0f, 0f, 0f));
            }
            Rotation.text = (gameObject.transform.rotation.z).ToString();
            showchoice(CardInfoScript.AllCards[0], movement);
        }
    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (Game)
        {
            float position = gameObject.transform.position.x;
            transform.SetParent(DefaultParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            //ToLeft
            if (position < Center_X - 15)
            {
                if (CardCounter == 1)
                    CardCounter += 1;
                else
                {
                    if (CardCounter == 2)
                        CardCounter += 2;
                    else
                    {
                        if (CardCounter == 3)
                            CardCounter += 1;
                        else
                        {
                            if (CardCounter == 4)
                            {
                                availablecard[0] = "Шут";
                                CardCounter += 1;
                            }
                            if (CardCounter > 4)
                            {
                                ReignsCounter += 22;
                                army_bar.fillAmount += CardInfoScript.AllCards[0].properties_left[0];
                                food_bar.fillAmount += CardInfoScript.AllCards[0].properties_left[1];
                                money_bar.fillAmount += CardInfoScript.AllCards[0].properties_left[2];
                                people_bar.fillAmount += CardInfoScript.AllCards[0].properties_left[3];
                                System.Random rand = new System.Random();
                                name = "1";
                                int TempPointer = CardCounter;
                                bool available = false;
                                while (!available)
                                {
                                    CardCounter = rand.Next(5, CardInfoScript.AllCards.Count);
                                    foreach (string st in availablecard)
                                    {
                                        if (st == CardInfoScript.AllCards[CardCounter].name && CardCounter != TempPointer && CardInfoScript.AllCards[CardCounter].name != CardInfoScript.AllCards[TempPointer].name)
                                            available = true;
                                    }
                                }
                            }
                        }
                    }
                }
                transform.position = new Vector3(Center_X, Center_Y + 15, 0.0f);
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                Decision_Right.text = "";
            }
            else
            {
                //ToRight
                if (position > Center_X + 15)
                {
                    if (CardCounter == 1)
                        CardCounter += 1;
                    else
                    {
                        if (CardCounter == 2)
                            CardCounter += 1;
                        else
                        {
                            if (CardCounter == 3)
                                CardCounter += 1;
                            else
                            {
                                if (CardCounter == 4)
                                    CardCounter += 1;
                                if (CardCounter > 4)
                                {
                                    ReignsCounter += 22;
                                    army_bar.fillAmount += CardInfoScript.AllCards[0].properties_right[0];
                                    food_bar.fillAmount += CardInfoScript.AllCards[0].properties_right[1];
                                    money_bar.fillAmount += CardInfoScript.AllCards[0].properties_right[2];
                                    people_bar.fillAmount += CardInfoScript.AllCards[0].properties_right[3];
                                    System.Random rand = new System.Random();
                                    name = "1";
                                    int TempPointer = CardCounter;
                                    bool available = false;
                                    while (!available)
                                    {
                                        CardCounter = rand.Next(5, CardInfoScript.AllCards.Count);
                                        foreach (string st in availablecard)
                                        {
                                            if (st == CardInfoScript.AllCards[CardCounter].name && CardCounter != TempPointer && CardInfoScript.AllCards[CardCounter].name != CardInfoScript.AllCards[TempPointer].name)
                                                available = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    transform.position = new Vector3(Center_X, Center_Y + 15, 0.0f);
                    transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                    Decision_Left.text = "";
                }
                else
                {
                    transform.position = new Vector3(Center_X, Center_Y + 15, 0.0f);
                    transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                    Decision_Left.text = "";
                    Decision_Right.text = "";
                }
                if (army_bar.fillAmount <= 0 || food_bar.fillAmount <= 0 || money_bar.fillAmount <= 0 || people_bar.fillAmount <= 0)
                {
                    Game = false;
                }
            }
        }

    }

    public void showchoice(Card card, string movement)
    {
        if (movement == "right")
        {
            Decision_Right.text = "";
            Decision_Left.text = card.right_decision;
        }
        else
        {
            if (movement == "left")
            {
                Decision_Left.text = "";
                Decision_Right.text = card.left_decision;
            }
            else
            {
                Decision_Right.text = "";
                Decision_Left.text = "";
            }
        }
    }
}

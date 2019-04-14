using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardShowScript : MonoBehaviour
{
    public TextMeshProUGUI year;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Reigns_counter;
    public TextMeshProUGUI Task;
    public TextMeshProUGUI Decision_Left;
    public TextMeshProUGUI Decision_Right;
    public Image BackImg;
    public Image TempBackImg;
    public Card SelfCard;

    // Start is called before the first frame update
    void Start()
    {
        /*0*/CardInfoScript.AllCards.Add(new Card("", "", "", "", "", "", new float[4] { 0, 0, 0, 0 }, new float[4] { 0, 0, 0, 0 }));
        /*1*/CardInfoScript.AllCards.Add(new Card("Король", "Cards/King", "Background/KingBack", "Настало твоё время стать королём, как тебя зовут?", "Я...", "Я...", new float[4] { 0, 0, 0, 0 }, new float[4] { 0, 0, 0, 0 }));
        /*2*/CardInfoScript.AllCards.Add(new Card("Король", "Cards/King", "Background/KingBack", "Впрочем неважно, я всё равно буду звать тебя дибил", "Проваливай", "Казнить", new float[4] { 0, 0, 0, 0 }, new float[4] { 0, 0, 0, 0 }));
        /*3*/CardInfoScript.AllCards.Add(new Card("Король", "Cards/King", "Background/KingBack", "Стой, возможно мне удасться тебя переубедить", "Выслушать", "Казнить", new float[4] { 0, 0, 0, 0 }, new float[4] { 0, 0, 0, 0 }));
        /*4*/CardInfoScript.AllCards.Add(new Card("Король", "Cards/King", "Background/KingBack", "Знаешь, я мог бы занять одну из должностей", "Сделать шутом", "Казнить", new float[4] { 0, 0, 0, 0 }, new float[4] { 0, 0, 0, 0 }));
        /*5*/CardInfoScript.AllCards.Add(new Card("Шут", "Cards/Joker", "Background/KingBack", "Знаешь что любят все короли? Пир!", "Давай устроим его", "Это пустая трата денег!", new float[4] { 0, -0.1F, -0.1F, 0.1F }, new float[4] { 0, 0.1F, 0.1F, -0.1F }));
        /*6*/CardInfoScript.AllCards.Add(new Card("Шут", "Cards/Joker", "Background/KingBack", "Было бы здорово немного развлечься и устроить настоящий турнир!", "Неплохая идея", "Хватит тратить мои деньги!", new float[4] { 0.2F, 0, -0.2F, 0 }, new float[4] { -0.2F, 0, +0.2F, 0 }));
        /*6*/CardInfoScript.AllCards.Add(new Card("Шут", "Cards/Joker", "Background/KingBack", "Этот священник со своей верой такой смешной", "Может быть хватит?", "Возможно", new float[4] { 0, 0, 0, 0 }, new float[4] { 0, 0, 0, 0 }));
        /*7*/CardInfoScript.AllCards.Add(new Card("Священник", "Cards/priest", "Background/PriestBack", "Мой Король, нам необходимо построить новый храм для увеличения вашей популярности", "Стройте", "Как-нибудь в другой раз", new float[4] { 0, 0, -0.2F, 0.1F }, new float[4] { 0, 0, 0.2F, -0.1F }));
        /*8*/CardInfoScript.AllCards.Add(new Card("Священник", "Cards/priest", "Background/PriestBack", "Мне кажется что придворный шут не очень рад мне", "Пустяки", "Я разберусь с этим", new float[4] { 0, 0, 0, 0 }, new float[4] { 0, 0, 0, 0 }));
        /*9*/CardInfoScript.AllCards.Add(new Card("Священник", "Cards/priest", "Background/PriestBack", "Мы могли бы привлечь людий на вшу сторону если бы оплатили расходы на праздник", "Сделаем это", "Только не сейчас", new float[4] { 0, 0, -0.3F, 0.3F }, new float[4] { 0, 0, 0.3F, -0.3F }));
        /*10*/CardInfoScript.AllCards.Add(new Card("Рыцарь", "Cards/Knight", "Background/KingBack", "Южные страные могут напасть, нужно увеличить армию", "Сейчас не самое время", "Да", new float[4] { +0.2f, 0, -0.1f, 0 }, new float[4] { -0.1f, 0, +0.1f, 0 }));
        /*11*/CardInfoScript.AllCards.Add(new Card("Рыцарь", "Cards/Knight", "Background/KingBack", "Группа людей оспаривает ваше право на трон", "Оставьте их", "Примите меры", new float[4] { -0.1f, 0, 0, +0.1f }, new float[4] { 0.1f, 0, 0, -0.1f }));
        /*12*/CardInfoScript.AllCards.Add(new Card("Рыцарь", "Cards/Knight", "Background/KingBack", "Северные страны напали на нас, необходимо нанести ответный удар", "Атакуйте", "Защищайтесь", new float[4] { -0.2f, 0, +0.2f, 0 }, new float[4] { -0.1f, 0, 0, 0 }));
    }

    void Update()
    {
        ShowCardInfo(CardInfoScript.AllCards[0]);
    }

    public void ShowCardInfo(Card card)
    {
        SelfCard = card;
        BackImg.sprite = SelfCard.path;
        Name.text = SelfCard.name;
        Task.text = SelfCard.task;
        TempBackImg.sprite = SelfCard.back_path;

    }
}


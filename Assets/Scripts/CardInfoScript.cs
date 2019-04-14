using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Card
{
    public string name;
    public Sprite path;
    public Sprite back_path;
    public string task;
    public string left_decision;
    public string right_decision;
    public float[] properties_left;
    public float[] properties_right;

    public Card(string name, string path, string back_path, string task, string left_decision, string right_decision, float[] properties_left, float[] properties_right)
    {
        this.name = name;
        this.task = task;
        this.path = Resources.Load<Sprite>(path);
        this.back_path = Resources.Load<Sprite>(back_path);
        this.left_decision = left_decision;
        this.right_decision = right_decision;
        this.properties_left = properties_left;
        this.properties_right = properties_right;
    }
}

public static class CardInfoScript
{
    public static Card SelfCard;
    public static List<Card> AllCards = new List<Card>();
}

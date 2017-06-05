using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text DisplayCaption;

    public static Score Current;

    public int TotalScore = 0;

    public void Start()
    {
        Current = this;
    }

    public void Update()
    {
        DisplayCaption.text = "Score: " + TotalScore;
    }
}

﻿/*
 * Jacob Zydorowicz, Anna Brueker
 * Project 2 Mole Mania
 * Controls display of score
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    void Start()
    {
        scoreText.text = "0000";
    }

    void Update()
    {
        scoreText.text = score.ToString(string.Format("000,000", score));
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;

#endif
using UnityEngine.Events;


public class ScoreValue : MonoBehaviour
{
    // Score
    public int score = 0;
    public Text Valuetext;

    // Progress bar
    public int actuel = 0;
    public int max = 40;
    public Image ProgressImage;
    public Text ProgressText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Progress = actuel == 0 ? 0 : (float)actuel / (float)max;
        ProgressImage.fillAmount = Progress;
        Valuetext.text = "Score : " + score.ToString();
        ProgressText.text = actuel.ToString() + "/" + max.ToString();
    }
}

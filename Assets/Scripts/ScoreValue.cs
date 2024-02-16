using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreValue : MonoBehaviour
{
    public int score = 0;

    public Text Valuetext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Valuetext.text = "Score : " + score.ToString();
    }
}

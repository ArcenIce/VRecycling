using UnityEngine;
using UnityEngine.UI;


public class ScoreValue : MonoBehaviour
{
    // Score
    public int score = 0;
    public Text Valuetext;

    // Progress bar
    private int actuel = 0;
    public Image ProgressImage;
    public Text ProgressText;
    public GameObject Interactables;
    private int max;

    // Start is called before the first frame update
    void Start()
    {
        max = Interactables.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        actuel = max - Interactables.transform.childCount;
        float Progress = actuel == 0 ? 0 : (float)actuel / (float)max;
        ProgressImage.fillAmount = Progress;
        Valuetext.text = "Score : " + score.ToString();
        ProgressText.text = actuel.ToString() + "/" + max.ToString();
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreValue : MonoBehaviour
{
    // Score
    public int score = 0;
    public Text Valuetext;

    // Progress bar
    public int actuel = 0;
    public Image ProgressImage;
    public Text ProgressText;
    public GameObject Interactables;
    private int max;

    // Loading de changement de scène
    public Loadingscreen sceneLoader;

    // Start is called before the first frame updater
    void Start()
    {
        max = Interactables.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        // actuel = max - Interactables.transform.childCount;
        float Progress = actuel == 0 ? 0 : (float)actuel / (float)max;
        ProgressImage.fillAmount = Progress;
        Valuetext.text = "Score : " + score.ToString();
        ProgressText.text = actuel.ToString() + "/" + max.ToString();

        if (actuel >= max)
        {
            sceneLoader.LoadScene("Fin");
        }
    }
}

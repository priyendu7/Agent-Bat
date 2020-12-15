
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    public Text scoreText;
    public Text finalScoreText;
    public float score;
    public static float startingTime;
    public float previousScore;

    // Start is called before the first frame update
    void Start()
    {
        previousScore = PlayerPrefs.GetFloat("PreviousScore", 0);
        PlayerPrefs.SetFloat("PreviousScore", 0);
        startingTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        score = Time.time-startingTime+ previousScore;
        scoreText.text = score.ToString("0");
        finalScoreText.text = score.ToString("0");

    }

}

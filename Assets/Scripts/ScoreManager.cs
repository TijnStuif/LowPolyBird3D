using UnityEngine;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public int score;
    [SerializeField] private UIDocument UIDocument;
    private Label scoreLabel;

    private void OnEnable()
    {
        scoreLabel = UIDocument.rootVisualElement.Q<Label>("ScoreText");
        score = 0;
        scoreLabel.text = "Score:" + score;

    }

    public void Enable()
    {
        gameObject.SetActive(true);
        enabled = true;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
        enabled = false;
    }

    public void ScoreLabelUpdate()
    {
        score += 1;
        scoreLabel.text = "Score: " + score.ToString();
    }

    public void SaveScore()
    {
        if (score > PlayerPrefs.GetInt("BestScore"))
        PlayerPrefs.SetInt("BestScore", score);
    }
}

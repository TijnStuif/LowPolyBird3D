using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private UIDocument UIDocument;
    [SerializeField] private ScoreManager scoreScreen;
    [SerializeField] AudioManager audioManager;
    private Label newScoreLabel;
    private Label highScoreLabel;

    private void Awake()
    {
        newScoreLabel = UIDocument.rootVisualElement.Q<Label>("CurrentScore");
        highScoreLabel = UIDocument.rootVisualElement.Q<Label>("HighScore");
    }

    private void Update()
    {
        CheckForSpacebarInput();
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
        highScoreLabel.text = "Highscore: " + PlayerPrefs.GetInt("BestScore").ToString();
        newScoreLabel.text = "Score: " + scoreScreen.score;
        audioManager.musicSource.Stop();
    }

    public void Enable()
    {
        gameObject.SetActive(true);
        scoreScreen.Disable();
    }

    public void Disable()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    private void CheckForSpacebarInput()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Disable();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

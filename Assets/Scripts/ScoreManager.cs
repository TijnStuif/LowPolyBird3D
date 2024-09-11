using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public float score = 0;
    [SerializeField] private UIDocument UIDocument;
    private Label scoreLabel;

    private void Start()
    {
        scoreLabel = UIDocument.rootVisualElement.Q<Label>("ScoreText");
    }

    public void ScoreLabelUpdate()
    {
        score += 1;
        scoreLabel.text = "Score: " + score;
    }
}

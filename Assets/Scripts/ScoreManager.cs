using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    private float score = 0;
    [SerializeField] private UIDocument UIDocument;
    private Label scoreLabel;

    private void OnEnable()
    {
        scoreLabel = UIDocument.rootVisualElement.Q<Label>("ScoreText");
    }

    public void ScoreLabelUpdate()
    {
        score += 1;
        scoreLabel.text = "Score: " + score.ToString();
        Debug.Log("Score: " + score);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
        enabled = true;
    }
}

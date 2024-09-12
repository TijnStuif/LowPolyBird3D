using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MainMenuEvents : MonoBehaviour
{
    [SerializeField] private UIDocument UIDocument;
    private Button startButton;

    private void OnEnable()
    {
        Time.timeScale = 0;
        startButton = UIDocument.rootVisualElement.Q<Button>("StartButton");
        startButton.RegisterCallback<ClickEvent>(OnStartButtonClicked);
    }

    private void OnDisable()
    {
        startButton.UnregisterCallback<ClickEvent>(OnStartButtonClicked);
    }

    private void OnStartButtonClicked(ClickEvent clickEvent)
    {
        Time.timeScale = 1;
        Debug.Log("Start button clicked");
    }
}

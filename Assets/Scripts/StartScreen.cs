using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class StartSceen : MonoBehaviour
{
    [SerializeField] private UIDocument UIDocument;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private ScoreManager scoreScreen;

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        CheckForSpacebarInput();
    }

    private void CheckForSpacebarInput()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Time.timeScale = 1;
            startScreen.SetActive(false);
            scoreScreen.Enable();
        }
    }

    
}

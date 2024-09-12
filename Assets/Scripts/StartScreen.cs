using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class StartSceen : MonoBehaviour
{
    [SerializeField] private UIDocument UIDocument;
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
            gameObject.SetActive(false);
            scoreScreen.Enable();
        }
    }

    
}

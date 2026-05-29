using UnityEngine;
using UnityEngine.InputSystem;

public class WindPanelToggle : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private bool isPanelOpen;

    public bool IsPanelOpen => isPanelOpen;

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            TogglePanel();
    }

    private void TogglePanel()
    {
        isPanelOpen = !isPanelOpen;

        panel.SetActive(isPanelOpen);

        Cursor.lockState =
            isPanelOpen
            ? CursorLockMode.None
            : CursorLockMode.Locked;

        Cursor.visible = isPanelOpen;
    }
}
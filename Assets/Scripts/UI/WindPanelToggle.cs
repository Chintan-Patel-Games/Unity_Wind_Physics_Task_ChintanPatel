using UnityEngine;

public class WindPanelToggle : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void TogglePanel() => panel.SetActive(!panel.activeSelf);
}
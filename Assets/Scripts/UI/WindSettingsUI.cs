using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindSettingsUI : MonoBehaviour
{
    [Header("Wind Controller")]
    [SerializeField] private DynamicWindController windController;

    [Header("Sliders")]
    [SerializeField] private Slider windStrengthSlider;
    [SerializeField] private Slider turbulenceSlider;
    [SerializeField] private Slider directionXSlider;
    [SerializeField] private Slider directionZSlider;

    [Header("Input Fields")]
    [SerializeField] private TMP_InputField windStrengthInput;
    [SerializeField] private TMP_InputField turbulenceInput;
    [SerializeField] private TMP_InputField directionXInput;
    [SerializeField] private TMP_InputField directionZInput;

    private void Start()
    {
        // Slider Listeners
        windStrengthSlider.onValueChanged.AddListener(OnWindStrengthSliderChanged);
        turbulenceSlider.onValueChanged.AddListener(OnTurbulenceSliderChanged);
        directionXSlider.onValueChanged.AddListener(OnDirectionXSliderChanged);
        directionZSlider.onValueChanged.AddListener(OnDirectionZSliderChanged);

        // Input Listeners
        windStrengthInput.onEndEdit.AddListener(OnWindStrengthInputChanged);
        turbulenceInput.onEndEdit.AddListener(OnTurbulenceInputChanged);
        directionXInput.onEndEdit.AddListener(OnDirectionXInputChanged);
        directionZInput.onEndEdit.AddListener(OnDirectionZInputChanged);

        UpdateAllInputFields();
    }

    #region Slider Callbacks

    private void OnWindStrengthSliderChanged(float value)
    {
        windController.SetWindStrength(value);
        windStrengthInput.text = value.ToString("F2");
    }

    private void OnTurbulenceSliderChanged(float value)
    {
        windController.SetWindTurbulence(value);
        turbulenceInput.text = value.ToString("F2");
    }

    private void OnDirectionXSliderChanged(float value)
    {
        windController.SetWindDirectionX(value);
        directionXInput.text = value.ToString("F2");
    }

    private void OnDirectionZSliderChanged(float value)
    {
        windController.SetWindDirectionZ(value);
        directionZInput.text = value.ToString("F2");
    }

    #endregion

    #region Input Callbacks

    private void OnWindStrengthInputChanged(string value)
    {
        if (float.TryParse(value, out float result))
            windStrengthSlider.value = result;
    }

    private void OnTurbulenceInputChanged(string value)
    {
        if (float.TryParse(value, out float result))
            turbulenceSlider.value = result;
    }

    private void OnDirectionXInputChanged(string value)
    {
        if (float.TryParse(value, out float result))
            directionXSlider.value = result;
    }

    private void OnDirectionZInputChanged(string value)
    {
        if (float.TryParse(value, out float result))
            directionZSlider.value = result;
    }

    #endregion

    private void UpdateAllInputFields()
    {
        windStrengthInput.text = windStrengthSlider.value.ToString("F2");
        turbulenceInput.text = turbulenceSlider.value.ToString("F2");
        directionXInput.text = directionXSlider.value.ToString("F2");
        directionZInput.text = directionZSlider.value.ToString("F2");
    }
}
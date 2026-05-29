using UnityEngine;

public class DynamicWindController : MonoBehaviour
{
    [Header("Wind Settings")]
    [SerializeField] private WindZone windZone;

    [Range(0.2f, 1f)]
    [SerializeField] private float windStrength = 0.3f;
    [Range(0.2f, 1f)]
    [SerializeField] private float windTurbulence = 0.7f;

    [Header("Wind Direction")]
    [SerializeField] private Vector3 windDirection = new Vector3(1f, 0f, 0f);

    [Header("Wind Gust Settings")]
    [SerializeField] private bool enableWindGusts = true;
    [Range(0.2f, 0.4f)]
    [SerializeField] private float gustStrengthMultiplier = 0.3f;
    [Range(0.2f, 0.6f)]
    [SerializeField] private float gustSpeed = 0.5f;

    private float gustNoise;

    public Vector3 WindDirection => windDirection.normalized;
    public float WindStrength => windStrength;

    private void Update()
    {
        SimulateWindGusts();
        UpdateWindZone();
    }

    private void SimulateWindGusts()
    {
        if (!enableWindGusts)
            return;

        gustNoise = Mathf.PerlinNoise(Time.time * gustSpeed, 0f);

        float gustValue = gustNoise * gustStrengthMultiplier;

        windZone.windMain = windStrength + gustValue;
    }

    private void UpdateWindZone()
    {
        if (windZone == null)
            return;

        windZone.windTurbulence = windTurbulence;

        windZone.transform.rotation = Quaternion.LookRotation(windDirection.normalized);
    }

    public void SetWindStrength(float value) => windStrength = value;
    public void SetWindTurbulence(float value) => windTurbulence = value;
    public void SetWindDirectionX(float value) => windDirection.x = value;
    public void SetWindDirectionZ(float value) => windDirection.z = value;
}
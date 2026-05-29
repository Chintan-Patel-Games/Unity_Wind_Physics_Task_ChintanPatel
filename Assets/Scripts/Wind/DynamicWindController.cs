using UnityEngine;

public class DynamicWindController : MonoBehaviour
{
    [Header("Wind Settings")]
    [SerializeField] private WindZone windZone;

    [SerializeField] private float windStrength = 1f;
    [SerializeField] private float windTurbulence = 0.5f;

    [Header("Wind Direction")]
    [SerializeField] private Vector3 windDirection = new Vector3(1f, 0f, 0f);

    public Vector3 WindDirection => windDirection.normalized;
    public float WindStrength => windStrength;

    private void Update()
    {
        UpdateWindZone();
    }

    private void UpdateWindZone()
    {
        if (windZone == null)
            return;

        windZone.windMain = windStrength;
        windZone.windTurbulence = windTurbulence;

        windZone.transform.rotation = Quaternion.LookRotation(windDirection.normalized);
    }

    public void SetWindStrength(float value)
    {
        windStrength = value;
    }

    public void SetWindDirectionX(float value)
    {
        windDirection.x = value;
    }

    public void SetWindDirectionZ(float value)
    {
        windDirection.z = value;
    }
}
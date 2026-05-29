using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WindAffectedObject : MonoBehaviour
{
    [SerializeField] private DynamicWindController windController;

    [SerializeField] private float windForceMultiplier = 5f;

    private Rigidbody rb;

    private void Awake() => rb = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        if (windController == null)
            return;

        Vector3 windForce =
            windController.WindDirection *
            windController.WindStrength *
            windForceMultiplier;

        rb.AddForce(windForce, ForceMode.Force);
    }
}
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class LeafParticleController : MonoBehaviour
{
    [SerializeField] private DynamicWindController windController;

    [SerializeField] private float windInfluence = 2f;

    private ParticleSystem particleSystemComponent;
    private ParticleSystem.VelocityOverLifetimeModule velocityModule;

    private void Awake()
    {
        particleSystemComponent = GetComponent<ParticleSystem>();
        velocityModule = particleSystemComponent.velocityOverLifetime;
    }

    private void Update()
    {
        if (windController == null)
            return;

        Vector3 windDirection = windController.WindDirection * windController.WindStrength * windInfluence;

        velocityModule.x = windDirection.x;
        velocityModule.z = windDirection.z;
    }
}
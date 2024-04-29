using UnityEngine;

public class SpeedTrailController : MonoBehaviour
{
    public ParticleSystem speedTrailParticles;

    void Start()
    {
        // Assicurati che le particelle siano inizialmente disattivate
        speedTrailParticles.Stop();
    }

    public void ActivateSpeedTrail()
    {
        // Attiva le particelle quando il power-up è attivo
        speedTrailParticles.Play();
    }

    public void DeactivateSpeedTrail()
    {
        // Disattiva le particelle quando il power-up è disattivato
        speedTrailParticles.Stop();
    }
}

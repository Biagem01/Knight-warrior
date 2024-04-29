using UnityEngine;

/*public class invincibilità : MonoBehaviour
{
    [Header("Power-Up Settings")]
    [SerializeField] private float invincibilityDuration = 20f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();

            if (playerHealth != null)
            {
                // Attiva l'invincibilità del giocatore per la durata specificata
                playerHealth.StartInvulnerabilityTimer(invincibilityDuration);

                // Disattiva l'oggetto del power-up (o distruggilo, a seconda delle tue esigenze)
                gameObject.SetActive(false);
            }
        }
    }
}*/
using UnityEngine;

public class bulletPower : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Chiamiamo la funzione CollectPowerUp quando il giocatore entra nel collider del power-up
            PlayerAttack playerAttack = collision.GetComponent<PlayerAttack>();
            if (playerAttack != null)
            {
                playerAttack.CollectPowerUp();
            }

            // Aggiungi qui ulteriori azioni, ad esempio la distruzione dell'oggetto power-up
            Destroy(gameObject);
        }
    }
}


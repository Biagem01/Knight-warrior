using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se il collider che entra è quello del giocatore
        if (other.CompareTag("Player"))
        {
            // Abilita una variabile nel giocatore per indicare che è sulla scatola
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.SetOnBox(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica se il collider che esce è quello del giocatore
        if (other.CompareTag("Player"))
        {
            // Disabilita la variabile nel giocatore per indicare che non è più sulla scatola
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.SetOnBox(false);
            }
        }
    }
}
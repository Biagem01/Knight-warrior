using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float bounceForce = 10f;
    private Animator trampolineAnimator;

    private void Start()
    {
        // Ottieni il componente Animator all'avvio
        trampolineAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se l'oggetto che ha collidato con il trampolino ha il tag "Player"
        if (other.CompareTag("Player"))
        {
            // Attiva l'animazione del trampolino
            ActivateTrampoline();

            // Applica una forza verticale al player per farlo saltare più in alto
            JumpPlayer(other.GetComponent<Rigidbody2D>());
        }
    }

    private void ActivateTrampoline()
    {
        // Attiva l'animazione del trampolino se presente l'Animator
        if (trampolineAnimator != null)
        {
            // Imposta il parametro booleano "IsActivated" su true
            trampolineAnimator.SetBool("IsActivated", true);

            Debug.Log("Trampoline activated!");
        }
    }

    private void JumpPlayer(Rigidbody2D playerRb)
    {
        // Applica una forza verticale al player per farlo saltare più in alto
        playerRb.velocity = new Vector2(playerRb.velocity.x, bounceForce);

        // Avvia la coroutine per resettare IsActivated dopo un breve ritardo
        StartCoroutine(ResetIsActivatedCoroutine());
    }

    private System.Collections.IEnumerator ResetIsActivatedCoroutine()
    {
        // Attendi per un breve ritardo
        yield return new WaitForSeconds(0.5f);

        // Riporta IsActivated a false per consentire nuove attivazioni
        trampolineAnimator.SetBool("IsActivated", false);
        Debug.Log("IsActivated reset!");
    }
}
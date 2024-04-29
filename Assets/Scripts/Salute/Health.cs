using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;


    [Header("Death Handling")]
     public bool isPlayer = true;

    
    [Header("Checkpoint Handling")]
    public bool hasCheckpoint = false;


    //private float invincibilityTimer;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
            SoundManager.instance.PlaySound(hurtSound);
        }
        else
        {
            if (!dead)
            {
                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;

                anim.SetBool("grounded", true);
                anim.SetTrigger("die");

                dead = true;
                SoundManager.instance.PlaySound(deathSound);
             if (isPlayer)
               {
                if (hasCheckpoint)
                    {
                        // Se il giocatore ha preso il checkpoint, respawn
                        Respawn();
                    }
                    else
                    {
                        // Se il giocatore non ha preso il checkpoint, carica la schermata di Game Over
                        Invoke("LoadGameOverScene", 0.8f);
                    }
               
                  
               }
               
                

            }
        }
    }

       private void LoadGameOverScene()
    {
        // Carica la scena di Game Over
        SceneManager.LoadScene("GameOverScreen");
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }
   /* private void Deactivate()
    {
        gameObject.SetActive(false);
    }
*/
    //Respawn
   public void Respawn()
{
    Debug.Log("Respawn called.");
    dead = false;
    AddHealth(startingHealth);
    anim.ResetTrigger("die"); // Resettare il trigger di morte
    anim.Play("idle"); // Avviare l'animazione di idle
    StartCoroutine(Invunerability());
    gameObject.SetActive(true);

    // Riattivare tutti i componenti collegati
    foreach (Behaviour component in components)
        component.enabled = true;
}
  

    


   

}
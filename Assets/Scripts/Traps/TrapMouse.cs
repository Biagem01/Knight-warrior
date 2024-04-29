using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsMouse : MonoBehaviour
{
    [SerializeField] private float damage;
    private Animator anim;
    private SpriteRenderer spriteRend;
    private bool triggered;
    private bool active;

    [Header("TrapsMouse Sound")]
    [SerializeField] private AudioClip FireTrapSound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            ActivateTrap();
        }
    }

    private void ActivateTrap()
    {
        // Attiva l'animazione della trappola
        anim.SetTrigger("activated");
    }

    public void ResetAnimationState()
    {
        // Reimposta lo stato dell'animazione
        anim.ResetTrigger("activated");
    }
}

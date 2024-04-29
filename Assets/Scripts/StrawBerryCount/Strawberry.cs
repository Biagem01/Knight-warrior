using UnityEngine;

public class Strawberry : MonoBehaviour
{
    [SerializeField] private int strawberryValue;  // Valore da assegnare al contatore delle fragole
    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);
            collision.GetComponent<StrawberryCounter>().CollectStrawberry(strawberryValue);
            gameObject.SetActive(false);
        }
    }
}

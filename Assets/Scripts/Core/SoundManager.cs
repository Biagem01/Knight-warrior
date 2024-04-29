using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    public AudioSource source; // Assegna l'AudioSource nell'Inspector di Unity

    private void Awake()
    {
        // Mantieni questo oggetto anche quando cambi di scena
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        // Assicurati che l'AudioSource non venga distrutto quando cambi di scena
        if (source == null)
        {
            Debug.LogError("L'AudioSource non è stato assegnato nell'Inspector.");
        }
    }

    public void PlaySound(AudioClip _sound)
    {
        if (source != null)
        {
            source.PlayOneShot(_sound);
        }
        else
        {
            Debug.LogError("L'AudioSource non è stato assegnato nell'Inspector.");
        }
    }
}

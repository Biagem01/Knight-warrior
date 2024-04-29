using UnityEngine;

public class GameManagerSound : MonoBehaviour
{
    private float musicVolume = 0.5f;

    void Awake()
    {
        // Assicurati che questo oggetto persista tra le scene
        DontDestroyOnLoad(this.gameObject);
    }

    // Restituisci il volume della musica
    public float GetMusicVolume()
    {
        return musicVolume;
    }

    // Imposta il volume della musica
    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        // Salva il volume corrente nelle preferenze del giocatore
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}

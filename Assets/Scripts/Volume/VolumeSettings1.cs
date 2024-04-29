using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings1 : MonoBehaviour
{
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private Slider musicSlider; // Assicurati di trascinare lo slider nell'Inspector di Unity

    void Start()
    {
        

        // Associa direttamente l'evento onValueChanged dello slider alla funzione SetMusicVolume
        musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });

        // Inizializza lo slider al valore corrente del volume
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        // Imposta il volume dell'AudioSource allo stesso valore
        musicAudioSource.volume = musicSlider.value;

        DontDestroyOnLoad(musicAudioSource.gameObject);
        DontDestroyOnLoad(musicSlider.gameObject);
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        // Aggiorna il volume dell'AudioSource
        musicAudioSource.volume = volume;
        // Salva il volume corrente nelle preferenze del giocatore
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}

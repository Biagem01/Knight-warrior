using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private const float DefaultValue = 0.5f;
    
    public void GoToDifficulty()
    {
        SceneManager.LoadScene("DifficultyScene");
    }

    public void GotoMenu()
    {
        // In un qualsiasi script in qualsiasi scena
        float volumeValue = PlayerPrefs.GetFloat("MusicVolume", DefaultValue);
        Debug.Log($"Il volume attuale è: {volumeValue}");

         Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
    }
}

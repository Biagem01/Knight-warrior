using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timeElapsed = 0f;
    private float levelTimeLimit = 120f; // 300 secondi, corrispondenti a 5 minuti

    void Update()
    {
        // Aggiorna il tempo trascorso
        timeElapsed += Time.deltaTime;

        // Aggiorna il timer nella UI
        UpdateTimerUI();

        // Controlla se il tempo limite del livello è stato superato
        if (timeElapsed > levelTimeLimit)
        {
            // Gestisci il completamento del livello o altre azioni
            Debug.Log("Il tempo limite è stato superato!");
            SceneManager.LoadScene("GameOverScreen");

        }
    }

    void UpdateTimerUI()
    {
        // Calcola i minuti e i secondi rimanenti
        float timeRemaining = Mathf.Max(0f, levelTimeLimit - timeElapsed);
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Formatta il tempo rimanente come stringa
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Aggiorna il testo della UI
        if (timerText != null)
        {
            timerText.text = "Tempo: " + timerString;
        }
    }
}

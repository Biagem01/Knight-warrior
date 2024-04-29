using UnityEngine;
using UnityEngine.SceneManagement;
//using YourNamespace.Player;
public class PauseManager : MonoBehaviour
{
    public Canvas pauseGame;
   // public LeaderboardManager leaderboardManager;

    
    

    void Start()
    {
         
        // Assicurati che la Canvas di pausa sia disattivata all'inizio
        if (pauseGame != null)
            pauseGame.enabled = false;
    }

    void Update()
    {
        
        // Rileva la pressione del tasto Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Attiva o disattiva la Canvas di pausa
            TogglePause();
        }
    }
void TogglePause()
{
    // Inverti lo stato dell'oggetto pauseGame
    if (pauseGame != null)
    {
        pauseGame.enabled = !pauseGame.enabled;
        // Pausa o riprendi il gioco a seconda dello stato attuale
        Time.timeScale = (pauseGame.enabled) ? 0 : 1;
    }
}

    public void RestartGame()
    {
        Time.timeScale = 1f; // Assicurati che il tempo torni a fluire normalmente
        SceneManager.LoadScene("StartScreen");

    }

    


    


} 
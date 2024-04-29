using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelCompleted : MonoBehaviour
{
    public string endSceneName = "EndScreen"; 
    private StrawberryCounter strawberryCounter;
    private HighscoreTable highscoreTable;

    private void Start()
    {
        strawberryCounter = FindObjectOfType<StrawberryCounter>();
        highscoreTable = GameManager.Instance.highscoreTable;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        Debug.Log("Livello completato!");

          if (strawberryCounter == null)
        {
            Debug.LogError("StrawberryCounter non trovato!");
            return;
        }
        else {
            Debug.Log("StrawberryCounter trovato!");

        }
        int strawberriesCollected = strawberryCounter.GetStrawberryCount();
        Debug.Log("Fragole raccolte: " + strawberriesCollected);

         if (highscoreTable == null)
        {
            Debug.LogError("HighscoreTable non trovato!");
            return;
        }


        Debug.Log("Aggiunta dello score al punteggio del giocatore: " + strawberriesCollected);
        highscoreTable.AddPlayerScoreBasedOnStrawberries(strawberriesCollected);

        SceneManager.LoadScene(endSceneName);
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyScript : MonoBehaviour
{
    public void StartGameEasy()
    {
       SceneManager.LoadScene("Facile");
    }

    public void StartGameMedium()
    {
        SceneManager.LoadScene("Normale");
    }

    public void StartGameHard()
    {
        SceneManager.LoadScene("Difficile");
    }

    
}

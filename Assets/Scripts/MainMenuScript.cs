using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void CaricaLivelloFacile()
    {
        Debug.Log("livello caricato");
        StartGame(1, 1, 3);
        
    }

    public void CaricaLivelloNormale()
    {
        SceneManager.LoadScene("LivelloNormale");
    }

    public void CaricaLivelloDifficile()
    {
        SceneManager.LoadScene("LivelloDifficile");
    }

      private void StartGame(int difficulty, int enemyCount, int trapCount)
    {
        //PlayerPrefs.SetInt("Difficulty", difficulty);
        //PlayerPrefs.SetInt("EnemyCount", enemyCount);
        //PlayerPrefs.SetInt("TrapCount", trapCount);
       // PlayerPrefs.SetInt("CoinCount", coinCount);
       

        SceneManager.LoadScene("GameScene");
    }
}

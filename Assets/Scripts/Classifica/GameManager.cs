using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Nella classe GameManager o in un altro oggetto persistente
public class GameManager : MonoBehaviour
{
    public HighscoreTable highscoreTable;

    private static GameManager _instance;
    
private void Awake()
{
    Debug.Log("GameManager Awake!");
    if (_instance == null)
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);

        // Trova e assegna HighscoreTable nella scena
        highscoreTable = FindObjectOfType<HighscoreTable>();
        if (highscoreTable == null)
        {
            Debug.LogError("HighscoreTable non trovato nella scena!");
        }
        else
        {
            Debug.Log("HighscoreTable trovato e assegnato correttamente.");
        }
    }
    else
    {
        Destroy(gameObject);
    }
}


    public static GameManager Instance
    {
        get { return _instance; }
    }
}
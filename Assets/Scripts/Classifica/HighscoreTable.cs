using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class HighscoreTable : MonoBehaviour {

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    public int maxHighscoreEntriesToShow = 10;

   private void Awake() {
    entryContainer = transform.Find("highscoreEntryContainer");
    entryTemplate = entryContainer.Find("highscoreEntryTemplate");

    entryTemplate.gameObject.SetActive(false);


    //ResetHighscoreTable();

    


    

    // Load saved Highscores
    string jsonString = PlayerPrefs.GetString("highscoreTable");
    Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

    if (highscores == null) {
        // There's no stored table, initialize
        Debug.Log("Initializing table with default values...");
        highscores = new Highscores() {
            highscoreEntryList = new List<HighscoreEntry>()
        };
    }

    // Sort the entries
    highscores.highscoreEntryList.Sort((a, b) => b.score.CompareTo(a.score));

    // Save updated Highscores
    string json = JsonUtility.ToJson(highscores);
    PlayerPrefs.SetString("highscoreTable", json);
    PlayerPrefs.Save();

    // Display highscores
    highscoreEntryTransformList = new List<Transform>();
    int count = 0;
    foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
        if(count >= maxHighscoreEntriesToShow){
            break;
        }
        CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        count++;
    }
}



    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
         
         
       
        float templateHeight = 31f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank) {
        default:
            rankString = rank + "TH"; break;

        case 1: rankString = "1ST"; break;
        case 2: rankString = "2ND"; break;
        case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        // Set background visible odds and evens, easier to read
        entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);
        
        // Highlight First
        if (rank == 1) {
            entryTransform.Find("posText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("scoreText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("nameText").GetComponent<Text>().color = Color.green;
        }

       

        transformList.Add(entryTransform);
    }

     


    private void AddHighscoreEntry(int score, string name) {
    // Load saved Highscores
    string jsonString = PlayerPrefs.GetString("highscoreTable");
    Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

    if (highscores == null) {
        // There's no stored table, initialize
        highscores = new Highscores() {
            highscoreEntryList = new List<HighscoreEntry>()
        };
    }

    // Create HighscoreEntry
    HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

    // Add new entry to Highscores
    highscores.highscoreEntryList.Add(highscoreEntry);

    Debug.Log("Highscore entry added. Total entries: " + highscores.highscoreEntryList.Count);

    // Sort the entries
    highscores.highscoreEntryList.Sort((a, b) => b.score.CompareTo(a.score));

    // Save updated Highscores
    string json = JsonUtility.ToJson(highscores);
    PlayerPrefs.SetString("highscoreTable", json);
    PlayerPrefs.Save();

    Debug.Log("Highscores saved.");
}

  public void AddPlayerScoreBasedOnStrawberries(int score) {
        AddHighscoreEntry(score, "Player"); // Aggiungi il giocatore con uno score basato sulle fragole raccolte
    }




    


    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }

    /*
     * Represents a single High score entry
     * */
    [System.Serializable] 
    private class HighscoreEntry {
        public int score;
        public string name;
    }


    // Aggiungi questo metodo per svuotare completamente la classifica
private void ResetHighscoreTable() {
    // Crea una nuova lista vuota di punteggi
    Highscores highscores = new Highscores() {
        highscoreEntryList = new List<HighscoreEntry>()
    };

    // Converti la lista in formato JSON e salvala
    string json = JsonUtility.ToJson(highscores);
    PlayerPrefs.SetString("highscoreTable", json);
    PlayerPrefs.Save();

    // Rimuovi tutti gli elementi UI della classifica
    foreach (Transform child in entryContainer) {
        Destroy(child.gameObject);
    }
}

}

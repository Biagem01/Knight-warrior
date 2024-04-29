using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StrawberryCounter : MonoBehaviour
{
    private static int strawberryCount;

    public TextMeshProUGUI strawberryText;

    private void Start()
    {
        // Azzera il contatore all'avvio di ogni livello
        ResetStrawberryCount();
        UpdateStrawberryCountText();
    }

    public void CollectStrawberry(int value)
    {
        Debug.Log("Fragole raccolte: " + strawberryCount);
        strawberryCount += value;
        UpdateStrawberryCountText();
    }

    public int GetStrawberryCount()
    {
        return strawberryCount;
    }

    private void UpdateStrawberryCountText()
    {
        strawberryText.text = "Strawberries: " + strawberryCount.ToString();
    }

    private void ResetStrawberryCount()
    {
        strawberryCount = 0;
    }
}

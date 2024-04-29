// MainMenuController.cs
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public void SetControlTypeWASD()
    {
        playerMovement.wasd = true; // Imposta il movimento su WASD

       
        Debug.Log("SetControlTypeWASD called. wasd set to true");
        
    }

    public void SetControlTypeArrows()
    {
        playerMovement.wasd = false; // Imposta il movimento sulle frecce
        
        Debug.Log("SetControlTypeArrows called. wasd set to false");
        

    }
}

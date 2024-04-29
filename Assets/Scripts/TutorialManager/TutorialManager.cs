using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutorialScreens;
    private int currentScreenIndex = 0;

    private void Start()
    {
        ShowCurrentScreen();
    }

    private void ShowCurrentScreen()
    {
        // Nascondi tutte le schermate del tutorial
        foreach (GameObject screen in tutorialScreens)
        {
            screen.GetComponent<CanvasGroup>().alpha = 0;
            screen.GetComponent<CanvasGroup>().interactable = false;
            screen.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        // Mostra solo la schermata corrente
        tutorialScreens[currentScreenIndex].GetComponent<CanvasGroup>().alpha = 1;
        tutorialScreens[currentScreenIndex].GetComponent<CanvasGroup>().interactable = true;
        tutorialScreens[currentScreenIndex].GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void ShowNextScreen()
    {
        // Passa alla schermata successiva
        currentScreenIndex = (currentScreenIndex + 1) % tutorialScreens.Length;
        ShowCurrentScreen();
    }

    public void ShowPreviousScreen()
    {
        // Passa alla schermata precedente
        currentScreenIndex = (currentScreenIndex - 1 + tutorialScreens.Length) % tutorialScreens.Length;
        ShowCurrentScreen();
    }
}

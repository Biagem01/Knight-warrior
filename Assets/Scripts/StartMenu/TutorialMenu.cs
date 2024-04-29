using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{
    

    public void GotoTutorial()
    {
        SceneManager.LoadScene("TutorialScreen");

    }

}
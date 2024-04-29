using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarClassifica : MonoBehaviour
{

      public void GoToClassifica()
    {
        SceneManager.LoadScene("GameHighScore_Table");
    }
   
}

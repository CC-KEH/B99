using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void quitGame(){
        Debug.Log("khatam tata byebye");
        Application.Quit();
    }
}

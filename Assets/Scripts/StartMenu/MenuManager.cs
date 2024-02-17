using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void loadCreate(){
        SceneManager.LoadScene("Create");
    }
    public void quit(){
        Debug.Log("Quit");
        Application.Quit();
    }
}

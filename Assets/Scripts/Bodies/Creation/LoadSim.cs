using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSim : MonoBehaviour
{
    public void load(){
        SceneManager.LoadScene("Sim");
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int camCount;
    public Object[] cameras;
    int index = 0;

    GameObject planetInfo;

    public GameObject[] bodies;
    GameObject[] bodyArr;

    private void Awake() {
        planetInfo = GameObject.FindGameObjectWithTag("BodyInfo");
    }

    private void Start() {
        planetInfo.SetActive(false);
    }

    private void Update() {

        bodies = new GameObject[GameObject.FindGameObjectsWithTag("Body").Length];
        bodyArr = GameObject.FindGameObjectsWithTag("Body");

        camSwap();
        //showInfo();
    }

    // void showInfo(){
    //     if(ToggleInfo.show){
    //         planetInfo.SetActive(true);
    //     }
    // }

    void camSwap(){
        int arrLimiter = 0;
        int n = 0;
        camCount = Camera.allCameras.Length; //Get how many cameras there are in the scene
        cameras = FindObjectsOfType<Camera>();

        if (camCount >= 1){ //Only works if there's more than one camera
            arrLimiter = camCount - 1;
            
            //Changes the camera
            if (Input.GetKeyDown(KeyCode.RightBracket)){ //Keyboard Input
                index++;
                if (index > arrLimiter){
                    index = arrLimiter;
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftBracket)){ //Keyboard Input
                index--;
                if(index < 0){
                    index = 0;
                }
            }

            while (camCount >= 1){//Only works if theres more than 1 camera in the scene
                while (index != n){//Allows to disable every other camera
                    for (n = 0; n < cameras.Length; n++) //Disables every camera
                    {
                        cameras[n].GetComponent<Camera>().enabled = false;
                    }

                    break;
                }
                cameras[index].GetComponent<Camera>().enabled = true;

                if(cameras[index].name == "ExteriorCam"){
                    CamMove.isActive = true;
                }else{
                    CamMove.isActive = true;
                }
                break;
            }
        }
    }

    // public void closePlanetInfo(){
    //     ToggleInfo.show = false;
    //     planetInfo.SetActive(false);
    // }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int camCount;
    public Object[] cameras;
    public Object[] gravObj;
    int index = 0;
    public bool STOP;

    private void Update() {
        camSwap();
        //_STOP();
    }

    void _STOP(){
        gravObj = FindObjectsOfType<Gravity>();

        if(!STOP){
            for (int i = 0; i < gravObj.Length; i++)
            {
                gravObj[i].GetComponent<Gravity>().enabled = true;
            }
        }else{
            for (int i = 0; i < gravObj.Length; i++)
            {
                gravObj[i].GetComponent<Gravity>().enabled = false;
            }
        }
    }

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
}

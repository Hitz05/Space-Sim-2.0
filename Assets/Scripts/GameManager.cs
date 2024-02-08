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

    private void Awake() {
        planetInfo = GameObject.FindGameObjectWithTag("BodyInfo");
    }

    private void Start() {
        planetInfo.SetActive(false);
        StartCoroutine(setUpCreate());
    }

    private void Update() {
        camSwap();
        showInfo();
        setBodies();
    }

    void setBodies(){
        bodies = new GameObject[GameObject.FindGameObjectsWithTag("Body").Length];
        GameObject[] bodyArr = GameObject.FindGameObjectsWithTag("Body");

        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i] = bodyArr[i];
        }

        StartCoroutine(setUpCreate());
    }

    IEnumerator setUpCreate(){
        yield return new WaitForEndOfFrame();
        while(bodies.Length != 0){
            for (int i = 0; i < bodies.Length; i++)
            {
                if(BodyCreation.creating){
                    bodies[i].GetComponent<Gravity>().enabled = false;
                    bodies[i].GetComponent<ToggleInfo>().enabled = false;
                }else{
                    bodies[i].GetComponent<Gravity>().enabled = true;
                    bodies[i].GetComponent<ToggleInfo>().enabled = true;

                    if(bodies[i].GetComponent<Gravity>().isStar){
                        bodies[i].GetComponent<Gravity>().enabled = false;
                    }
                }
            }

            break;
        }
    }

    void showInfo(){
        if(ToggleInfo.show){
            planetInfo.SetActive(true);
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

    public void closePlanetInfo(){
        ToggleInfo.show = false;
        planetInfo.SetActive(false);
    }
}

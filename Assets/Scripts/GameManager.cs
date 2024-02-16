using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int camCount;
    public Object[] cameras;
    int index = 0;

    GameObject planetInfo;
    Text nameBox, velBox, massBox, densBox, gBox;

    public GameObject[] bodies;
    GameObject[] bodyArr;

    private void Awake() {
        planetInfo = GameObject.FindGameObjectWithTag("BodyInfo");

        nameBox = GameObject.FindGameObjectWithTag("Name").GetComponent<Text>();
        velBox = GameObject.FindGameObjectWithTag("velInfo").GetComponent<Text>();
        gBox = GameObject.FindGameObjectWithTag("gInfo").GetComponent<Text>();
        massBox = GameObject.FindGameObjectWithTag("massInfo").GetComponent<Text>();
        densBox = GameObject.FindGameObjectWithTag("denInfo").GetComponent<Text>();
    }

    private void Start() {
        planetInfo.SetActive(false);
    }

    private void Update() {

        bodies = new GameObject[GameObject.FindGameObjectsWithTag("Body").Length];
        bodyArr = GameObject.FindGameObjectsWithTag("Body");

        for (int i = 0; i < bodyArr.Length; i++)
        {
            if(bodyArr[i].gameObject.GetComponent<ToggleInfo>().onBody){
                if(bodyArr[i].GetComponent<ToggleInfo>().show){
                    planetInfo.SetActive(true);
                    GetSetInfo();
                }
            }
        }
        camSwap();
    }

    void resetInfo(){
        
    }

    public void GetSetInfo(){
        string b_name; //Name of body
        float velocity, g, dens, mass;

        for (int i = 0; i < bodyArr.Length; i++)
        {
            if(bodyArr[i].gameObject.GetComponent<ToggleInfo>().onBody){
                b_name = bodyArr[i].name;
                velocity = Mathf.Sqrt(bodyArr[i].GetComponent<Gravity>().currentVel.sqrMagnitude) * 1000;
                mass = bodyArr[i].GetComponent<Gravity>().getMass();
                g = bodyArr[i].GetComponent<Gravity>().calcAg();
                dens = bodyArr[i].GetComponent<Gravity>().b_density * 100f;

                nameBox.text = b_name;
                velBox.text = "v: " + velocity + " m/s";
                gBox.text = "a: " + g + " G";
                massBox.text = "m: " + mass + " MKg";
                densBox.text = "ρ : " + dens + " Kgm^3";
            }
        }
    }
    
    public void closePlanetInfo(){
        planetInfo.SetActive(false);
        for (int i = 0; i < bodyArr.Length; i++)
        {
            if(bodyArr[i].GetComponent<ToggleInfo>().show){
                bodyArr[i].GetComponent<ToggleInfo>().show = false;
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

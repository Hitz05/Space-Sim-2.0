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
    Text nameBox, velBox, massBox, densBox, gBox, distBox;

    public GameObject selBody; //Selected body
    public static GameObject selBodyOut;

    public GameObject[] bodies;
    GameObject[] bodyArr;
    

    private void Awake() {
        planetInfo = GameObject.FindGameObjectWithTag("BodyInfo");

        nameBox = GameObject.FindGameObjectWithTag("Name").GetComponent<Text>();
        velBox = GameObject.FindGameObjectWithTag("velInfo").GetComponent<Text>();
        gBox = GameObject.FindGameObjectWithTag("gInfo").GetComponent<Text>();
        massBox = GameObject.FindGameObjectWithTag("massInfo").GetComponent<Text>();
        densBox = GameObject.FindGameObjectWithTag("denInfo").GetComponent<Text>();
        distBox = GameObject.FindGameObjectWithTag("dist").GetComponent<Text>();
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
        liveInfo();
        camSwap();

        selBodyOut = selBody;
    }

    void liveInfo(){
        float velocity;
        double distance;

        while(selBody != null){
            velocity = Mathf.Round(Mathf.Sqrt(selBody.GetComponent<Gravity>().currentVel.sqrMagnitude) * 1000) * 100 / 100;
            distance = System.Math.Round(selBody.GetComponent<Gravity>().dist2Star(), 0);

            velBox.text = "v: " + velocity + " m/s";
            distBox.text = "R: " + distance + " Km";

            break;
        }
    }

    public void GetSetInfo(){
        string b_name; //Name of body
        float dens;
        double g, mass;

        for (int i = 0; i < bodyArr.Length; i++)
        {
            if(bodyArr[i].gameObject.GetComponent<ToggleInfo>().onBody){
                
                selBody = bodyArr[i];

                b_name = bodyArr[i].name;

                mass = bodyArr[i].GetComponent<Gravity>().getMass() * 10;
                mass = System.Math.Round(mass, 1);

                g = bodyArr[i].GetComponent<Gravity>().calcAg();
                g = System.Math.Round(g, 2);

                dens = bodyArr[i].GetComponent<Gravity>().b_density * 100f;

                nameBox.text = b_name;
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

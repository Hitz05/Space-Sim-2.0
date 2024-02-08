using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ToggleInfo : MonoBehaviour
{

    MeshRenderer m_Rend;

    Color mouseOver = Color.magenta;
    Color originalCol;

    GameObject massInfo, gInfo, velInfo, Name, denInfo,selectedBody;

    public static bool show = false;

    private void Start() {
        m_Rend = gameObject.GetComponent<MeshRenderer>();
        originalCol = m_Rend.material.color;
        massInfo = GameObject.FindGameObjectWithTag("massInfo");
        gInfo = GameObject.FindGameObjectWithTag("gInfo");
        velInfo = GameObject.FindGameObjectWithTag("velInfo");
        Name = GameObject.FindGameObjectWithTag("Name");
        denInfo = GameObject.FindGameObjectWithTag("denInfo");

    }

    private void OnMouseOver() {
        m_Rend.material.color = mouseOver;
        if(Input.GetMouseButton(0) && !BodyCreation.creating){
            //Toggle Canvas with info box
            selectedBody = gameObject;
            show = true;
            setValues();
        }else if(Input.GetMouseButton(1) && BodyCreation.creating){
            StartCoroutine(destroy());
        }
    }

    IEnumerator destroy(){
        m_Rend.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
    
    private void OnMouseExit() {
        m_Rend.material.color = originalCol;
    }


    void setValues(){
        float selMass, selG, selVel, selDen;
        string name;
        selMass = selectedBody.GetComponent<Gravity>().getMass();
        selG = Mathf.Round(selectedBody.GetComponent<Gravity>().calcAg() * 10f)  * 0.1f;
        selVel = Mathf.Round(selectedBody.GetComponent<Gravity>().currentVel.sqrMagnitude * 10f) * 0.1f;
        name = selectedBody.gameObject.name;
        selDen = selectedBody.gameObject.GetComponent<Gravity>().b_density;

        Name.GetComponent<Text>().text = "Name: " + name;
        massInfo.GetComponent<Text>().text = "m: " + selMass * 10 + " MKg";
        gInfo.GetComponent<Text>().text = "acc: " + selG + " G";
        velInfo.GetComponent<Text>().text = "v: " + selVel * 100 + "m/s";
        denInfo.GetComponent<Text>().text = "ρ: " + selDen * 100 + "Kg/m^3";
    }
}

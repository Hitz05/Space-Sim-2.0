using UnityEngine;
using UnityEngine.UI;

public class ToggleInfo : MonoBehaviour
{

    MeshRenderer m_Rend;

    Color mouseOver = Color.magenta;
    Color originalCol;

    GameObject selectedBody;
    GameObject textBox, massInfo, gInfo, velInfo;

    private void Start() {
        m_Rend = gameObject.GetComponent<MeshRenderer>();
        originalCol = m_Rend.material.color;
        textBox = GameObject.FindGameObjectWithTag("BodyInfo");
        massInfo = GameObject.FindGameObjectWithTag("massInfo");
        gInfo = GameObject.FindGameObjectWithTag("gInfo");
        velInfo = GameObject.FindGameObjectWithTag("velInfo");
    }

    private void Update() {

    }

    private void OnMouseOver() {
        m_Rend.material.color = mouseOver;
        if(Input.GetMouseButton(0)){
            //Toggle Canvas with info box
            selectedBody = gameObject;
            setValues();
        }
    }

    void setValues(){
        float selMass, selG, selVel;
        selMass = selectedBody.GetComponent<Gravity>().getMass();
        selG = Mathf.Round(selectedBody.GetComponent<Gravity>().calcAg());
        selVel = Mathf.Round(selectedBody.GetComponent<Gravity>().currentVel.sqrMagnitude);

        massInfo.GetComponent<Text>().text = "Mass: " + selMass * 100 + " MKg";
        gInfo.GetComponent<Text>().text = "a: " + selG + " g";
        velInfo.GetComponent<Text>().text = "v: " + selVel * 100 + "m/s";

    }

    private void OnMouseExit() {
        m_Rend.material.color = originalCol;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ToggleInfo : MonoBehaviour
{

    MeshRenderer m_Rend;

    Color mouseOver = Color.magenta;
    Color originalCol;

    GameObject selectedBody;
    GameObject massInfo, gInfo, velInfo, Name;

    private void Start() {
        m_Rend = gameObject.GetComponent<MeshRenderer>();
        originalCol = m_Rend.material.color;
        massInfo = GameObject.FindGameObjectWithTag("massInfo");
        gInfo = GameObject.FindGameObjectWithTag("gInfo");
        velInfo = GameObject.FindGameObjectWithTag("velInfo");
        Name = GameObject.FindGameObjectWithTag("Name");
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
        string name;
        selMass = selectedBody.GetComponent<Gravity>().getMass();
        selG = Mathf.Round(selectedBody.GetComponent<Gravity>().calcAg() * 10f)  * 0.1f;
        selVel = Mathf.Round(selectedBody.GetComponent<Gravity>().currentVel.sqrMagnitude * 10f) * 0.1f;
        name = selectedBody.gameObject.name;

        Name.GetComponent<Text>().text = "Name: " + name;
        massInfo.GetComponent<Text>().text = "m: " + selMass * 10 + " Kg";
        gInfo.GetComponent<Text>().text = "acc: " + selG + " G";
        velInfo.GetComponent<Text>().text = "v: " + selVel * 100 + "m/s";
    }

    private void OnMouseExit() {
        m_Rend.material.color = originalCol;
    }

    public void closeMenu(){
        Debug.Log("Close");
    }
}

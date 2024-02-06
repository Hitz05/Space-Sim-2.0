using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToggleInfo : MonoBehaviour
{

    MeshRenderer m_Rend;
    Color mouseOver = Color.magenta;
    Color originalCol;
    bool toggleBox = false;
    GameObject textBox;

    private void Start() {
        m_Rend = gameObject.GetComponent<MeshRenderer>();
        originalCol = m_Rend.material.color;
        textBox = GameObject.FindGameObjectWithTag("BodyInfo");
    }

    private void Update() {
        boxToggle();
    }
    
    void boxToggle(){
        if(toggleBox){
            textBox.gameObject.SetActive(true);
        }else if(!toggleBox && textBox.activeInHierarchy == true){
            textBox.gameObject.SetActive(false);
        }
    }

    private void OnMouseOver() {
        m_Rend.material.color = mouseOver;
        if(Input.GetMouseButton(0)){
            //Toggle Canvas with info box
            Debug.Log(gameObject.name);
            toggleBox = !toggleBox;
            textBox.GetComponent<Text>().text = "Hello World";
        }
    }
    private void OnMouseExit() {
        m_Rend.material.color = originalCol;
        textBox.GetComponent<Text>().text = "Off";
    }
}

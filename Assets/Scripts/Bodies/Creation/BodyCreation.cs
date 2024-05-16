using System;
using UnityEngine;
using UnityEngine.UI;

public class BodyCreation : MonoBehaviour
{
    float r; //Radius
    public Slider radiusSel;
    public Text rText;
    float rVal;
    float solarRadius = 10f;

    float p; //Density
    public Slider densSel;
    public Text pText;
    float pVal;
    

    public static bool isCreating = false;

    public GameObject tempStar;

    private void Start() {
        isCreating = true;
    }
    
    private void Update() {
        //Debug.Log(starRadius());
        rVal = radiusSel.value;
        pVal = densSel.value;

        tempStar = GameObject.FindGameObjectWithTag("Star");

        setRadius();
        setDensity();
    }

    public float starRadius(){
        float factor = 0;

        //When value > 0, 1 = 1.01, when val < 0, - = 0.99
        while(rVal != 0){
            if(rVal > 0){
                factor = (rVal + 100) / 100;
            }
            else if(rVal < 0){
                
                factor = (-rVal - 1000) / -10000;
            }
            break;
        }

        r = factor * solarRadius;
        rText.text = "Radius: " + r.ToString("F1") + "Rs [Mm]";
        return r;
    }

    public void setRadius(){
        if(tempStar != null){
            tempStar.GetComponent<Gravity>().enabled = true;
            tempStar.GetComponent<Gravity>().b_radius = starRadius();
        }
    }

    public float starDensity(){
        p = pVal / 100;

        pText.text = "Denisty: " + (p*100).ToString("F1") + "[Kg m^3]";
        return p;
    }

    void setDensity(){
        if(tempStar != null){
            tempStar.GetComponent<Gravity>().enabled = true;
            tempStar.GetComponent<Gravity>().b_density = starDensity();
        }
    }
}
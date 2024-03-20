using UnityEngine;
using UnityEngine.UI;

public class BodyCreation : MonoBehaviour
{
    float r;
    public Slider radiusSel;
    public Text rText;

    float solarRadius = 10f;
    float val;
    
    private void Update() {
        //Debug.Log(makeRadius());
        val = radiusSel.value;
    }

    public float starRadius(){
        float factor = 0;

        //When value > 0, 1 = 1.01, when val < 0, - = 0.99
        while(val != 0){
            if(val > 0){
                factor = (val + 100) / 100;
            }
            else if(val < 0){
                
                factor = (-val - 1000) / -10000;
            }
            break;
        }

        r = factor * solarRadius;
        rText.text = "Radius: " + r.ToString("F1") + "Rs [Mm]";
        return r;
    }
}
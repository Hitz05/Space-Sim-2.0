using Unity.VisualScripting;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    float G = 1;
    Vector3 scaleChange;

    //b_ Is for bodies
    [Header("Body Properties")]
    public int velocity = 0;
    public float b_radius = 1;
    public float b_density; //Will look into this
    float b_Volume;
    float b_Mass;
    float b_Ag; //Accel due to gravity

    Rigidbody rb;
    public Gravity[] body;

    [Header("Gravity Param")]
    float r; //Distance between 2 bodies
    Vector3 Fg; //Force due to gravity
    Vector3 initialVel, currentVel;

    private void Awake() {
        calcAg();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    float calcAg(){
        //Ag = GM/b_radius^2
        b_Ag = G * getMass() / Mathf.Pow(b_radius, 2);
    
        return b_Ag;
    }

    float getMass(){
        //Set Radius
        scaleChange = new Vector3(b_radius, b_radius, b_radius);
        this.transform.localScale = scaleChange;

        //mass = volume x density
        b_Volume = 4/3 * Mathf.PI * Mathf.Pow(b_radius, 3);

        b_Mass = b_Volume * b_density;
        return b_Mass;
    }

    void gravity(){
        // Fg = GMm / r^2

        foreach(var bodies in body){
            if(bodies != this){
                
            }
        }
    	
    }
}
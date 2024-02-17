using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModGrav : MonoBehaviour
{
    const float G = 0.01f;
    Vector3 scaleChange;

    //b_ Is for bodies
    [Header("Body Properties")]
    public float speed = 0;
    public float b_radius = 1;
    public float b_density; //Will look into this
    public bool isStar = false;
    float b_Volume;
    public float b_Mass;
    public bool notStar = true;

    Rigidbody rb;
    public List<GameObject> bodies;

    [Header("Gravity Parameters")]
    float r; //Distance between 2 bodies
    Vector3 Fg; //Force due to gravity
    Vector3 initialVel;
    public Vector3 currentVel;

    int count = 0;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
       setBodies();

    }

    private void Update() {
        setVel();
        is_Star();
    }

    void setVel(){
        while(count < 1){
            initialVel = new Vector3(0,0, speed);
            currentVel = initialVel;

            count++;

            break;
        }
    }

    private void FixedUpdate() {
        gravity();
        rb.MovePosition(rb.position + currentVel * Time.fixedDeltaTime);
    }

    void setBodies(){
        //Sets all bodies to a List within each object
        bodies.AddRange(GameObject.FindGameObjectsWithTag("Body"));

        for (int i = 0; i < bodies.Count(); i++)
        {
            if(bodies[i].name == this.gameObject.name){
                bodies.Remove(this.gameObject);
            }
        }
    }

    void is_Star(){
        if(isStar){
            gameObject.GetComponent<ModGrav>().enabled = false;
        }else{
            gameObject.GetComponent<ModGrav>().enabled = true;
        }
    }

    public float getMass(){
        //Set Radius
        scaleChange = new Vector3(b_radius, b_radius, b_radius);
        this.transform.localScale = scaleChange;

        //mass = volume x density
        b_Volume = 4/3 * Mathf.PI * Mathf.Pow(b_radius, 3);

        b_Mass = b_Volume * b_density;
        return b_Mass;
    }

    void gravity(){
        float M, m, F_scalar;

        Vector3 F_dir;

        //Fg = GMm/r^2
        foreach (var body in bodies)
        {
            r = Mathf.Sqrt((body.GetComponent<Rigidbody>().position - this.rb.position).sqrMagnitude); //Distance between objects
            M = getMass();
            m = body.GetComponent<ModGrav>().getMass();
            F_dir = (body.GetComponent<Rigidbody>().position - this.rb.position).normalized;

            F_scalar = (G * M * m) / Mathf.Pow(r,2);
            Fg = F_dir * F_scalar / 100000;

            currentVel += Fg;
        }
    }
}
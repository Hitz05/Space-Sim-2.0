using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public static bool isActive;

    [Range(0,1000)]
    public float rotaSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        while(isActive){
            
            if(Input.GetKey(KeyCode.D)){
                transform.Rotate(Vector3.forward, rotaSpeed * Time.deltaTime);
            }else if(Input.GetKey(KeyCode.A)){
                transform.Rotate(Vector3.forward, -rotaSpeed * Time.deltaTime);
            }else if(Input.GetKey(KeyCode.W)){
                transform.Rotate(Vector3.right, rotaSpeed * Time.deltaTime);
            }else if(Input.GetKey(KeyCode.S)){
                transform.Rotate(Vector3.right, -rotaSpeed * Time.deltaTime);
            }else if(Input.GetKey(KeyCode.Q)){
                transform.Rotate(Vector3.up, rotaSpeed * Time.deltaTime);
            }else if(Input.GetKey(KeyCode.E)){
                transform.Rotate(Vector3.up, -rotaSpeed * Time.deltaTime);
            }
                    
            break;
        }
    }
}
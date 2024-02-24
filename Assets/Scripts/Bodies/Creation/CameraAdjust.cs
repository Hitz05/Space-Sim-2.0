using UnityEngine;

public class CameraAdjust : MonoBehaviour
{    
    public float velocity;
    public float sens;

    Vector3 originalPos;

    private void Start() {
        originalPos = transform.position;
    }

    //Camera only to zoom in and out and Up Down left right in plane; WASD
    private void Update() {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        float scroll = Input.GetAxis("Mouse ScrollWheel"); 

        transform.Translate(new Vector2(xInput * velocity * Time.deltaTime, yInput * velocity * Time.deltaTime));

        if(scroll != 0 && transform.position.y > 0){
            transform.position -= new Vector3(0, scroll * sens * Time.deltaTime, 0);
        }
        else if(Input.GetKey(KeyCode.Space)){
            transform.position = originalPos;
        }

        if(transform.position.y < 0){
            transform.position = originalPos;
        }
    }
}

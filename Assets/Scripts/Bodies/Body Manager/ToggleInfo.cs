using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInfo : MonoBehaviour
{

    MeshRenderer mRend;
    Color originalCol;

    public bool onBody = false;
    public bool show = false;

    private void Start() {
        mRend = GetComponent<MeshRenderer>();
        originalCol = mRend.material.color;
    }
    
    private void OnMouseOver() {
        mRend.material.color = Color.magenta;
        onBody = true;
        if(Input.GetMouseButton(0) && onBody){
            show = true;
        }
    }

    private void OnMouseExit() {
        mRend.material.color = originalCol;
        onBody = false;
        show = false;
    }
}

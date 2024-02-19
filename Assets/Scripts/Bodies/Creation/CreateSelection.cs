using UnityEngine;

public class CreateSelection : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        select();
    }

    void select(){
        if(Input.GetKeyDown(KeyCode.S)){
            Debug.Log("Star");

        }else if(Input.GetKeyDown(KeyCode.P)){
            Debug.Log("Planet");
            
        }else if(Input.GetKeyDown(KeyCode.D)){
            Debug.Log("Nothing Yet");

        }
    }
}

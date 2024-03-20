using System;
using UnityEngine;

public class CreateSelection : MonoBehaviour
{
    public static int choice;

    public GameObject star, planet;
    
    //bool starPlaced = false;

    // Update is called once per frame
    void Update()
    {
        select();
        createStar();
    }

    void checkStar(){

    }
    
    void createStar(){
        while(choice == 1){
            //Right click, goes in the middle
            if(Input.GetMouseButtonDown(1)){
                Instantiate(star, new Vector3(0,0,0), Quaternion.identity);
                //starPlaced = true;
            }
            //Left-Click, places wherever mouse is
            if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Space)){

                Vector3 mousePos = Input.mousePosition;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Mathf.Abs(Camera.main.transform.position.y)));

                Instantiate(star, new Vector3(worldPos.x, 0f, worldPos.z), Quaternion.identity);

                //starPlaced = true;
            }

            break;
        }

    }
    void createPlanet(){
        //Can place only after star is placed
        //Needs to rotate so that z axis of planet is perpendicular to star
        //Alt + mouse move only up or down in screen    
    }

    void deleteBody(){
        //Right click to delete
        //No star deletion unless changed
    }

    void select(){
        if(Input.GetKeyDown(KeyCode.Z)){
            //Debug.Log("Star");
            choice = 1;

        }else if(Input.GetKeyDown(KeyCode.X)){
            //Debug.Log("Planet");
            choice = 2;
            
        }else if(Input.GetKeyDown(KeyCode.C)){
            //Debug.Log("Nothing Yet");
            choice = 3;
        }
    }
}

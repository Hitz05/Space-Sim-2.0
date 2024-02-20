using UnityEngine;

public class CreateSelection : MonoBehaviour
{
    public static int choice;

    // Update is called once per frame
    void Update()
    {
        select();
    }
    
    void createStar(){
        //Can place anywhere anytime
        //No rotation
        //Alt + mouse 0 = place centre

        

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
            Debug.Log("Star");
            choice = 1;

        }else if(Input.GetKeyDown(KeyCode.X)){
            Debug.Log("Planet");
            choice = 2;
            
        }else if(Input.GetKeyDown(KeyCode.C)){
            Debug.Log("Nothing Yet");
            choice = 3;
        }
    }
}

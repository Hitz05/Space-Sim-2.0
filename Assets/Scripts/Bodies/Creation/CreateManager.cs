using UnityEngine;

public class CreateManager : MonoBehaviour
{
    GameObject starMenu;

    // Start is called before the first frame update
    void Start()
    {
        starMenu = GameObject.FindGameObjectWithTag("StarMenu");

    }

    // Update is called once per frame
    void Update()
    {
        switch(CreateSelection.choice){
            case 1:
                if(GameObject.FindGameObjectsWithTag("Star").Length > 0){
                    starMenu.SetActive(true);
                }
                break;
            default:
                starMenu.SetActive(false);
                break;
        }
    }
}

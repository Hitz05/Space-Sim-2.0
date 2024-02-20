using UnityEngine;

public class IconManager : MonoBehaviour
{
    public GameObject star, planet, delete;

    // Update is called once per frame
    void Update()
    {
        switch(CreateSelection.choice){
            case 1:
                star.SetActive(true);
                planet.SetActive(false);
                delete.SetActive(false);
                break;
            case 2:
                planet.SetActive(true);
                star.SetActive(false);
                delete.SetActive(false);
                break;
            case 3:
                delete.SetActive(true);
                star.SetActive(false);
                planet.SetActive(false);
                break;
        }
    }
}

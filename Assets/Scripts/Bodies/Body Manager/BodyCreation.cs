using UnityEngine;

public class BodyCreation : MonoBehaviour
{
    public static bool creating = false;
    public bool localCreate = false;

    public GameObject spawn;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        creating = localCreate;
    }

    // Update is called once per frame
    void Update()
    {
        spawnObj();
        creating = localCreate;
    }

    void spawnObj(){
        while(localCreate){
            Vector3 mouse = Input.mousePosition;
            mouse.z = offset;
            Vector3 pos = Camera.main.ScreenToWorldPoint(mouse);
            pos.y = 0;
            if(Input.GetButtonDown("Fire1")){
                Instantiate(spawn, pos, Quaternion.identity);
            }

            break;
        }
    }
}

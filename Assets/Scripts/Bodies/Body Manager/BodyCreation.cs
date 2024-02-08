using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCreation : MonoBehaviour
{
    public static bool creating = false;
    public bool localCreate = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        creating = localCreate;
    }
}

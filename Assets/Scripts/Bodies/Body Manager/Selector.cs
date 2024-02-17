using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    GameObject selector, info;

    RectTransform img;

    Image selectorImg;

    // Start is called before the first frame update
    void Start()
    {
        selector = GameObject.FindGameObjectWithTag("Selector");
        info = GameObject.FindGameObjectWithTag("BodyInfo");

        selectorImg = FindObjectOfType<Image>();

        img = selectorImg.GetComponent<RectTransform>();

        selectorImg.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        activateSelector();
    }

    void activateSelector(){
        if(info.activeInHierarchy && img != null && GameManager.selBodyOut != null){

            Vector2 bodyPos = Camera.main.WorldToScreenPoint(GameManager.selBodyOut.GetComponent<Transform>().position);

            img.position = bodyPos;

            selectorImg.gameObject.SetActive(true);
        }
    }

    public void selectorOFF(){
        selectorImg.gameObject.SetActive(false);
    }
}
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    GameObject  info;
    public float scaleFactor = 22.1f;

    RectTransform img;

    Image selectorImg;

    private void Awake() {
        info = GameObject.FindGameObjectWithTag("BodyInfo");
    }

    // Start is called before the first frame update
    void Start()
    {
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
            //Sets position
            Vector2 bodyPos = Camera.main.WorldToScreenPoint(GameManager.selBodyOut.GetComponent<Transform>().position);

            img.position = bodyPos;

            //Sets Size based on radius
            float radius = GameManager.selBodyOut.GetComponent<Gravity>().b_radius;
            img.sizeDelta = new Vector2(radius * scaleFactor, radius * scaleFactor);

            if(GameManager.selBodyOut.GetComponent<Gravity>().isStar){
                img.sizeDelta = new Vector2(radius * scaleFactor / 2f, radius * scaleFactor / 2f);
            }

            selectorImg.gameObject.SetActive(true);
        }
    }

    public void selectorOFF(){
        selectorImg.gameObject.SetActive(false);
    }
}
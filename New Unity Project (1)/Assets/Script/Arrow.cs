using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject controller;
    public bool rightD;
    private Transform arrow;
    void Start()
    {
        gameObject.SetActive(gameObject.activeSelf);
        arrow = GetComponent<Transform>();
        rightD = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void arrowDirection(){

        if (controller.GetComponent<Controller>().getCurrentTg() == 1 && !rightD){
            arrow.Rotate(0f,0f,180f);
            rightD = true;
            //gameObject.SetActive(gameObject.activeSelf);
        }else if (controller.GetComponent<Controller>().getCurrentTg() == 0 && rightD){
            arrow.Rotate(0f,0f,180f);
            rightD = false;
            //gameObject.SetActive(!gameObject.activeSelf);
        }
        //Debug.Log( "target atual = " + controller.GetComponent<Controller>().getCurrentTg());
    }
}

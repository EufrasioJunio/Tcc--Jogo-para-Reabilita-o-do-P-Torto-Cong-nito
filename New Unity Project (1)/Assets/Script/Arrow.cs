using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject controller;
    public bool arrowRight;
    private Transform arrow;

    public Material material;

    public Color correctColor;

     public Color errortColor;

     public bool reporting;
    void Start()
    {
        //gameObject.SetActive(gameObject.activeSelf);
        reporting = false;
        material.color = correctColor;
        arrow = GetComponent<Transform>();
        //setArrowDirection();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void setRotationRight() {
        arrow.SetPositionAndRotation(arrow.position, new Quaternion(0f,0f,180f, 0f));
    }
    public void setRotationLeft() {
        arrow.SetPositionAndRotation(arrow.position, new Quaternion(0f,0f,0f, 0f));
    }
    public void setArrowDirection(){
        bool targetRight = (controller.GetComponent<Controller>().getCurrentTg() == 1);
        if(targetRight){
            setRotationRight();
        }else if (!targetRight){
            setRotationLeft();
        }
    }

    public bool getReporting(){
        return reporting;
    }
    public void setReporting(bool b){
        reporting = b;
    }

    public void setColor(){ 
            reporting = true;
            material.color = errortColor;
            StartCoroutine(timeToReport());  


    }

    IEnumerator timeToReport(){
            yield return new WaitForSecondsRealtime(1f);
            controller.GetComponent<Controller>().addTError();
            controller.GetComponent<Controller>().setCorrectSide(0);
            material.color = correctColor;
            reporting = false;
    }
}

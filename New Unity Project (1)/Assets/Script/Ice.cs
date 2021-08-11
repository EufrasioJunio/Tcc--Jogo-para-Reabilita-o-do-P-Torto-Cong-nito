using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject controller;

    public Transform iceT;

    public Vector3 rightP;
    public Vector3 leftP;
    void Start()
    {   
        iceT =  GetComponent<Transform>();
        leftP = iceT.position;
        rightP= iceT.position + new Vector3(17,0,0);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
       public void setIcePosition(){
           bool targetRight = (controller.GetComponent<Controller2>().getCurrentTg() == 1);
           if(targetRight){
               iceT.position = rightP;
           }else{
               iceT.position = leftP;
           }

        
    } 
}

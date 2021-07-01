using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.IO;
public class Ball : MonoBehaviour
{
    private Transform wayleft;

    private bool kick ;
    private Transform wayright;
    public GameObject player;
    public GameObject controller;
    public int check;
    public GameObject playerstart;
    public Vector3 ballstarted;
    public Transform ball;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
     check = 99;
     ball = GetComponent<Transform>();
     agent = GetComponent<NavMeshAgent>();
     ballstarted = ball.position;
     //Debug.Log("bola starta em =" + ballstarted);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.GetComponent<Transform>().position,transform.position);
    //    if(check==1){
    //     if (Vector3.Distance(wayright.position,transform.position) <= 1f ){
    //                 updateStatus();
    //                 check = 99;
    //     }
    //    }
    //    if(check==0){
    //     if (Vector3.Distance(wayleft.position,transform.position) <= 1f ){
    //                 updateStatus();
    //                 check = 99;
    //     }
    //    }

        if (controller.GetComponent<Controller>().getReturnB()){
                updateStatus();

        }

        //if(controller.GetComponent<Controller>().acertou) {
        if(player.GetComponent<PlayerScript>().getIsKick() && distance<= 0.5f){
            //controller.GetComponent<Controller>().acertou = false;
            player.GetComponent<PlayerScript>().setIsKick(false);
            if (controller.GetComponent<Controller>().getCurrentTg() == 1){
                wayright = GameObject.FindWithTag("WayRight").transform;
                agent.enabled = true;
                agent.destination = wayright.position;
                
                //Debug.Log(Vector3.Distance(wayright.position,transform.position));
                //check = 1;
            }else{
                wayleft = GameObject.FindWithTag("WayLeft").transform;
                agent.enabled = true;
                agent.destination = wayleft.position;
                //Debug.Log(Vector3.Distance(wayleft.position,transform.position));
                //check = 0;

           }

        }
    }

    public void updateStatus(){
           // player.GetComponent<PlayerScript>().setPositionStart();
            agent.ResetPath();
            ball.position = ballstarted;
            //Debug.Log("Posição da bola depois de setar = "+ ball.position);
            //player.GetComponent<PlayerScript>().setCurrentPs(player.GetComponent<PlayerScript>().getCurrentPs()+1);
            //player.GetComponent<PlayerScript>().setController(true);
            controller.GetComponent<Controller>().setReturnB(false);

    }
}

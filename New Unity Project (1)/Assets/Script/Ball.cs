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
    public int controller;
    public GameObject playerstart;
    public Vector3 ballstarted;
    public Transform ball;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
     controller = 99;
     ball = GetComponent<Transform>();
     agent = GetComponent<NavMeshAgent>();
     ballstarted = ball.position;
    }

    // Update is called once per frame
    void Update()
    {
       float distance = Vector3.Distance(player.GetComponent<Transform>().position,transform.position);
       if(controller==1){
        if (Vector3.Distance(wayright.position,transform.position) <= 1f ){
                    updateStatus();
                    controller = 99;
        }
       }
       if(controller==0){
        if (Vector3.Distance(wayleft.position,transform.position) <= 1f ){
                    updateStatus();
                    controller = 99;
        }
       }
       if (distance<= 0.5f){
           if (player.GetComponent<PlayerScript>().currentTg == 1){
                wayright = GameObject.FindWithTag("WayRight").transform;
                agent.enabled = true;
                agent.destination = wayright.position;
                Debug.Log(Vector3.Distance(wayright.position,transform.position));
                controller = 1;
           }else{
                wayleft = GameObject.FindWithTag("WayLeft").transform;
                agent.enabled = true;
                agent.destination = wayleft.position;
                Debug.Log(Vector3.Distance(wayleft.position,transform.position));
                controller = 0;

           }

        }
    }

    void updateStatus(){
            player.GetComponent<PlayerScript>().setPositionStart();
            agent.enabled = false;
            ball.position = ballstarted;
            player.GetComponent<PlayerScript>().setCurrentPs(player.GetComponent<PlayerScript>().getCurrentPs()+1);
            player.GetComponent<PlayerScript>().setController(true);
    }
}

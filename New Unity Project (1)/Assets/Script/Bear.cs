using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.IO;

public class Bear : MonoBehaviour
{

    // bool controller; 
    public float kick = 0.1f;
    private Transform objecty;

    public GameObject destination;
    public GameObject controller;
    private Transform playerT;
    private Transform playerS;
    public NavMeshAgent agent;
    public Animator anim;
    public int repetition;
    public int time;
    public int currentTg;
    public int currentPs;
    public Vector3 playerstarted;

    public bool animIsOff;

    public bool isKick;

    // Start is called before the first frame update

    public int[] targets;
    void Start()
    {
        playerT= GetComponent<Transform>();
        playerstarted = playerT.position;
        //Debug.Log("posiçao de start = " + playerstarted);
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        objecty = destination.transform;
        //controller = true;
        kick = 1f;
        currentPs = 0;
        //controller = true;
        isKick= false;
        animIsOff = false;

    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
         float distance = Vector3.Distance(gameObject.GetComponent<Transform>().position, objecty.position);
         //Debug.Log(distance);

        if (distance < kick)
        {
            //Debug.Log(currentPs + " " + targets.Length + " " + currentTg);
            // agent.enabled= false;
            //anim.SetBool("run", false);
            //anim.SetBool("idle", true);

        }

        if (controller.GetComponent<Controller2>().getReturnP()){
            updateStatus();
        }

        // if (controller)
        // {
        //     //controller = false;
        //     if (1==1)//(currentPs < targets.Length)
        //     {
        //         currentTg = 1;//targets[currentPs];

        //         if ((currentTg == 1 && Input.GetMouseButtonDown(1)) || (currentTg == 0 && Input.GetMouseButtonDown(0)))
        //         {
        //             //anim.SetBool("idle",false);
        //             anim.SetBool("run", true);
        //             agent.destination = objecty.position;

        //         }
        //     }
        //     else
        //     {
        //          Debug.Log("fim de jogo");        
        //     }
        // }

    }

    public void toObjecty(){
        setIsKick(true);
        agent.enabled = true;
        agent.speed = 150;
        agent.acceleration = 75;

        //anim.SetBool("idle",false);
        //anim.SetBool("run", true);
        agent.destination = objecty.position;  
    }

    public bool getIsKick(){
        return isKick;
    }
    public void setIsKick(bool b){
        isKick = b;
    }

    public int getCurrentPs()
    {
        return currentPs;
    }

    // public void setController(bool C)
    // {
    //     controller = C;

    // }

    // public bool getController()
    // {
    //     return controller;
    // }

    public void setCurrentPs(int P)
    {
        currentPs = P;

    }


    public void updateStatus(){
        anim.enabled = false;
        animIsOff = true;
        agent.ResetPath();
        playerT.position = playerstarted;
        if (animIsOff)
            StartCoroutine( animOn());
        controller.GetComponent<Controller2>().setReturnP(false);
        //Debug.Log("posiçao des de setar o start = " + playerT.position);
    }

    IEnumerator animOn(){
    yield return new WaitForSecondsRealtime(0.05f);
        anim.enabled = true;
        animIsOff = false;
    }

}

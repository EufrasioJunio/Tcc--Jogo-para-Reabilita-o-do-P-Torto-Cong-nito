using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.IO;

public class PlayerScript : MonoBehaviour
{
    bool runcon = true;
    // bool controller; 
    public float kick = 0.1f;
    private Transform BallWayPoint;

    private Transform playerT;
    private Transform playerS;
    private NavMeshAgent agent;
    private Animator anim;
    public int repetition;
    public int time;
    bool controller;
    public int currentTg;
    public int currentPs;

    // Start is called before the first frame update

    public int[] targets;
    void Start()
    {
        playerT= GetComponent<Transform>();
        playerS = playerT;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        BallWayPoint = GameObject.FindWithTag("BallWayPoint").transform;
        //controller = true;
        kick = 1f;
        StreamReader sr = new StreamReader("controller.txt");
        string[] file = sr.ReadLine().Split(' ');
        int.TryParse(file[0], out repetition);
        int.TryParse(file[1], out time);
        targets = new int[2 * repetition];
        Directions();
        currentPs = 0;
        controller = true;

    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
         float distance = Vector3.Distance(gameObject.GetComponent<Transform>().position, BallWayPoint.position);
         //Debug.Log(distance);

        if (distance < kick)
        {
            //Debug.Log(currentPs + " " + targets.Length + " " + currentTg);
            // agent.enabled= false;
            anim.SetBool("run", false);
            anim.SetBool("idle", true);

        }
        if (controller)
        {
            //controller = false;
            if (currentPs < targets.Length)
            {
                currentTg = targets[currentPs];

                if ((currentTg == 1 && Input.GetMouseButtonDown(1)) || (currentTg == 0 && Input.GetMouseButtonDown(0)))
                {
                    //anim.SetBool("idle",false);
                    anim.SetBool("run", true);
                    agent.destination = BallWayPoint.position;

                }
            }
            else
            {
                 Debug.Log("fim de jogo");        
            }
        }

    }

    void Directions()
    {

        int i = 0;
        while (i < targets.Length)
        {
            int c = Random.Range(0, 2);
            if (c == 1)
            {
                targets[i] = c;
                targets[i + 1] = c - 1;
                i += 2;
            }
            else
            {
                targets[i] = c;
                targets[i + 1] = c + 1;
                i += 2;
            }

        }


    }

    public int getCurrentPs()
    {
        return currentPs;
    }

    public void setController(bool C)
    {
        controller = C;

    }

    public bool getController()
    {
        return controller;
    }

    public void setCurrentPs(int P)
    {
        currentPs = P;

    }

    public void setPositionStart(){
        playerT = playerS;
    }

}

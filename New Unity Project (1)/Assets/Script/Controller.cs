using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.IO;

public class Controller : MonoBehaviour
{
    
    public GameObject arrow;
    public GameObject player;
    public GameObject ball;
    public int repetition;
    public int time;
    public int[] targets;
    public ConfigData configData;

    public LogData logData;

    public int currentTg;
    public int currentPs; 

    public bool playng;

    public bool returnB;

    public bool returnP;

    public int correctSide;

    public int tError;


    
    // Start is called before the first frame update
    void Start()
    {
        // StreamReader sr = new StreamReader("controller.txt");
        // string[] file = sr.ReadLine().Split(' ');
        // int.TryParse(file[0], out repetition);
        // int.TryParse(file[1], out time);
        Application.targetFrameRate = 60;
        string jsonC = File.ReadAllText(Application.dataPath + "/config.json");
        string jsonL = File.ReadAllText(Application.dataPath + "/log.json");
        configData = JsonUtility.FromJson<ConfigData>(jsonC);
        logData = JsonUtility.FromJson<LogData>(jsonL);
        time =  configData.getTime();
        repetition = configData.getRepetition();
        targets = new int[2 * repetition];
        Directions();
        playng = true;
        currentPs = 0;
        //arrow.GetComponent<Arrow>().setRightD(false);
        // arrow.GetComponent<Arrow>().arrowDirection();
        returnB = false;
        returnP = false;
        correctSide = 0;
        tError = 0;
        arrow.GetComponent<Arrow>().setArrowDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPs < targets.Length){
            bool right = (getCurrentTg() == 1);
            if(playng){
                if (correctSide > time*60){
                        correctSide = 0;
                        playng = false;
                        player.GetComponent<PlayerScript>().toBall();
                        StartCoroutine( restTime());
                      
                }else{
                    if ( (right && Input.GetAxis("Horizontal") > 0) || (!right && Input.GetAxis("Horizontal") < 0)){
                        correctSide +=1;
                        //Debug.Log("lado correto = " + correctSide);
                    }else if ((!right && Input.GetAxis("Horizontal") > 0) || (right && Input.GetAxis("Horizontal") < 0)){
                        if (!arrow.GetComponent<Arrow>().getReporting())
                            arrowReport();
                    }else if (correctSide >0 && Input.GetAxis("Horizontal") == 0){
                        if (!arrow.GetComponent<Arrow>().getReporting())
                            arrowReport();
                    }
                }

                
            }
        }else{
            correctSide= 0;
            Debug.Log("Fim De Jogo");

        } 

    }

    IEnumerator restTime(){
        yield return new WaitForSecondsRealtime(2f);
        returnP = true;
        returnB = true;
        //player.GetComponent<PlayerScript>().updateStatus();
        //ball.GetComponent<Ball>().updateStatus();
        if((currentPs +1) < targets.Length){
            currentPs +=1;
            //Debug.Log( "posi atual = " + currentPs);
            arrow.GetComponent<Arrow>().setArrowDirection();
        }else{
            currentPs +=1;
        }
        playng = true;
    }

    public bool getPlayng(){
        return playng;
    }
    
    public bool getReturnB(){
        return returnB;
    }
    public bool getReturnP(){
        return returnP;
    }
     public void setReturnB(bool b){
        returnB = b;
     }
     public void setReturnP(bool b){
       returnP = b;
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

    //     void updateStatus(){
    //        // player.GetComponent<PlayerScript>().setPositionStart();
    //         player.GetComponent<PlayerScript>().updateStatus();
    //         ball.GetComponent<Ball>().updateStatus();

    //         //player.GetComponent<PlayerScript>().setCurrentPs(player.GetComponent<PlayerScript>().getCurrentPs()+1);
    //         //player.GetComponent<PlayerScript>().setController(true);
    // }

    public int getCurrentTg(){
        return targets[currentPs];
    }

    public void arrowReport(){
        arrow.GetComponent<Arrow>().setColor();
    }

    public void setCorrectSide(int i){
        correctSide = i;
    }

    public void addTError(){
        tError += 1;
    }

    public class ConfigData {
        public int repetition = 2;
        public int time = 4;

        public void setTime (int t){
            time = t;
            File.WriteAllText(Application.dataPath + "/config.json",getJson());
        }
        public void setRepetition (int r){
            repetition = r;
            File.WriteAllText(Application.dataPath+ "/config.json",getJson());
        }

        public int getRepetition(){
            return repetition;
        }
        public int getTime(){
            return time;
        }

        public string getJson(){
            return JsonUtility.ToJson(this);
        }


    }    
    public class LogData {
        public string name;
        public float maxtime;
        public int maxrepetition;
        public int maxerror;

        public void setMaxTime (float t){
            maxtime = t;
            saveLog();
        }
        public void setMaxRepetition (int r){
            maxrepetition = r;
            saveLog();
        }

         public void setMaxError (int e){
            maxerror = e;
            saveLog();
        }

        public void setName (string n){
            name = n;
            saveLog();
        }
        public int getMaxRepetition(){
            return maxrepetition;
        }

        public string getName(){
            return name;
        }
        public int getMaxError(){
            return maxerror;
        }
        public float getMaxTime(){
            return maxtime;
        }

        public void saveLog(){

            File.WriteAllText(Application.dataPath+ "/log.json",JsonUtility.ToJson(this));
        }


    }
}  


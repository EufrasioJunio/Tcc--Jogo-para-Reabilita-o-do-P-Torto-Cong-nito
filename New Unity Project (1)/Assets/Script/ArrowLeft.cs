using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLeft : MonoBehaviour
{ 
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerScript>().currentTg == 0 )
            gameObject.SetActive(gameObject.activeSelf);
        else
            gameObject.SetActive(!gameObject.activeSelf);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerScript>().currentTg == 1 )
            gameObject.SetActive(gameObject.activeSelf);
        else
            gameObject.SetActive(!gameObject.activeSelf);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractions : MonoBehaviour
{
    public PlayerUI ui;
    private PlayerScoring playerscoring;
    private GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        playerscoring = GetComponent<PlayerScoring>();
        ui = GetComponent<PlayerUI>();
        //gameObject = GetComponent<>();
    }

    // Update is called once per frame
    void Update()
    {
        ui.UpdateUI();
        if(Input.GetKeyDown(KeyCode.P))//cookbook
        {
            playerscoring.AddKPoints(1);
        }
        if(Input.GetKeyDown(KeyCode.L))//PHd
        {
            playerscoring.AddKPoints(25);
        }
        if(Input.GetKeyDown(KeyCode.M))//brownie
        {
            playerscoring.AddBrownie();
        }
        if(Input.GetKeyDown(KeyCode.O))//NullPointer
        {
            playerscoring.MinusKPoints();
        }
        if(Input.GetKeyDown(KeyCode.K))//Swarm
        {
            playerscoring.MinusKPoints();
        }
        if(Input.GetKeyDown(KeyCode.N))//brownie
        {
            playerscoring.AddBrownie();
        }
        
    }
}

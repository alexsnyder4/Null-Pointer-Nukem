using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractions : MonoBehaviour
{
    public PlayerUI ui;
    private PlayerScoring playerscoring;
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
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Null Pointer")) 
        {
            playerscoring.MinusKPoints();
            NullPointers nullPointer = collision.gameObject.GetComponent<NullPointers>();
            if (nullPointer != null)
            {
                nullPointer.Destroy();
            }
        }
        if(collision.gameObject.CompareTag("Swarm")) 
        {
            //reduce by 10 per second until collides with hero
        }
        if(collision.gameObject.CompareTag("Pirate")) 
        {
            //freeze player
        }
        if(collision.gameObject.CompareTag("Cookbook")) 
        {
            playerscoring.AddKPoints(1);
        }
        if(collision.gameObject.CompareTag("PHD")) 
        {
            playerscoring.AddKPoints(25);
        }
        if(collision.gameObject.CompareTag("Brownie")) 
        {
            playerscoring.AddBrownie();
        }
        if(collision.gameObject.CompareTag("Ohl")) 
        {
            //10 brownies knowledge bomb
        }
        if(collision.gameObject.CompareTag("Sandro")) 
        {
            //10 brownies british invasion
        }
        if(collision.gameObject.CompareTag("Bilitski")) 
        {
            //10 brownies American Algorithmic Amplifier.
        }
    }
}

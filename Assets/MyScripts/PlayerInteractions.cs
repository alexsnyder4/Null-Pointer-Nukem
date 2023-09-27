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
            playerscoring.StartSwarmDmg();
            Swarms swarms = collision.gameObject.GetComponent<Swarms>();
            if (swarms != null)
            {
                swarms.Destroy();
            }
        }
        if(collision.gameObject.CompareTag("Pirate")) 
        {
            //freeze player
            Pirates pirates = collision.gameObject.GetComponent<Pirates>();
            if (pirates != null)
            {
                pirates.Destroy();
            }
        }
        if(collision.gameObject.CompareTag("Cookbook")) 
        {
            playerscoring.AddKPoints(1);
            Cookbook cookbook = collision.gameObject.GetComponent<Cookbook>();
            if (cookbook != null)
            {
                cookbook.Destroy();
            }
        }
        if(collision.gameObject.CompareTag("Pendant")) 
        {
            playerscoring.AddKPoints(25);
            Pendant pendant = collision.gameObject.GetComponent<Pendant>();
            if (pendant != null)
            {
                pendant.Destroy();
            }
        }
        if(collision.gameObject.CompareTag("Brownie")) 
        {
            playerscoring.AddBrownie();
            Brownie brownie = collision.gameObject.GetComponent<Brownie>();
            if (brownie != null)
            {
                brownie.Destroy();
            }
        }
        if(collision.gameObject.CompareTag("Ohl")) 
        {
            //10 brownies knowledge bomb
            playerscoring.isPoisoned = false;
            Ohl ohl = collision.gameObject.GetComponent<Ohl>();
            if (ohl != null)
            {
                ohl.Destroy();
            }
        }
        if(collision.gameObject.CompareTag("Sandro")) 
        {
            playerscoring.isPoisoned = false;            //10 brownies british invasion
            Sandro sandro = collision.gameObject.GetComponent<Sandro>();
            if (sandro != null)
            {
                sandro.Destroy();
            }
        }
        if(collision.gameObject.CompareTag("Bilitski")) 
        {
            playerscoring.isPoisoned = false;            //10 brownies American Algorithmic Amplifier.
            Bilitski bilitski = collision.gameObject.GetComponent<Bilitski>();
            if (bilitski != null)
            {
                bilitski.Destroy();
            }
        }
    }
}

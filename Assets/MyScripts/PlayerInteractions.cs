using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerInteractions : MonoBehaviour
{
    private PlayerUI ui;
    private PlayerScoring playerscoring;
    private PlayerMovement pm;
    [SerializeField]
    public bool isImmune = false;

    // Start is called before the first frame update
    void Start()
    {
        playerscoring = GetComponent<PlayerScoring>();
        ui = GetComponent<PlayerUI>();
        pm = GetComponent<PlayerMovement>();
        ui.ToggleImage();
        ui.ToggleChat();
    }

    // Update is called once per frame
    void Update()
    {
        ui.UpdateUI();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Null Pointer") && isImmune == false) 
        {
            playerscoring.MinusKPoints();
            NullPointers nullPointer = collision.gameObject.GetComponent<NullPointers>();
            if (nullPointer != null)
            {
                nullPointer.Destroy();

            }
        }
        if (collision.gameObject.CompareTag("Null Pointer"))
        {
            NullPointers nullPointer = collision.gameObject.GetComponent<NullPointers>();
            nullPointer.Destroy();
        }
        if(collision.gameObject.CompareTag("Swarm") && isImmune == false) 
        {
            playerscoring.StartSwarmDmg();
            Swarms swarms = collision.gameObject.GetComponent<Swarms>();
            if (swarms != null)
            {
                swarms.Destroy();
            }
        }
        if (collision.gameObject.CompareTag("Swarm"))
        {
            Swarms swarms = collision.gameObject.GetComponent<Swarms>();
            swarms.Destroy();
        }
        if(collision.gameObject.CompareTag("Pirate") && isImmune == false) 
        {
            //freeze player
            Pirates pirates = collision.gameObject.GetComponent<Pirates>();
            if (pirates != null)
            {
                pm.FreezePlayerMovement();
                
                pirates.Destroy();
            }
        }
        if(collision.gameObject.CompareTag("Pirate"))
        {
            Pirates pirates = collision.gameObject.GetComponent<Pirates>();
            
            pirates.Destroy();
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
            BrownieSpawner spawner = GetComponent<BrownieSpawner>();
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
                if(playerscoring.brownies == 10)
                {
                    ohl.DestroyAllObjects("Null Pointer");
                    ohl.DestroyAllObjects("Pirate");
                    ohl.DestroyAllObjects("Swarm");
                    playerscoring.ResetBrownies();
                }
                ohl.Destroy();
            }
        }
        if(collision.gameObject.CompareTag("Sandro")) 
        {
            playerscoring.isPoisoned = false;            //10 brownies british invasion
            Sandro sandro = collision.gameObject.GetComponent<Sandro>();
            if (sandro != null)
            {
                if(playerscoring.brownies == 10)
                {
                    isImmune = true;
                    ui.ToggleImage();
                    StartCoroutine(ImmunityTimer());
                    Debug.Log("Player is immune");
                    playerscoring.ResetBrownies();
                }
                sandro.Destroy();
            }
        }
        if(collision.gameObject.CompareTag("Bilitski")) 
        {
            playerscoring.isPoisoned = false;            //10 brownies American Algorithmic Amplifier.
            Bilitski bilitski = collision.gameObject.GetComponent<Bilitski>();
            if (bilitski != null)
            {
                if(playerscoring.brownies == 10)
                {
                    playerscoring.currKPoints = bilitski.Amplify(playerscoring.currKPoints);
                    playerscoring.ResetBrownies();
                }
                bilitski.Destroy();
            }
        }
    }
    private IEnumerator ImmunityTimer()
    {
        yield return new WaitForSeconds(7.0f);

        // After 5 seconds, remove the immunity
        isImmune = false;
        ui.ToggleImage();
        Debug.Log("Player is no longer immune");

        // Restore collision-related logic if you disabled it earlier
        // ...
    }
}


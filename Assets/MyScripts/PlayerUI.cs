using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerUI : MonoBehaviour
{
    private PlayerScoring playerscoring;
    private PlayerInteractions pi;
    public TMP_Text kScore;
    public TMP_Text bScore;
    public Image canvasImage;
    public TMP_Text chat;
    // Start is called before the first frame update
    void Start()
    {
        
        playerscoring = GetComponent<PlayerScoring>();
        pi = GetComponent<PlayerInteractions>();
    }

    // Update is called once per frame
    public void UpdateUI()
    {
        kScore.text = "Knowledge Points: " + System.Convert.ToString(playerscoring.currKPoints) + 
                      "\n" + "Min Knowledge Points: " + System.Convert.ToString(playerscoring.minKPoints);
        bScore.text = "Brownies: " + System.Convert.ToString(playerscoring.brownies);
    }
    public void ToggleImage()
    {
        canvasImage.enabled = !canvasImage.enabled;
    }
    public void ToggleChat()
    {
        chat.enabled = !chat.enabled;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerUI : MonoBehaviour
{
    private PlayerScoring playerscoring;
    public TMP_Text kScore;
    public TMP_Text bScore;
    // Start is called before the first frame update
    void Start()
    {
        playerscoring = GetComponent<PlayerScoring>();
    }

    // Update is called once per frame
    public void UpdateUI()
    {
        kScore.text = "Knowledge Points: " + System.Convert.ToString(playerscoring.currKPoints);
        bScore.text = "Brownies: " + System.Convert.ToString(playerscoring.brownies);

    }
}

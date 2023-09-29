using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoring : MonoBehaviour
{   
    public bool isPoisoned = false;
    public int brownies = 0;
    public bool maxBrownies = false;
    public int currKPoints = 20;
    public int minKPoints = 5;
    public int highestNumKPoints = 20;
    public int maxKPoints = 1000000;
    public float lastReductionTime;
    public PlayerInteractions playerinteractions;
    // Start is called before the first frame update
    void Start()
    {
        playerinteractions = GetComponent<PlayerInteractions>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHighestKPoints();
        if(brownies < 10)
            maxBrownies = false;
        
        CheckForLoss();
    }
    public void AddKPoints(int value)
    {
        currKPoints += value;
    }
    public void AddBrownie()
    {
        if (brownies < 10 && maxBrownies == false)
            brownies++;
        else 
        {
            maxBrownies = true;
            Debug.Log("Maximum Brownies collected, turn into Hero");
        }
    }
    public void MinusKPoints()
    {
        if(currKPoints <= 20)
            currKPoints -= 10;
        else
            currKPoints /= 2;
    }
    public void ResetBrownies()
    {
        brownies = 0;
    }
    public void UpdateHighestKPoints()
    {
        if (currKPoints > highestNumKPoints)
        {
            highestNumKPoints = currKPoints;

            minKPoints = (int)(.25 * highestNumKPoints);

        }
    }
    public void CheckForLoss()
    {
        if (currKPoints < minKPoints)
        {
            Debug.Log("Loss");
        }
    }
    public void DecayPoints()
    {
        
        
    }

    private IEnumerator SwarmCoroutine()
    {   
        while(isPoisoned)
        {
            currKPoints = (int)(currKPoints * .9);
            yield return new WaitForSeconds(1f);
        }
    }
    public void StartSwarmDmg()
    {
        isPoisoned = true;
        StartCoroutine(SwarmCoroutine());
    }
}
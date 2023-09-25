using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoring : MonoBehaviour
{
    public int brownies = 0;
    public bool maxBrownies = false;
    public int currKPoints = 20;
    public int highestNumKPoints = 20;
    public int maxKPoints = 1000000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            highestNumKPoints = currKPoints;
    }
    public void CheckForLoss()
    {
        if (currKPoints < (.25 * currKPoints))
        {
            Debug.Log("Game Over");
            //remove player controls
            //display new text mesh canvas saying Game Over
            //possibly add restart button?
        }
    }

}

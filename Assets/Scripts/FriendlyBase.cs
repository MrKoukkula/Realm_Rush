using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendlyBase : MonoBehaviour
{
    [SerializeField] int baseHealth = 5;
    [SerializeField] Text healthText;
    [SerializeField] Text pointsText;
    private int points = 0;

    private void OnTriggerEnter(Collider other)
    {
        print("Base is hit!");
        baseHealth--;
        healthText.text = "Friendly Base health: " + baseHealth;
    }

    public void addPoint()
    {
        points++;
        pointsText.text = "Points: " + points;
    }
}

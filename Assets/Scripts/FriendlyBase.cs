using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendlyBase : MonoBehaviour
{
    [SerializeField] int baseHealth = 5;
    [SerializeField] Text healthText;


    private void OnTriggerEnter(Collider other)
    {
        print("Base is hit!");
        baseHealth--;
        healthText.text = "Friendly Base health: " + baseHealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Number of steps the player made, initlized as one for better player movement
    public static int steps = 1;
    
    Button buttonComponent;
    GameManager gameManager;
    void Start()
    {
        // Set up the button click event to trigger the MovePlayer method in the GameManager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (gameManager == null)
            Debug.LogError("Game Manager not found");

        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(gameManager.MovePlayer);
            
        
    }
    // Set the button interactable, this method made for roll button 
    public void SetInteractable()
    {
        buttonComponent.interactable = true;
    }
}

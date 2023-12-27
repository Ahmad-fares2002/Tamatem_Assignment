using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlayerMovement : MonoBehaviour
{
    /* this script made for animatiom events to handle the ability to interact with the player so the player 
     * can't interact with the button unless the dice animation finished */
    private PlayerController playerController;
    void Start()
    {
        // Perform a null check before accessing GameManager.player
        if (GameManager.player != null)
        {
            playerController = GameManager.player.GetComponent<PlayerController>();
        }
        else
        {
            Debug.LogError("GameManager.player is null in EnablePlayerMovement script");
        }
    }
    public void SetPlayerInteractable()
    {
        if (playerController != null)
        {
            playerController.SetInteractable();
        }
        else
        {
            Debug.LogError("playerController is null in EnablePlayerMovement script");
        }
    }

}

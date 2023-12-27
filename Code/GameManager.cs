using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform[] redPlayerPath;
    public static GameObject player;
    private DiceRoller diceRoller;
    public static bool startRolling;
    private int diceNum;
    private const string pathObjectName = "Path";
    private const string playerCloneName = "Player(Clone)";
    void Start()
    {

        // Put all the Path children in the redPlayerPath
        redPlayerPath = GameObject.Find(pathObjectName)
            .GetComponentsInChildren<Transform>();
        diceRoller = GetComponent<DiceRoller>();
       }
    //Find Player in the inspector
    public void FindPlayer()
    {        
        player = GameObject.Find(playerCloneName);

        if (player == null)
        {
            Debug.LogError("player is not here");
            return;
        }
     
    }
    //Decide the player intractability depedning on the input
    public void IsInteractablePlayer(bool status)
    {
        player.GetComponent<Button>().interactable = status;
    }
    // Move the plaer depending on the random number
    public void MovePlayer()
    {
        diceNum = GetRandomNum.diceNum;
        diceRoller.dices[diceNum].SetActive(false);
        StartCoroutine("MovementAnim");

        // The rolling phase stopped and the player can interact with the roll button 
        startRolling = false;
        diceRoller.IsInteractableDiceButton(true);
        diceRoller.ShowButton();

        IsInteractablePlayer(false);

    }
    // Make a tween for movment as an animation
    IEnumerator MovementAnim()
    {
        // the number of steped increased by the one becuase it is decremented by one in initialization
        int steps = diceNum + 1;

        // time between translating the player from path to path
        const float secondsToWait = .2f;
        int playerSteps;
        for (int i = 0; i < steps; i++)
        {
            // Not allowing to end unless the number doest goes beyond the array size
            if (PlayerController.steps + steps > redPlayerPath.Length)
            {
                break;
            }

            PlayerController.steps += 1;
            playerSteps = PlayerController.steps;
            player.transform.position = redPlayerPath[playerSteps].position;
            
            yield return new WaitForSeconds(secondsToWait);
        }
    }
    // return the player to its initial position
    public void ReturnPlayer()
    {
        if(startRolling)
        {
            return;
        }
        player.transform.position = redPlayerPath[1].position;
        PlayerController.steps = 1;
    }
}

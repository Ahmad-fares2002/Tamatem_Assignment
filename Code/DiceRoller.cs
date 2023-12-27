using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiceRoller : MonoBehaviour
{
    [SerializeField] private GameObject Rollerbutton;
    [SerializeField] public GameObject[] dices;

    // Activate the Rollerbutton
    public void HideButton()
    {
        Rollerbutton.SetActive(false);
    }
    //Deactivate The Rollerbutton
    public void ShowButton()
    {
        Rollerbutton.SetActive(true);
    }  
    //Showing the dice depending on the number gotten from another class
    public void ShowDiceAnim(int num)
    {
        // Handling the button interactiblity, saving the game from bugs
        IsInteractableDiceButton(false);

        dices[num].SetActive(true);
    }
  
    //Decide the button interactble or not depending on input
    public void IsInteractableDiceButton(bool status)
    {
        Rollerbutton.GetComponent<Button>().enabled = status;
        Rollerbutton.GetComponent<Image>().raycastTarget = status;
    }
}

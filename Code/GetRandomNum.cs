using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetRandomNum : MonoBehaviour
{
    private string apiUrl = "https://www.randomnumberapi.com/api/v1.0/random?min=1&max=7&count=1";
    public static int diceNum;
    [SerializeField] DiceRoller diceRoller;

    IEnumerator FetchRandomNumber()
    {
        // If the dice is rolling, exit the function
        if (GameManager.startRolling)
        {
            yield break; // Use yield break to exit the coroutine early
        }

        GameManager.startRolling = true;

        using (UnityWebRequest request = UnityWebRequest.Get(apiUrl))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string responseText = request.downloadHandler.text;

                // Parsing the response to get the random number
                if (char.IsDigit(responseText[1]))
                {
                    diceNum = (int)char.GetNumericValue(responseText[1]);
                    // Make the dice number better for arrays
                    diceNum -= 1;

                    // Showing the dice number
                    diceRoller.ShowDiceAnim(diceNum);
                }
                else
                {
                    Debug.LogError("Invalid response format: " + responseText);
                }
            }
            else
            {
                Debug.LogError("Network request failed: " + request.error);
            }
        }
    }

    // This function is made for the roll button to allow fetching every time it is pressed
    public void StartFetching()
    {
        StartCoroutine(FetchRandomNumber());
    }
}

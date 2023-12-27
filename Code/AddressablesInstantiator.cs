using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class AddressablesInstantiator : MonoBehaviour
{

    [SerializeField] private AssetReferenceGameObject _player;
    [SerializeField] private AssetReferenceSprite _dice1;
    [SerializeField] private AssetReferenceSprite _dice2;
    [SerializeField] private AssetReferenceSprite _dice3;
    [SerializeField] private AssetReferenceSprite _dice4;
    [SerializeField] private AssetReferenceSprite _dice5;
    [SerializeField] private AssetReferenceSprite _dice6;
    [SerializeField] private Image[] dices;
    [SerializeField] private GameObject canvas;



    void Start()
    {
        Addressables.InitializeAsync().Completed += AddresableCompleted;
    }
    // Update is called once per frame
    void Update()
    {

    }
    void AddresableCompleted(AsyncOperationHandle<IResourceLocator> obj)
    {
        _player.InstantiateAsync().Completed += (playerOpertation) =>
        {
            GameObject player = playerOpertation.Result;

            // Putting the player inside the canavas without manipulating its position
            player.transform.SetParent(canvas.transform, false);

            // Enable to assign the player in a GameManager variable after it have instantiated
            GameObject.Find("Game Manager").GetComponent<GameManager>().FindPlayer();
        };

        // Load 6 Sprites and add them to the  6 Dices
        _dice1.LoadAssetAsync<Sprite>().Completed += (DiceImage) =>
        {
            dices[0].sprite = DiceImage.Result;
        };
        _dice2.LoadAssetAsync<Sprite>().Completed += (DiceImage) =>
        {
            dices[1].sprite = DiceImage.Result;
        }; ;
        _dice3.LoadAssetAsync<Sprite>().Completed += (DiceImage) =>
        {
            dices[2].sprite = DiceImage.Result;
        }; ;
        _dice4.LoadAssetAsync<Sprite>().Completed += (DiceImage) =>
        {
            dices[3].sprite = DiceImage.Result;
        }; ;
        _dice5.LoadAssetAsync<Sprite>().Completed += (DiceImage) =>
        {
            dices[4].sprite = DiceImage.Result;
        }; ;
        _dice6.LoadAssetAsync<Sprite>().Completed += (DiceImage) =>
        {
            dices[5].sprite = DiceImage.Result;
        }; ;
    }
}

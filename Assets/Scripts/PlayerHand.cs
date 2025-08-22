using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private CardsManager cardsManager;

    public List<CardsManager.Card> playerHand;

    private void Awake()
    {
        cardsManager = GetComponentInParent<CardsManager>();
        playerHand = new List<CardsManager.Card>();

        for (int i = 0; i < 10; i++)
        {
            playerHand.Add(cardsManager.GenerateRandomCard());
        }
    }

    private void Start()
    {
        InitialisePlayerHandGraphics();
    }

    private void InitialisePlayerHandGraphics()
    {
        for(int i = 0; i < playerHand.Count; i++)
        {
            CardsManager.Card card = playerHand[i];

            cardsManager.AssignCardDetails(card, gameObject.transform, i);
        }
    }
}
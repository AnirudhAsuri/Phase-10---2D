using UnityEngine;

public class FaceCardHandler : MonoBehaviour
{
    [SerializeField] private CardsManager cardsManager;
    private CardsManager.Card card;

    private void Awake()
    {
        cardsManager = GetComponentInParent<CardsManager>();
        card = cardsManager.GenerateRandomCard();

        cardsManager.AssignCardDetails(card, gameObject.transform, 1);
    }
}
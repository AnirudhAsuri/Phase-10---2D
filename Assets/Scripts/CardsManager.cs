using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardsManager : MonoBehaviour
{
    public struct Card
    {
        public bool isStarCard;
        public bool isSkipCard;

        public int cardNumber { get; set; }
        public Color cardColor { get; set; }

        public const int MIN_NUMBER = 1;
        public const int MAX_NUMBER = 12;

        private const float STAR_PROBABILITY = 0.1f;
        private const float SKIP_PROBABILITY = 0.1f;

        public Card(Color color, int number)
        {
            isSkipCard = Random.value < SKIP_PROBABILITY;
            if (!isSkipCard)
                isStarCard = Random.value < STAR_PROBABILITY;
            else
                isStarCard = false;

            if(!isStarCard && !isSkipCard)
            {
                cardNumber = number;
                cardColor = color;
            }

            else
            {
                cardNumber = 0;
                cardColor = color;
            }
        }
    }

    public Color[] colors = { Color.red, Color.blue, Color.yellow, Color.green };
    public Card randomCard;

    public Card GenerateRandomCard()
    {
        Color randomColor = colors[Random.Range(0, colors.Length)];
        int randomNumber = Random.Range(1, 12);

        randomCard = new CardsManager.Card(randomColor, randomNumber);

        return randomCard;
    }

    public void AssignCardDetails(Card card,Transform cardHolderPanel, int childCardNumber)
    {
        Transform cardPanel = cardHolderPanel.GetChild(childCardNumber);
        Image backgroundImage = cardPanel.GetComponent<Image>();
        TextMeshProUGUI cardText = cardPanel.GetComponentInChildren<TextMeshProUGUI>();

        if (card.isStarCard)
        {
            if (backgroundImage != null)
                backgroundImage.color = Color.black;
            if (cardText != null)
                cardText.text = "*";
        }

        else if (card.isSkipCard)
        {
            if (backgroundImage != null)
                backgroundImage.color = Color.black;
            if (cardText != null)
                cardText.text = "X";
        }

        else
        {
            if (backgroundImage != null)
            {
                backgroundImage.color = card.cardColor;
            }

            if (cardText != null)
            {
                cardText.text = card.cardNumber.ToString();
            }
        }
    }
}
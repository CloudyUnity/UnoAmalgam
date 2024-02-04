using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardPhysical : MonoBehaviour
{
    Image m_cardFace;
    TMP_Text m_numberText;

    public Card m_card;
    public Player m_player;

    public int m_discardPileIndex;

    private void Awake()
    {
        m_cardFace = transform.Find("CardFace").GetComponent<Image>();
        m_numberText = transform.Find("Number").GetComponent<TMP_Text>();
    }

    public void Init(Card card, Player player)
    {
        m_card = card;
        m_player = player;
    }

    public void Set(Card card)
    {
        m_card = card;
    }

    private void Update()
    {
        UpdateCardColor();
        UpdateCardNumber();
    }

    public void UpdateCardColor()
    {
        if (m_card == null)
            return;

        switch (m_card.m_color)
        {
            case CardData.Color.Red:
                m_cardFace.color = Color.red;
                break;

            case CardData.Color.Green:
                m_cardFace.color = Color.green;
                break;

            case CardData.Color.Blue:
                m_cardFace.color = Color.blue;
                break;

            case CardData.Color.Yellow:
                m_cardFace.color = Color.yellow;
                break;

            default:
                m_cardFace.color = Color.magenta;
                break;
        }
    }

    public void UpdateCardNumber()
    {
        if (m_card == null)
            return;

        switch (m_card.m_number)
        {
            case CardData.Number.n0:
                m_numberText.text = "0";
                break;

            case CardData.Number.n1:
                m_numberText.text = "1";
                break;

            case CardData.Number.n2:
                m_numberText.text = "2";
                break;

            case CardData.Number.n3:
                m_numberText.text = "3";
                break;

            case CardData.Number.n4:
                m_numberText.text = "4";
                break;

            case CardData.Number.n5:
                m_numberText.text = "5";
                break;

            case CardData.Number.n6:
                m_numberText.text = "6";
                break;

            case CardData.Number.n7:
                m_numberText.text = "7";
                break;

            case CardData.Number.n8:
                m_numberText.text = "8";
                break;

            case CardData.Number.n9:
                m_numberText.text = "9";
                break;

            case CardData.Number.n50:
                m_numberText.text = "50";
                break;

            default:
                m_numberText.text = "?";
                break;
        }
    }

    public void SelectCard()
    {
        if (m_player == null)
        {
            DiscardPileClicked();
            return;
        }            

        m_player.SelectCard(this);
    }

    public void DiscardPileClicked()
    {

    }
}

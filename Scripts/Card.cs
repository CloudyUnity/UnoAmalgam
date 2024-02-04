using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card
{
    public CardData m_cardData;
    public CardData.Number m_number;
    public CardData.Color m_color;
    public Card m_flipSide;

    public void Init(CardData data)
    {
        m_cardData = data;
        m_color = data.m_BaseColor;
        m_number = data.m_BaseNumber;
    }

    public bool CanPlayOn(Card belowCard)
    {
        foreach (string black in m_cardData.m_playBlacklist)
        {
            if (belowCard.m_cardData.m_tags.Contains(black))
                return false;
        }

        if (m_color == CardData.Color.Wild || m_number == CardData.Number.Wild)
            return true;

        if (belowCard.m_color == m_color && m_color != CardData.Color.None)
            return true;

        if (belowCard.m_number == m_number && m_number != CardData.Number.None)
            return true;

        foreach (string white in m_cardData.m_playWhitelist)
        {
            if (belowCard.m_cardData.m_tags.Contains(white))
                return true;
        }

        return false;
    }
}

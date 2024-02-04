using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<CardPhysical> m_Hand;
    public bool m_canPlayCard = false;

    public CardPhysical m_selectedCard;

    private void Update()
    {
        for (int i = 0; i < m_Hand.Count; i++)
        {
            float t = i / (float)(m_Hand.Count - 1);
            float t05 = 2 * Mathf.Abs(t - 0.5f);

            float x = Mathf.Lerp(-375, 375, t);
            float y = Mathf.Lerp(-350, -425, t05);
            float r = Mathf.Lerp(40, -40, t);

            m_Hand[i].transform.localPosition = new Vector3(x, y, 0);
            m_Hand[i].transform.localRotation = Quaternion.Euler(0, 0, r);
        }
    }

    public bool CanPlayAnyCard()
    {
        for (int i = 0; i < m_Hand.Count; i++)
        {
            if (DeckManager.m_Instance.CanPlayCard(m_Hand[i].m_card))
                return true;
        }
        return false;
    }

    public void GiveCard(Card card)
    {
        var cardP = Instantiate(DeckManager.m_Instance.m_cardPhysicalPrefab, GameLoopManager.Canvas.transform);
        cardP.Init(card, this);
        m_Hand.Add(cardP);
    }

    public void GiveCard(IList<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            var cardP = Instantiate(DeckManager.m_Instance.m_cardPhysicalPrefab, GameLoopManager.Canvas.transform);
            cardP.Init(cards[i], this);
            m_Hand.Add(cardP);
        }
    }

    public async Task PlayCard()
    {
        m_canPlayCard = true;
        while (m_canPlayCard)
        {
            await Task.Delay(10);
        }
    }

    public bool CheckWinner()
    {
        return m_Hand.Count <= 0; 
    }

    public bool CheckLoser()
    {
        return m_Hand.Count >= 25;
    }

    public void SelectCard(CardPhysical card)
    {
        m_selectedCard = card;
    }
}

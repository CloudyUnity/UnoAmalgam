using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public static DeckManager m_Instance;

    public CardData[] m_AllCardData;

    public List<Card> m_DrawPile = new List<Card>();

    public Stack<Card> m_Discard1 = new Stack<Card>();
    public Stack<Card> m_Discard2 = new Stack<Card>();
    public Stack<Card> m_Discard3 = new Stack<Card>();
    public Stack<Card> m_Discard4 = new Stack<Card>();

    public CardPhysical m_DiscardPhysical1, m_DiscardPhysical2, m_DiscardPhysical3, m_DiscardPhysical4;

    public CardPhysical m_cardPhysicalPrefab;

    private void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        else if (m_Instance != this)
            Destroy(gameObject);
    }

    public void Init()
    {
        for (int i = 0; i < m_AllCardData.Length; i++)
        {
            Card card = new Card();
            card.Init(m_AllCardData[i]);

            PushCard(card);
        }

        ShuffleDeck();

        m_Discard1.Push(PopCard());
        m_Discard2.Push(PopCard());
        m_Discard3.Push(PopCard());
        m_Discard4.Push(PopCard());        
    }

    public void AddExtraCardsDebug()
    {
        for (int i = 0; i < m_AllCardData.Length; i++)
        {
            Card card = new Card();
            card.Init(m_AllCardData[i]);

            PushCard(card);
        }
    }

    private void Update()
    {
        m_DiscardPhysical1.Set(m_Discard1.Peek());
        m_DiscardPhysical2.Set(m_Discard2.Peek());
        m_DiscardPhysical3.Set(m_Discard3.Peek());
        m_DiscardPhysical4.Set(m_Discard4.Peek());
    }

    public void ShuffleDeck()
    {
        m_DrawPile.ShuffleList();
    }

    public Card PopCard()
    {
        if (m_DrawPile.Count == 0)
            AddExtraCardsDebug();

        Card card = m_DrawPile[m_DrawPile.Count - 1];
        m_DrawPile.RemoveAt(m_DrawPile.Count - 1);
        return card;
    }

    public Card[] PopCard(int num)
    {
        if (m_DrawPile.Count < num)
            AddExtraCardsDebug();

        Card[] cards = new Card[num];

        for (int i = 0; i < num; i++)
        {
            cards[i] = m_DrawPile[m_DrawPile.Count - 1];
            m_DrawPile.RemoveAt(m_DrawPile.Count - 1);
        }        

        return cards;
    }

    public void PushCard(Card card)
    {
        m_DrawPile.Add(card);
    }

    public bool CanPlayCard(Card card)
    {
        if (card.CanPlayOn(m_Discard1.Peek()))
            return true;

        if (card.CanPlayOn(m_Discard2.Peek()))
            return true;

        if (card.CanPlayOn(m_Discard3.Peek()))
            return true;

        if (card.CanPlayOn(m_Discard4.Peek()))
            return true;

        return false;
    }    
}

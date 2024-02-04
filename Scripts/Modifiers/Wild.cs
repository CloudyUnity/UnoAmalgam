using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Wild : IModifier
{
    async Task IModifier.IDiscard(Card card)
    {
        CardData.Color color = await GameLoopManager.m_Instance.PickColor();

        card.m_color = color;
    }

    Task IModifier.IPickup(Card card)
    {
        throw new System.NotImplementedException();
    }

    Task IModifier.IPlayedOn(Card card, Card belowCard)
    {
        throw new System.NotImplementedException();
    }
}

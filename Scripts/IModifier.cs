using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IModifier
{
    Task IDiscard(Card card);
    Task IPickup(Card card);
    Task IPlayedOn(Card card, Card belowCard);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "New CardData")]
public class CardData : ScriptableObject
{
    public enum Number
    {
        n0, n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n50, None, Wild
    }

    public enum Color
    {
        Red, Green, Blue, Yellow, Pink, Orange, Grey, Cyan, None, Wild
    }

    public Number m_BaseNumber;
    public Color m_BaseColor;
    public List<IModifier> m_modifiers;
    public List<string> m_tags;    

    public List<string> m_playWhitelist;
    public List<string> m_playBlacklist;
}

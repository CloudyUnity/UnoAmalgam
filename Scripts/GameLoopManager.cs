using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    public static GameLoopManager m_Instance;

    List<Player> m_Players = new List<Player>();
    int m_currentPlayer;
    bool m_dirRight = true;

    bool m_insideGameLoop;
    bool m_gameStarted;

    public Player m_PlayerPrefab;
    public static GameObject Canvas;

    private void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        else if (m_Instance != this)
            Destroy(this);

        Canvas = GameObject.Find("Canvas");
    }

    private void Start()
    {
        Initialize(2);
    }

    public void Initialize(int playerCount)
    {
        print("Init");

        DeckManager.m_Instance.Init();

        for (int i = 0; i < playerCount; i++)
            m_Players.Add(Instantiate(m_PlayerPrefab));

        foreach (var player in m_Players)
        {
            player.GiveCard(DeckManager.m_Instance.PopCard(7));
        }

        m_currentPlayer = Random.Range(0, m_Players.Count);

        m_gameStarted = true;
    }

    private async void Update()
    {
        if (m_insideGameLoop || !m_gameStarted)
            return;

        m_insideGameLoop = true;
        await GameLoop();
        ChangeCurrentPlayer(1);
        m_insideGameLoop = false;
    }

    public async Task<int> GameLoop()
    {       
        Player curPlayer = m_Players[m_currentPlayer];

        print("Can player " + m_currentPlayer + " play card?");
        if (!curPlayer.CanPlayAnyCard())
        {
            print("No");
            curPlayer.GiveCard(DeckManager.m_Instance.PopCard());
            return 0;
        }
        print("Yes");

        await curPlayer.PlayCard();

        foreach (var player in m_Players)
        {
            if (player.CheckWinner())
                PlayerWon(player);
            if (player.CheckLoser())
                PlayerEliminated(player);
        }

        return 0;
    }

    // TODO: Add Color picker
    public async Task<CardData.Color> PickColor()
    {
        System.Array allColors = System.Enum.GetValues(typeof(CardData.Color));
        return (CardData.Color)allColors.GetValue(Random.Range(0, allColors.Length));
    }

    public void ChangeCurrentPlayer(int add)
    {
        if (!m_dirRight)
            add = -add;

        m_currentPlayer = Mathf.Abs((m_currentPlayer + add) % m_Players.Count);
    }

    public void PlayerWon(Player player)
    {

    }

    public void PlayerEliminated(Player player)
    {

    }

    public void DiscardPileClicked(int index)
    {
        CardPhysical selected = m_Players[m_currentPlayer].m_selectedCard;
        if (selected == null)
            return;

        if (index == 0)
            DeckManager.m_Instance.m_Discard1.Push(selected.m_card);
    }
}

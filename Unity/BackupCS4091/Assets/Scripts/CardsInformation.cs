
using UnityEngine;

public class CardsInformation : MonoBehaviour
{
    // Player who owns the card
    private int player = 0; // Player 1 or Player 2
    [SerializeField] private int symbol;   // 1 for wifi, 2 for lock, 3 for shield, 4 for houses, 5 for all
    [SerializeField] private int color;  // 1 for Blue, 2 for Green, 3 for Red
    private bool isDrop;
    private GameManager gameManager;

    void Start()
    {
        isDrop = false;
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }
    }
    public int GetColor()
    {
        return color;
    }

    public void setDrop()
    {
        isDrop = true;
    }
    public bool GetDrop()
    {
        return isDrop;
        gameManager.switchTurn();
    }

    public void SetPlayer(int player)
    {
        this.player = player;
        Debug.LogError("this card is set to player" + this.player);
    }

    public int GetPlayer()
    {
        return player;
    }

    public int GetSymbol()
    {
        return this.symbol;
    }

    public bool CompareSymbol(CardsInformation otherCardInfo1, CardsInformation otherCardInfo2)
    {
        if (otherCardInfo1.GetSymbol() == otherCardInfo2.GetSymbol() || otherCardInfo1.GetSymbol() == 5 || otherCardInfo2.GetSymbol() == 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}

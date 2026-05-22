using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentPlayer = 1;

    void Awake()
    {
        Instance = this;
    }

    public void ChangeTurn()
    {
        if(currentPlayer == 1)
        {
            currentPlayer = 2;
        }
        else
        {
            currentPlayer = 1;
        }

        Debug.Log("Jogador atual: " + currentPlayer);
    }
}
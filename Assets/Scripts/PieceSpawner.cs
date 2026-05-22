using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    public GameObject redPiece;
    public GameObject yellowPiece;

    GridData gridData;

    int width = 7;
    int height = 6;

    void Start()
    {
        gridData = new GridData(width, height);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            DetectColumn();
        }
    }

    void DetectColumn()
    {
        Vector3 mousePosition =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        int column =
            Mathf.RoundToInt(mousePosition.x);

        DropPiece(column);
    }

    void DropPiece(int column)
    {
        if(column < 0 || column >= width)
            return;

        for(int y = 0; y < height; y++)
        {
            if(gridData.grid[column, y] == 0)
            {
                SpawnPiece(column, y);

                GameManager.Instance.ChangeTurn();

                break;
            }
        }
    }

    void SpawnPiece(int x, int y)
    {
        GameObject prefab;

        int player =
            GameManager.Instance.currentPlayer;

        if(player == 1)
        {
            prefab = redPiece;

            gridData.grid[x, y] = 1;
        }
        else
        {
            prefab = yellowPiece;

            gridData.grid[x, y] = 2;
        }

        Instantiate(
            prefab,
            new Vector3(x, y, 0),
            Quaternion.identity
        );
    }
}
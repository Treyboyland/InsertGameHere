using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMapUI : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;

    [SerializeField]
    ObjectPool pool;

    [SerializeField]
    RectTransform gridTransform;

    [SerializeField]
    GridLayoutGroup grid;

    /*
        Formula Grid Width = cell width * num columns + (num columns - 1) * spacing x
        Formula Grid Height = cell height * num rows + (num rows - 1) * spacing y
    */

    static GameMapCreator mapCreator;

    List<GameMapPieceUI> currentPieces = new List<GameMapPieceUI>();

    GameMapPieceUI[,] rooms;

    Vector2Int currentPlayerPosition;

    readonly List<Vector2Int> offsets = new List<Vector2Int>()
    {
        new Vector2Int(-1,0),
        new Vector2Int(1,0),
        new Vector2Int(0,0),
        new Vector2Int(0,1),
        new Vector2Int(0,-1)
    };

    // Start is called before the first frame update
    void Start()
    {
        FindMapReference();
        canvas.gameObject.SetActive(false);
    }

    public void DiscoverAll()
    {
        foreach (var piece in currentPieces)
        {
            piece.IsDiscovered = true;
            piece.SetColors(currentPlayerPosition);
        }
    }

    void UnparentAll()
    {
        foreach (var piece in currentPieces)
        {
            piece.ResetData();
            piece.transform.SetParent(null);
        }
    }

    void FindMapReference()
    {
        if (mapCreator == null)
        {
            mapCreator = GameObject.FindObjectOfType<GameMapCreator>();
        }
    }

    public void DiscoverAdjacent(Vector3Int position)
    {
        currentPlayerPosition = (Vector2Int)position;
        DiscoverAdjacent(currentPlayerPosition);
    }

    public void DiscoverAdjacent(Vector2Int position)
    {
        FindMapReference();

        rooms[position.x, position.y].IsDiscovered = true;
        rooms[position.x, position.y].SetColors(position);

        foreach (var offset in offsets)
        {
            Vector2Int newPos = position + offset;
            if (newPos.x < rooms.GetLength(0) && newPos.x >= 0 && newPos.y < rooms.GetLength(1) && newPos.y >= 0)
            {
                rooms[newPos.x, newPos.y].IsDiscovered = true;
                rooms[newPos.x, newPos.y].SetColors(position);
            }
        }
    }

    void SetGridSize(Vector2Int dimensions)
    {
        float width = dimensions.x * grid.cellSize.x + (dimensions.x - 1) * grid.spacing.x;
        float height = dimensions.y * grid.cellSize.y + (dimensions.y - 1) * grid.spacing.y;
        gridTransform.sizeDelta = new Vector2(width, height);
    }

    public void ToggleMap()
    {
        canvas.gameObject.SetActive(!canvas.gameObject.activeInHierarchy);
    }

    public void SetInitialMap()
    {
        bool initialState = canvas.gameObject.activeSelf;
        canvas.gameObject.SetActive(true);
        FindMapReference();
        UnparentAll();
        currentPieces.Clear();
        pool.DisableAll();
        var data = mapCreator.MapData;

        Vector2Int dimensions = new Vector2Int();
        dimensions.x = data.Map.GetLength(0);
        dimensions.y = data.Map.GetLength(1);
        Debug.LogWarning("Dimensions: " + dimensions);
        SetGridSize(dimensions);

        //X -> Rank 0, Y -> Rank 1
        rooms = new GameMapPieceUI[dimensions.x, dimensions.y];

        for (int x = 0; x < rooms.GetLength(0); x++)
        {
            for (int y = 0; y < rooms.GetLength(1); y++)
            {
                var piece = pool.GetObject().GetComponent<GameMapPieceUI>();
                piece.gameObject.SetActive(true);
                piece.CurrentPosition = new Vector2Int(x, y);
                piece.IsActiveRoom = data.Map[x, y];
                piece.transform.SetParent(gridTransform);

                rooms[x, y] = piece;
                currentPieces.Add(piece);
                piece.SetColors(data.StartingPosition);
            }
        }

        foreach (var roomLocation in mapCreator.SpecialRoomLocations)
        {
            rooms[roomLocation.x, roomLocation.y].IsSpecial = true;
        }

        DiscoverAdjacent(data.StartingPosition);
        canvas.gameObject.SetActive(initialState);
    }


}

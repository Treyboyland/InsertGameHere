using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;


public class Room : MonoBehaviour
{
    [SerializeField]
    rho.ConfigFloat secondsBeforeSpawn;

    [SerializeField]
    bool isOpen;

    [SerializeField]
    EnemySpawner enemySpawner;

    public UnityEvent<bool> OnOpenStateChanged = new UnityEvent<bool>();

    RoomThemeSO currentTheme;

    public UnityEvent<RoomThemeSO> OnSetTheme = new UnityEvent<RoomThemeSO>();

    public bool IsOpen
    { get { return isOpen; } set { isOpen = value; OnOpenStateChanged.Invoke(isOpen); } }

    /// <summary>
    /// Location of this room on the map
    /// </summary>
    Vector2Int roomLocation;

    /// <summary>
    /// Location of this room on the map
    /// </summary>
    /// <value></value>
    public Vector2Int RoomLocation { get { return roomLocation; } set { roomLocation = value; } }

    [Header("Spawns for player")]
    [SerializeField]
    GameObject leftPlayerSpawn, rightPlayerSpawn, upPlayerSpawn, downPlayerSpawn, centerPlayerSpawn;

    [Header("Doors")]
    [SerializeField]
    DoorType leftDoor, rightDoor, upDoor, downDoor;

    [Header("Exit Triggers")]
    GameObject leftTrigger, rightTrigger, upTrigger, downTrigger;

    public GameObject LeftPlayerSpawn { get { return leftPlayerSpawn; } }
    public GameObject RightPlayerSpawn { get { return rightPlayerSpawn; } }
    public GameObject UpPlayerSpawn { get { return upPlayerSpawn; } }
    public GameObject DownPlayerSpawn { get { return downPlayerSpawn; } }
    public GameObject CenterPlayerSpawn { get { return centerPlayerSpawn; } }

    public bool CanLeftOpen { get; set; } = false;
    public bool CanRightOpen { get; set; } = false;
    public bool CanUpOpen { get; set; } = false;
    public bool CanDownOpen { get; set; } = false;

    List<GameObject> spawnedObjects = new List<GameObject>();
    List<GameObject> enemies = new List<GameObject>();

    List<Vector2> chosenEnemyPositions = new List<Vector2>();

    List<EnemySpawner> createdSpawners = new List<EnemySpawner>();

    EverythingARoomNeedsForSpawn everything;

    int rating;

    private void Awake()
    {
        OnSetTheme.AddListener(newTheme => currentTheme = newTheme);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public bool CanDoorOpen(DoorType doorType)
    {
        if (doorType == leftDoor)
        {
            return CanLeftOpen;
        }
        else if (doorType == rightDoor)
        {
            return CanRightOpen;
        }
        else if (doorType == upDoor)
        {
            return CanUpOpen;
        }
        else if (doorType == downDoor)
        {
            return CanDownOpen;
        }
        return false;
    }

    /// <summary>
    /// Destroys the old stuff in the room
    /// </summary>
    public void DestroyOldStuff()
    {
        //TODO: Inefficient
        foreach (var obj in spawnedObjects)
        {
            Destroy(obj);
        }

        foreach (var obj in createdSpawners)
        {
            obj.DestroySpawnedEnemy();
            Destroy(obj.gameObject);
        }
        chosenEnemyPositions.Clear();
        createdSpawners.Clear();
        spawnedObjects.Clear();
    }

    public void GenerateRoomStuff(EverythingARoomNeedsForSpawn roomData, int challengeRating)
    {
        everything = roomData;
        rating = challengeRating;
        DestroyOldStuff();

        foreach (var spawn in roomData.Spawns)
        {
            var obj = Instantiate(spawn.Prefab, transform);
            obj.transform.localPosition = spawn.Location;
            spawnedObjects.Add(obj);

            var themed = obj.GetComponent<RoomThemeSetter>();
            if (themed)
            {
                themed.UpdateTheme(currentTheme);
            }
        }


        //Create Spawners
        if (roomData.EnemySpawnLocations != null && roomData.EnemySpawnLocations.Count > 0)
        {
            //Make sure that each enemy spawn location has at least 1 challenge point
            var possibleConfigs = roomData.EnemySpawnLocations.Where(x => x.Count <= challengeRating).ToList();
            if (possibleConfigs.Count > 0)
            {
                int chosenIndex = UnityEngine.Random.Range(0, possibleConfigs.Count);
                chosenEnemyPositions = possibleConfigs[chosenIndex].CloneList(); //Normal set here results in data loss on clear
                CreateEnemySpawners(challengeRating);
            }
        }
    }

    void CreateEnemySpawners(int challengeRating)
    {
        if (chosenEnemyPositions.Count == 0)
        {
            Debug.LogWarning("No enemy positions found for room " + roomLocation +". Challenge Rating: " + challengeRating);
            return;
        }
        List<int> ratingsPerSpawner = new List<int>(chosenEnemyPositions.Count);
        int ratingPerSpawn = challengeRating / chosenEnemyPositions.Count;
        int remainder = challengeRating % chosenEnemyPositions.Count;

        for (int i = 0; i < chosenEnemyPositions.Count; i++)
        {
            ratingsPerSpawner.Add(ratingPerSpawn);
        }

        for (int i = 0; i < remainder; i++)
        {
            int chosenIndex = UnityEngine.Random.Range(0, ratingsPerSpawner.Count);
            ratingsPerSpawner[chosenIndex] = ratingsPerSpawner[chosenIndex] + 1;
        }

        for (int i = 0; i < ratingsPerSpawner.Count; i++)
        {
            int rating = ratingsPerSpawner[i];
            Vector2 pos = chosenEnemyPositions[i];
            var spawner = Instantiate(enemySpawner, transform);
            spawner.transform.localPosition = pos;
            spawner.SelectEnemy(rating);
            createdSpawners.Add(spawner);
        }
    }

    public void CheckToSpawnEnemies(Vector3Int pos)
    {
        Vector2Int posCast = new Vector2Int(pos.x, pos.y);

        if (gameObject.activeInHierarchy && posCast == roomLocation)
        {
            BeginSpawning();
        }
        else
        {
            StopSpawning();
        }
    }

    void BeginSpawning()
    {
        foreach (var spawner in createdSpawners)
        {
            spawner.SpawnEnemy(this);
        }
    }

    void StopSpawning()
    {
        foreach (var spawner in createdSpawners)
        {
            spawner.StopEnemySpawn();
        }
    }
}

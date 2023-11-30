using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnAtTimeEnd : MonoBehaviour
{
    [SerializeField] private GameTime gameTime;

    [SerializeField] float distanceFromPlayer;

    [SerializeField] private Enemy enemy;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        enemy.gameObject.SetActive(false);
        gameTime.OnTimeRemaining.AddListener(SpawnIfTimeZero);
    }

    void SpawnIfTimeZero(float remaining)
    {
        if (remaining <= 0 && !enemy.gameObject.activeInHierarchy)
        {
            enemy.transform.position = GetSpawnPosition();
            enemy.gameObject.SetActive(true);
        }
        else if (remaining > 0 && enemy.gameObject.activeInHierarchy)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    Vector3 GetSpawnPosition()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }

        if (player == null)
        {
            return Vector3.zero;
        }

        float angle = Random.Range(0.0f, 360f);
        Vector3 distanceVector = Vector3.up * distanceFromPlayer;
        distanceVector = Quaternion.AngleAxis(angle, Vector3.forward) * distanceVector;

        return player.transform.position + distanceVector;
    }
}

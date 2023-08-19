using System.Collections;
using System.Collections.Generic;
using Game.Reader.Games.ShootingGame;
using UnityEngine;

public class WitchInitializer : MonoBehaviour
{
    [SerializeField] private WitchMovement witchPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private void GetRandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        WitchMovement witchMovement = Instantiate(witchPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        
        
    }
}

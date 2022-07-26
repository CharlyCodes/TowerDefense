using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private WavesData _wavesData;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _weakEnemyPrefab;
    [SerializeField] private GameObject _midEnemyPrefab;
    [SerializeField] private GameObject _heavyEnemyPrefab;
    [SerializeField] private float _minSpawnDelay = 1;
    [SerializeField] private float _maxSpawnDelay = 3;
    [SerializeField] private float _timeBetweenWaves = 5;
    [SerializeField] private UnityEvent OnWavesEnded;
    private int _waveNumber;

    private void Start() {
        StartCoroutine(CreateNewEnemyWave());
    }

    IEnumerator CreateNewEnemyWave(){
        while(_waveNumber < _wavesData.Waves.Length){
            yield return new WaitForSeconds(_timeBetweenWaves);
            StartCoroutine(SpawnEnemies(_wavesData.Waves[_waveNumber].WeakEnemies, _weakEnemyPrefab));
            StartCoroutine(SpawnEnemies(_wavesData.Waves[_waveNumber].MidEnemies, _midEnemyPrefab));
            StartCoroutine(SpawnEnemies(_wavesData.Waves[_waveNumber].HeavyEnemies, _heavyEnemyPrefab));

            while (GameManager.Instance.EnemyCount > 0 ){
                yield return null;
            }
            //yield return new WaitForSeconds(5);
            _waveNumber++;
        }
        //Winner
    OnWavesEnded?.Invoke();
    }

    IEnumerator SpawnEnemies (int enemyAmount, GameObject enemyPrefab){
        for (int i = 0; i < enemyAmount; i++){
            Instantiate(enemyPrefab, _spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
        }
    }


}

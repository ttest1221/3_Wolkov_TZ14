using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _finish;
    private float _spawnTime;
    private bool _end = false;

    private List<GameObject> _spawned = new List<GameObject>();
    void Update()
    {
        if (Time.time > _spawnTime && _gameManager.gameStarted == true && _gameManager.score < 100)
        {
            Spawn();
            _spawnTime = Time.time + _timeBetweenSpawn;
        }
        if (_gameManager.score >= 100 && _end == false)
        {
            Instantiate(_finish, _spawned[_spawned.Count-1].transform.position, transform.rotation);
            for (int i = 0; i < _spawned.Count; i++)
                Destroy(_spawned[i]);
            _end = true;
        }

    }
    private void Spawn()
    {
        int randomY = Random.Range(2, 7);
        _spawned.Add(Instantiate(_obstacle, transform.position + new Vector3(20, randomY, 0), transform.rotation));
        
        
    }
}

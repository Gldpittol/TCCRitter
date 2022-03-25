using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Vector2 _spawnPosition;
    private GameManager _instance;

    public GameManager Instance { get { return _instance; } }

    void Awake()
    {
        if(!_instance)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        Instantiate(_playerPrefab, _spawnPosition, Quaternion.identity);
    }
}

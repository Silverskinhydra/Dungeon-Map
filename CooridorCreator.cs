using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CooridorCreator : MonoBehaviour
{
    //variable options

    [SerializeField] private Tile _tileprefab;

    [SerializeField] private Transform _start;

    [SerializeField] private Transform _end;

    [SerializeField] private int _width;

    // Start is called before the first frame update
    void Start() 
    {
        GenerateCooridor();
    }
    void GenerateCooridor()
    {

            //Starting Coordinates
        int _xStart = (int)_start.transform.position.x;
        int _yStart = (int)_start.transform.position.y;

            //Ending Coordinates
        int _xEnd = (int)_end.transform.position.x - 1;
        int _yEnd = (int)_end.transform.position.y;

            //determining Rise and Run
        int _rise = (int)_yEnd - _yStart;
        int _run = (int)_xEnd - _xStart;

        //rng
        Random rnd = new Random();
        int _coin = (int)rnd.Next(1, 2);

        //spawning right sided
        if (_coin == 1)
        {
            for (int x = _xStart - 1; x <= _xEnd; x++)
            {
                for (int y = _yStart; y < _yStart + _width; y++)
                {
                    var spawnedTile = Instantiate(_tileprefab, new Vector3(x, y), Quaternion.identity);
                    spawnedTile.name = $"Coridor {x} {y}";
                }

            }
            for (int y = _yStart; y <= _yEnd; y++)
            {
                for (int x = _xEnd; x < _xEnd + _width; x++)
                {
                    var spawnedTile = Instantiate(_tileprefab, new Vector3(x, y), Quaternion.identity);
                    spawnedTile.name = $"Coridor {x} {y}";
                }
            }
            for (int y = _yEnd; y <= _yEnd; y++) 
            {
                for (int x = _xEnd; x == _xEnd; x++)
                {
                    var spawnedTile = Instantiate(_tileprefab, new Vector3(x, y), Quaternion.identity);
                    spawnedTile.name = $"Coridor {x} {y}";
                }
            }
        }
        //spawning left sided
        if (_coin == 2) {
            for (int x = _xStart; x <= _xEnd; x++)
            {
                for (int y = _yEnd; y <= _yEnd; y++)
                {
                    var spawnedTile = Instantiate(_tileprefab, new Vector3(x, y), Quaternion.identity);
                    spawnedTile.name = $"Coridor {x} {y}";
                }

            }
            for (int y = _yStart; y <= _yEnd; y++)
            {
                for (int x = _xStart; x <= _xStart; x++)
                {
                    var spawnedTile = Instantiate(_tileprefab, new Vector3(x, y), Quaternion.identity);
                    spawnedTile.name = $"Coridor {x} {y}";
                }
            }
        }
    }
}
        
    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private float _scale1, _ratio1;

    [SerializeField] private Tile _tileprefab;

    [SerializeField] private Transform _origin;

    [SerializeField] private bool _westExit, _eastExit, _northExit, _southExit;

    [SerializeField] private MyEnum _shape  = new MyEnum ();

    public enum MyEnum
    {
        Rectangular,
        Orthagonal
    };
    
    void Start(){
        GenerateGrid();
    }

    void GenerateGrid()
    {
        //_ratio to int
        float _ratioint1 = _ratio1 * _scale1;

        //Scale Conversion
        int _length = (int)_scale1;
        int _height = (int)_ratioint1;

        //x,y
        int _x = (int)_origin.transform.position.x;
        int _y = (int)_origin.transform.position.y;
        int _radius = _length/2;

        //Temp Var
        int TempY = _y + _radius;
        int TempLimit = _x + _radius;
        int TempTarget = _x + _radius;
        int Tempradius = _radius + _y;
        int TempradiusB = ((-1* _radius) + _y);


        //Create Rectangle
        if(_shape == MyEnum.Rectangular){
            for (int x = _x ; x < _length + _x; x++)
            {
                for (int y = _y; y < _height + _y; y++)
                {
                    var spawnedTile = Instantiate (_tileprefab, new Vector3 (x, y), Quaternion.identity);
                    spawnedTile.name = $"Tile {x} {y}";
                }

            }

            //Create Doors
            if( _westExit == true) 
            {
                for (int x = _x -1; x < _x; x++)
                {
                    for (int y = (_height % 2) + _y + 1; y <= (_height % 2) + _y + 1; y++)
                    {
                        var spawnedTile = Instantiate (_tileprefab, new Vector3 (x, y), Quaternion.identity);
                        spawnedTile.name = $"West Exit {x} {y}";
                    }
                }
            }
            if( _eastExit == true) 
            {
                for (int x = _length + _x + 1; x < _length+ _x + 1; x++)
                {
                    for (int y = (_height % 2) + 1 + _y; y <= (_height % 2) + _y + 1; y++)
                    {
                        var spawnedTile = Instantiate (_tileprefab, new Vector3 (x, y), Quaternion.identity);
                    spawnedTile.name = $"East Exit {x} {y}";
                    }
                }    
            }
            if( _northExit == true) 
            {
                for (int x = (_length % 2) + _x + 1; x <= (_length % 2) +_x + 1; x++)
                {
                    for (int y = _height + _y; y <= _height + _y; y++)
                    {
                        var spawnedTile = Instantiate (_tileprefab, new Vector3 (x, y), Quaternion.identity);
                        spawnedTile.name = $"North Exit {x} {y}";
                    }
                }
            }
            if( _southExit == true) 
            {
                for (int x = (_length % 2) + _x + 1; x <= (_length % 2) + _x + 1; x++)
                {
                    for (int y = _y - 1; y <= _y; y++)
                    {
                        var spawnedTile = Instantiate (_tileprefab, new Vector3 (x, y), Quaternion.identity);
                    spawnedTile.name = $"South Exit {x} {y}";
                    }
                }    
            }  
        }
        
        //Create Diamond
        if( _shape == MyEnum.Orthagonal)
        {
            while (TempY >= TempradiusB)
            {
            
                for (int x = TempLimit; x <= TempTarget; x++)
                {
                    for(int y = Tempradius; y <= Tempradius; y++)
                    {
                        var spawnedTile = Instantiate (_tileprefab, new Vector3 (x, y), Quaternion.identity);
                        spawnedTile.name = $"Test {x} {y}";
                    }
                }
                if (TempY > (_y))
                {
                    TempLimit--;
                    TempTarget++;
                }
                else
                {
                    TempLimit++;
                    TempTarget--;
                }
                TempradiusB--;
                Tempradius--;
                
            }
        }
    }
}

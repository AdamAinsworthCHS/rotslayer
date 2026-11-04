using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool cleared = false;
    public bool treasureTaken = false;
    public List<GameObject> enemies;
    public List<Vector2> enemyPositions;
    public List<GameObject> objects;
    public List<Vector2> objectPositions;
    public string roomType;

    [Header("Boss Wave Room Properties")]
    public List<GameObject> wave1;
    public List<Vector2> wave1Pos;
    public List<GameObject> wave2;
    public List<Vector2> wave2Pos;
    public List<GameObject> wave3;
    public List<Vector2> wave3Pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

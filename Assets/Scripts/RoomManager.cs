using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<Room> rooms;
    public int position;
    public bool combat;
    public List<GameObject> currentEnemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        combat = false;
        for (int i = 0; i < rooms.Count; i++)
        {
            rooms[i].cleared = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemies.Count <= 0)
        {
            combat = false;
            rooms[position].cleared = true;
        }
    }

    // called when the room is entered
    public void InitiateRoom()
    {
        if (rooms[position].cleared == false)
        {
            for (int i = 0; i < rooms[position].enemies.Count; i++)
            {
                GameObject clone = Instantiate(rooms[position].enemies[i], rooms[position].enemyPositions[i], transform.rotation);
            }
            combat = true;
        }
        
        for (int i = 0; i < rooms[position].objects.Count; i++)
        {
            GameObject clone = Instantiate(rooms[position].objects[i], rooms[position].objectPositions[i], transform.rotation);
        }
    }
}

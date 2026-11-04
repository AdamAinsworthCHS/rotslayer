using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<Room> rooms;
    public int position;
    public bool combat;
    public List<GameObject> currentEnemies;
    public int bossWave;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        combat = false;
        for (int i = 0; i < rooms.Count; i++)
        {
            rooms[i].cleared = false;
            rooms[i].treasureTaken = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemies.Count <= 0)
        {
            if (rooms[position].roomType == "Boss")
            {
                if (bossWave == 1)
                {
                    for (int i = 0; i < rooms[position].wave2.Count; i++)
                    {
                        GameObject clone = Instantiate(rooms[position].wave2[i], rooms[position].wave2Pos[i], transform.rotation);
                    }
                    bossWave += 1;
                }
                else if (bossWave == 2)
                {
                    for (int i = 0; i < rooms[position].wave3.Count; i++)
                    {
                        GameObject clone = Instantiate(rooms[position].wave3[i], rooms[position].wave3Pos[i], transform.rotation);
                    }
                    bossWave += 1;
                }
                else
                {
                    combat = false;
                    rooms[position].cleared = true;
                }
                
            }
            else
            {
                combat = false;
                rooms[position].cleared = true;
            }
        }
    }

    // called when the room is entered
    public void InitiateRoom()
    {
        if (rooms[position].cleared == false)
        {
            if (rooms[position].roomType == "Boss")
            {
                bossWave = 1;
                for (int i = 0; i < rooms[position].wave1.Count; i++)
                {
                    GameObject clone = Instantiate(rooms[position].wave1[i], rooms[position].wave1Pos[i], transform.rotation);
                }
                combat = true;
            }
            else
            {
                for (int i = 0; i < rooms[position].enemies.Count; i++)
                {
                    GameObject clone = Instantiate(rooms[position].enemies[i], rooms[position].enemyPositions[i], transform.rotation);
                }
                combat = true;
            }
            
        }
        
        for (int i = 0; i < rooms[position].objects.Count; i++)
        {
            if (rooms[position].objects[i].GetComponent<RandomItem>() != null)
            {
                if (rooms[position].treasureTaken == false)
                {
                    GameObject itemSpawner = Instantiate(rooms[position].objects[i], rooms[position].objectPositions[i], transform.rotation);
                }
            }
            else
            {
                GameObject clone = Instantiate(rooms[position].objects[i], rooms[position].objectPositions[i], transform.rotation);
            }
        }
    }
}

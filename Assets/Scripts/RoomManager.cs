using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<Room> rooms;
    public int position;
    public bool combat;
    public List<GameObject> currentEnemies;
    public int bossWave;
    public GameObject blankPlayer;
    private GameObject[] players;

    [Header("Room Indexes")]
    public List<Room> treasureRoomsIndex;
    public List<Room> specialRoomsIndex;
    public List<Room> miscRoomsIndex;
    public List<Room> floor1CombatRoomsIndex;
    public List<Room> floor1BossRoomsIndex;
    public List<Room> floor2CombatRoomsIndex;
    public List<Room> floor2BossRoomsIndex;
    public List<Room> floor3CombatRoomsIndex;
    public List<Room> floor3BossRoomsIndex;
    public List<Room> floor4CombatRoomsIndex;
    public List<Room> floor4BossRoomsIndex;
    private int roomNumber; // int used to select rooms
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // KILL THE CLONES!!!
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length != 1)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].GetComponent<ItemManager>().currentItems.Count == 0)
                {
                    if (players[i].GetComponent<PlayerController>().floor == 0)
                    {
                        Destroy(players[i]);
                    }
                }
            }
        }
        players[0].transform.position = transform.position;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ItemManager>().ItemSetup();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Setup();

        rooms.Clear();
        // set up random rooms
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().floor == 0)
        {
            rooms.Add(miscRoomsIndex[0]);
            AddTreasureRoom();
            for (int i = 0; i < 7; i++)
            {
                AddCombatRoom();
            }
            AddSpecialRoom();
            AddBossRoom();
        }
        else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().floor == 1)
        {
            rooms.Add(miscRoomsIndex[0]);
            for (int i = 0; i < 2; i++)
            {
                AddCombatRoom();
            }
            AddTreasureRoom();
            for (int i = 0; i < 4; i++)
            {
                AddCombatRoom();
            }
            AddTreasureRoom();
            AddSpecialRoom();
            for (int i = 0; i < 5; i++)
            {
                AddCombatRoom();
            }
            AddTreasureRoom();
            AddSpecialRoom();
            AddBossRoom();
        }
        else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().floor == 2)
        {
            rooms.Add(miscRoomsIndex[0]);
            AddCombatRoom();
            AddTreasureRoom();
            for (int i = 0; i < 6; i++)
            {
                AddCombatRoom();
            }
            AddSpecialRoom();
            for (int i = 0; i < 3; i++)
            {
                AddCombatRoom();
            }
            AddSpecialRoom();
            for (int i = 0; i < 5; i++)
            {
                AddCombatRoom();
            }
            AddTreasureRoom();
            for (int i = 0; i < 2; i++)
            {
                AddCombatRoom();
            }
            AddSpecialRoom();
            AddBossRoom();
        }
        else
        {
            rooms.Add(miscRoomsIndex[0]);
            AddTreasureRoom();
            for (int i = 0; i < 8; i++)
            {
                AddCombatRoom();
            }
            AddSpecialRoom();
            for (int i = 0; i < 9; i++)
            {
                AddCombatRoom();
            }
            AddTreasureRoom();
            for (int i = 0; i < 7; i++)
            {
                AddCombatRoom();
            }
            AddSpecialRoom();
            AddBossRoom();
            rooms.Add(miscRoomsIndex[1]);
        }

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

    void AddTreasureRoom()
    {
        roomNumber = Random.Range(0, treasureRoomsIndex.Count);
        rooms.Add(Instantiate(treasureRoomsIndex[roomNumber]));
    }

    void AddSpecialRoom()
    {
        roomNumber = Random.Range(0, specialRoomsIndex.Count);
        rooms.Add(Instantiate(specialRoomsIndex[roomNumber]));
    }

    void AddCombatRoom()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().floor == 0)
        {
            roomNumber = Random.Range(0, floor1CombatRoomsIndex.Count);
            rooms.Add(Instantiate(floor1CombatRoomsIndex[roomNumber]));
        }
        else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().floor == 1)
        {
            roomNumber = Random.Range(0, floor2CombatRoomsIndex.Count);
            rooms.Add(Instantiate(floor2CombatRoomsIndex[roomNumber]));
        }
        else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().floor == 2)
        {
            roomNumber = Random.Range(0, floor3CombatRoomsIndex.Count);
            rooms.Add(Instantiate(floor3CombatRoomsIndex[roomNumber]));
        }
        else
        {
            roomNumber = Random.Range(0, floor4CombatRoomsIndex.Count);
            rooms.Add(Instantiate(floor4CombatRoomsIndex[roomNumber]));
        }
    }

    void AddBossRoom()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().floor == 0)
        {
            roomNumber = Random.Range(0, floor1BossRoomsIndex.Count);
            rooms.Add(Instantiate(floor1BossRoomsIndex[roomNumber]));
        }
        else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().floor == 1)
        {
            roomNumber = Random.Range(0, floor2BossRoomsIndex.Count);
            rooms.Add(Instantiate(floor2BossRoomsIndex[roomNumber]));
        }
        else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().floor == 2)
        {
            roomNumber = Random.Range(0, floor3BossRoomsIndex.Count);
            rooms.Add(Instantiate(floor3BossRoomsIndex[roomNumber]));
        }
        else
        {
            roomNumber = Random.Range(0, floor4BossRoomsIndex.Count);
            rooms.Add(Instantiate(floor4BossRoomsIndex[roomNumber]));
        }
    }
}

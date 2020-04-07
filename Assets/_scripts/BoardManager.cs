﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int min { get; set; }
        public int max { get; set; }

        public Count(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    }
    /// <summary>
    /// Todas las variables que se generan con BoardManager
    /// 
    /// </summary>
    #region levelProperties
    [SerializeField]
    private int columns = 9;
    [SerializeField]
    private int rows = 9;

    //cantidad minima y maxima de paredes que va a haber
    [SerializeField]
    private Count wallCountMinMax = new Count(5, 10);
    //idem wallCountMinMax para recolectables
    [SerializeField]
    private Count entityNeutralCount = new Count(3, 4);
    //idem wallCountMinMax para enemigos y trampas
    [SerializeField]
    private Count entityChaoticCount = new Count(2, 3);

    //contenedores de tiles
    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] neutralTiles;
    public GameObject[] chaoticTiles;
    public GameObject[] outerWallTiles;
    #endregion

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>(); 
    
    void InitializeList()
    {
        gridPositions.Clear();
        for (int x = 0; x < columns - 1; x++)
        {
            for (int y = 0; y < rows-1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }

        }
    }
    void BoardSetup()
    {
        boardHolder = new GameObject("roomBoard").transform;
        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0,floorTiles.Length)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                    toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
            Debug.Log("hola");

        }
    }

    //RandomPosition returns a random position from our list gridPositions.
    Vector3 RandomPosition()
    {
        //Declare an integer randomIndex, set it's value to a random number between 0 and the count of items in our List gridPositions.
        int randomIndex = Random.Range(0, gridPositions.Count);

        //Declare a variable of type Vector3 called randomPosition, set it's value to the entry at randomIndex from our List gridPositions.
        Vector3 randomPosition = gridPositions[randomIndex];

        //Remove the entry at randomIndex from the list so that it can't be re-used.
        gridPositions.RemoveAt(randomIndex);

        //Return the randomly selected Vector3 position.
        return randomPosition;
    }


    //LayoutObjectAtRandom accepts an array of game objects to choose from along with a minimum and maximum range for the number of objects to create.
    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        //Choose a random number of objects to instantiate within the minimum and maximum limits
        int objectCount = Random.Range(minimum, maximum + 1);

        //Instantiate objects until the randomly chosen limit objectCount is reached
        for (int i = 0; i < objectCount; i++)
        {
            //Choose a position for randomPosition by getting a random position from our list of available Vector3s stored in gridPosition
            Vector3 randomPosition = RandomPosition();

            //Choose a random tile from tileArray and assign it to tileChoice
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            //Instantiate tileChoice at the position returned by RandomPosition with no change in rotation
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }


    //SetupScene initializes our level and calls the previous functions to lay out the game board
    public void SetupScene(int level)
    {
        //Creates the outer walls and floor.
        BoardSetup();

        //Reset our list of gridpositions.
        InitializeList();

        //Instantiate a random number of wall tiles based on minimum and maximum, at randomized positions.
        LayoutObjectAtRandom(wallTiles, wallCountMinMax.min, wallCountMinMax.max);

        //Instantiate a random number of food tiles based on minimum and maximum, at randomized positions.
        LayoutObjectAtRandom(neutralTiles, entityNeutralCount.min, entityNeutralCount.max);

        //Determine number of enemies based on current level number, based on a logarithmic progression
        int enemyCount = (int)Mathf.Log(level, 2f);

        //Instantiate a random number of enemies based on minimum and maximum, at randomized positions.
        LayoutObjectAtRandom(chaoticTiles, enemyCount, enemyCount);

        //Instantiate the exit tile in the upper right hand corner of our game board
        Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
    }
}

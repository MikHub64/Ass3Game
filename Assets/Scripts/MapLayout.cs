using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLayout : MonoBehaviour
{

    public GameObject outCorner;
    public GameObject outWall;
    public GameObject inCorner;
    public GameObject inWall;
    public GameObject pellet;
    public GameObject powerPellet;
    public GameObject junction;

    public int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
    };

    private void OnEnable()
    {
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                if (levelMap[i, j] == 1)
                {
                    Instantiate(outCorner, new Vector3(j, -i, 0), Quaternion.identity);
                }
                if (levelMap[i, j] == 2)
                {
                    Instantiate(outWall, new Vector3(j, -i, 0), Quaternion.identity);
                }
                if (levelMap[i, j] == 3)
                {
                    Instantiate(inCorner, new Vector3(j, -i, 0), Quaternion.identity);
                }
                if (levelMap[i, j] == 4)
                {
                    Instantiate(inWall, new Vector3(j, -i, 0), Quaternion.identity);
                }
                if (levelMap[i, j] == 5)
                {
                    Instantiate(pellet, new Vector3(j, -i, 0), Quaternion.identity);
                }
                if (levelMap[i, j] == 6)
                {
                    Instantiate(powerPellet, new Vector3(j, -i, 0), Quaternion.identity);
                }
                if (levelMap[i, j] == 7)
                {
                    Instantiate(junction, new Vector3(j, -i, 0), Quaternion.identity);
                }
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

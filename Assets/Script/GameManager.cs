using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gmInstance;

    public int Goalcount = 0;
    public int NumberofSpawn;

    public GameObject Wall;
    public GameObject Goal;

    Vector3 GoalPos;
    // Start is called before the first frame update
    void Start()
    {
        if (gmInstance == null)
        {
            gmInstance = this;
        }

        for (int i = 1; i < NumberofSpawn; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-24.5f, 24.5f), 0.6f, Random.Range(-24.5f, 24.5f));
            Instantiate(Wall, randomPos, Quaternion.identity);
        }


        GoalPos = new Vector3(Random.Range(-24.5f, 24.5f), 2.5f, Random.Range(-24.5f, 24.5f));
        Instantiate(Goal, GoalPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void OnGoal()
    {
        GoalPos = new Vector3(Random.Range(-24.5f, 24.5f), 2.5f, Random.Range(-24.5f, 24.5f));
        if (Goalcount == 0)
        {
            Instantiate(Goal, GoalPos, Quaternion.identity);
        }
    }
}

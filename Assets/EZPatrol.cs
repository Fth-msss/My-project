using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EZPatrol : MonoBehaviour
{
    [SerializeField]
    List<GameObject> MapEdgePoints;
    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    List<GameObject> Gems;
    [SerializeField]
    GameObject player;

    bool targetingplayer;
    

    void MoveToCorner() 
    {
        Debug.Log("moving to corner");
        int next = Random.Range(0, MapEdgePoints.Count-1);

        SetDestination(MapEdgePoints[next].transform.position);
    }

    void MoveToGem() 
    {
        Debug.Log("moving to gem");
        int next = Random.Range(0, Gems.Count-1);

        SetDestination(MapEdgePoints[next].transform.position);
    }

    void MoveToPlayer() 
    {
        Debug.Log("moving to player");
        SetDestination(player.transform.position);
    }

    public void TargetPlayer() 
    {
        SetDestination(player.transform.position);
        targetingplayer = true;
        agent.speed *= 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer(); 
    }

    float randominterval = 8f;
    float time = 0f;
    void Timer() 
    {
        time += Time.deltaTime;
        if (time > randominterval) 
        {
            time -= randominterval;

            if (!targetingplayer) //
            {
                int next = Random.Range(0, 3);
                switch (next)
                {
                    case 0:
                        MoveToCorner();
                        break;
                    case 1:
                        MoveToGem();
                        break;
                    case 2:
                        MoveToPlayer();
                        break;
                    default:
                        Debug.Log("something is ver wrong");
                        break;

                }
            }

           
        }
    }

    void SetDestination(Vector3 destiny) 
    {
        agent.SetDestination(destiny);
    }
}

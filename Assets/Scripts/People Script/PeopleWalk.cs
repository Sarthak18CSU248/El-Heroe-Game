using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeopleWalk : MonoBehaviour
{

    public Transform[] walk_points;
    public float walk_speed = 1f;
    public bool isIdle;

    private int walk_Index;

    private NavMeshAgent navAgent;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (isIdle)
        {
            anim.Play("Idle");
        }
        else
            anim.Play("Walk");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isIdle)
            ChooseWalkPoint();
    }
    void ChooseWalkPoint()
    {
        if(navAgent.remainingDistance <=0.1f)
        {
            navAgent.SetDestination(walk_points[walk_Index].position);
            if (walk_Index == walk_points.Length - 1)
            {
                walk_Index = 0;
            }
            else
                walk_Index++;
        }
    }

}//class

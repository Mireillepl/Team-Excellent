using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.
    private AudioSource m_AudioSource;

    NavMeshAgent agent;
    public Transform[] waypoints;
    private int currentWaypoint = 0;
    public ZombieData data;
    public GameObject player;
    public float WanderpointDistance;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_AudioSource = GetComponent<AudioSource>();
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float curTime = Time.time;
        Debug.Log("Diff: = " + (curTime - time));
        if (curTime - time > 0.5f && Vector3.Distance(this.transform.position, player.transform.position) > data.attackRange)
        {
            time = curTime;
            PlayFootStepAudio();
        }



        if (Vector3.Distance(this.transform.position, player.transform.position) < data.lockRange)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) < data.attackRange)
            {
                agent.SetDestination(this.transform.position);
                LookAtPlayer();
            }
            else
            {
                MoveToPlayer();
            }
        }
        else 
        {
            Debug.Log(currentWaypoint);
            agent.SetDestination(waypoints[currentWaypoint].position);
            if (Vector3.Distance(this.transform.position, waypoints[currentWaypoint].position) < WanderpointDistance) 
            {
                if (currentWaypoint < waypoints.Length - 1)
                {
                    ++currentWaypoint;
                }
                else
                {
                    currentWaypoint = 0;
                }
            }
        }
    }

    void MoveToPlayer() 
    {
        agent.SetDestination( player.transform.position);
    }
    void LookAtPlayer()
    {
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * data.rotSpeed);   
    }

    private void PlayFootStepAudio()
        {
            // pick & play a random footstep sound from the array,
            // excluding sound at index 0
            int n = Random.Range(1, m_FootstepSounds.Length);
            m_AudioSource.clip = m_FootstepSounds[n];
            m_AudioSource.PlayOneShot(m_AudioSource.clip);
            // move picked sound to index 0 so it's not picked next time
            m_FootstepSounds[n] = m_FootstepSounds[0];
            m_FootstepSounds[0] = m_AudioSource.clip;
        }
}
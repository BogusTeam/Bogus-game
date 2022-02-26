using System;
using UnityEngine;
using UnityEngine.AI;

public class FollowerPlayer : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // clicking on the nav mesh, sets the destination of the agent and off he goes
        var delta = _player.transform.position - _agent.transform.position;
        // Debug.Log($"Stopped: {_agent.isStopped}");
        // Debug.Log(delta);
        if (Math.Abs(delta.x) > 2.0 || Math.Abs(delta.z) > 2.0)
        {
            if (_agent.isStopped)
                _agent.Resume();
            _agent.SetDestination(_player.transform.position);
        }
        else if (!_agent.isStopped)
        {
            _agent.Stop();
        }
    }
}
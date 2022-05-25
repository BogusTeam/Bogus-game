using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = Utils.GetPlayerObject();
        if (_player == null)
            Debug.Log("Player object is not found!");
    }

    // Update is called once per frame
    void Update()
    {
        // Make check if enemy turn, then go to player/follower and fight!
        var delta = _player.transform.position - _agent.transform.position;
        if (Math.Abs(delta.x) > 4.0 || Math.Abs(delta.z) > 4.0)
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
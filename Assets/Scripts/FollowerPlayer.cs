using System;
using UnityEngine;
using UnityEngine.AI;

public class FollowerPlayer : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameObject _player;
    private Animator _animator;
    private String _walkingAnimation = "Walk";
    private String _idleAnimation = "Idle";

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = Utils.GetPlayerObject();
        if(GetComponent<Animator>()!=null)
            _animator = GetComponent<Animator>();
        if (_player == null)
            Debug.Log("Player object is not found!");
    }

    // Update is called once per frame
    void Update()
    {
        // clicking on the nav mesh, sets the destination of the agent and off he goes
        var delta = _player.transform.position - _agent.transform.position;
        // Debug.Log($"Stopped: {_agent.isStopped}");
        // Debug.Log(delta);
        if (Math.Abs(delta.x) > 6.0 && Math.Abs(delta.z) > 6.0)
        {
            if (_agent.isStopped)
                _agent.Resume();
            
            _agent.SetDestination(_player.transform.position);
            if (_animator != null)
                _animator.Play(_walkingAnimation);
        }
        else if (!_agent.isStopped)
        {
            if (_animator != null)
                _animator.Play(_idleAnimation);
            _agent.Stop();
        }
    }
}
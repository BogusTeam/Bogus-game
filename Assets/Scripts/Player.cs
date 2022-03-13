using System;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Camera _cam;
    private NavMeshAgent _agent;
    private CharacterController _controller;
    private Animator _animator;
    private String _walkingAnimation = "Walk";
    private String _idleAnimation = "Idle";
    

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Clicking on the nav mesh, sets the destination of the agent and off he goes
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
            {
                _agent.SetDestination(hit.point);
                _animator.Play(_walkingAnimation);
                // Debug.Log(_walkingAnimation);
            }
        }

        var delta = _agent.destination - gameObject.transform.position;
        if (Math.Abs(delta.x) < 0.08 || Math.Abs(delta.z) < 0.08)
        {
            _animator.Play(_idleAnimation);
            // Debug.Log(_idleAnimation);
        }
    }
}
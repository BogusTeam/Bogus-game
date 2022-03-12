using System;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private UnityEngine.Camera _cam;
    private GameObject _obj;
    private NavMeshAgent _agent;
    private CharacterController _controller;
    private Animator _animator;
    private String _walkingAnimation = "Walk";
    private String _idleAnimation = "Idle";
    

    // Start is called before the first frame update
    void Start()
    {
        _cam = UnityEngine.Camera.main;
        _obj = GameObject.FindWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
        // _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // clicking on the nav mesh, sets the destination of the agent and off he goes
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
            {
                _agent.SetDestination(hit.point);
                _animator.Play(_walkingAnimation);
                // _controller.Move(hit.point);
                Debug.Log(_walkingAnimation);
            }
        }

        var delta = _agent.destination - _obj.transform.position;
        if (Math.Abs(delta.x) < 0.2 || Math.Abs(delta.z) < 0.2)
        {
            _animator.Play(_idleAnimation);
            Debug.Log(_idleAnimation);
        }
    }
}
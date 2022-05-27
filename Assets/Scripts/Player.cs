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
    private bool _walkingState;
    private PauseMenu _pauseMenu;
    private Dialogs _dialogs;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        _cam.transform.parent = gameObject.transform;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _pauseMenu = Utils.GetPausedScript();
        _dialogs = Utils.GetDialogsScript();
    }

    // Update is called once per frame
    void Update()
    {
        // Clicking on the nav mesh, sets the destination of the agent and off he goes
        if (Input.GetMouseButtonDown(0) && !_pauseMenu.pauseEnabled && !_dialogs.inDialog)
        {
            if (Physics.Raycast(_cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
            {
                _agent.Resume();
                _agent.SetDestination(hit.point);
                _animator.Play(_walkingAnimation);
                _walkingState = true;
                // Debug.Log(_walkingAnimation);
            }
        }

        if (_walkingState)
        {
            var delta = _agent.destination - gameObject.transform.position;
            if (Math.Abs(delta.x) < 0.1 && Math.Abs(delta.z) < 0.1)
            {
                _animator.Play(_idleAnimation);
                _agent.Stop();
                _walkingState = false;
                // Debug.Log(_idleAnimation);
            }
            else if (Math.Abs(delta.x) < 0.9 && Math.Abs(delta.z) < 0.9)
            {
                _animator.Play(_idleAnimation);
            }
        }
    }
}
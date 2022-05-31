using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Camera _cam;
    private NavMeshAgent _agent;
    private CharacterController _controller;
    private Animator _animator;
    private String _walkingAnimation = "Walk";
    private String _idleAnimation = "Idle";
    private String _hitAnimation = "Hit";
    private String _blockAnimation = "Block";
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
        Utils.GetStatsScript()!.attackButton.GetComponent<Button>().onClick.AddListener(StartAttack);
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
                StartCoroutine(GetBlock());
            }
            else if (Math.Abs(delta.x) < 0.9 && Math.Abs(delta.z) < 0.9)
            {
                _animator.Play(_idleAnimation);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.F))
            StartAttack();
    }

    public IEnumerator GetHit()
    {
        _animator.Play(_hitAnimation);
        yield return new WaitForSeconds((float)1.5);
        _animator.Play(_idleAnimation);
    }

    public IEnumerator GetBlock()
    {
        _animator.Play(_blockAnimation);
        yield return new WaitForSeconds((float)1.6);
        _animator.Play(_idleAnimation);
    }

    public void StartAttack()
    {
        StartCoroutine(GetHit());
        var enemies = Utils.GetEnemies();
        if (enemies.Count > 0)
        {
            foreach (var enemy in enemies)
            {
                var delta = gameObject.transform.position - enemy.transform.position;
                if (Math.Abs(delta.x) < 12.0 && Math.Abs(delta.z) < 12.0)
                {
                    enemy.GetComponent<Enemy>().GetDamage(-GetComponent<Entity>().attackRating);
                    break;
                }
            }
        }
    }
}
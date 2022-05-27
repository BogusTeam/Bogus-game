using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameObject _player;
    private Animator _animator;
    private String _walkingAnimation = "Walk";
    private String _idleAnimation = "Idle";
    private GameObject _startTrigger;
    private DateTime? _dateTime;
    private Dialogs _dialogs;
    private Entity _entity;

    // Start is called before the first frame update
    void Start()
    {
        _startTrigger = gameObject.GetComponent<Entity>().linkedObject;
        _agent = GetComponent<NavMeshAgent>();
        _player = Utils.GetPlayerObject();
        _dialogs = Utils.GetDialogsScript();
        _entity = GetComponent<Entity>();
        if(GetComponent<Animator>()!=null)
            _animator = GetComponent<Animator>();
        if (_player == null)
            Debug.Log("Player object is not found!");
    }

    // Update is called once per frame
    void Update()
    {
        if (_dialogs.inDialog || !_startTrigger.GetComponent<Trigger>().triggered)
            return;
        // Make check if enemy turn, then go to player/follower and fight!
        var delta = _player.transform.position - _agent.transform.position;
        if (Math.Abs(delta.x) > 4.0 || Math.Abs(delta.z) > 4.0)
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
            _dateTime = DateTime.Now;
        }
        else if (_dateTime != null && DateTime.Now > _dateTime)
        {
            Debug.Log($"{name} attack!");
            Utils.ChangeHeroHp(-_entity.attackRating);
            _dateTime = DateTime.Now.AddSeconds(2);
        }
    }

    public void GetDamage(int damage)
    {
        _entity.healthPoints += damage;
        Debug.Log($"{name} hp: {_entity.healthPoints}");
        if (_entity.healthPoints < 1)
            Destroy(gameObject);
    }
}
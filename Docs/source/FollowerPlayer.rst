FollowerPlayer module
=====================
.. default-domain:: sphinxsharp

.. namespace:: BogusGame

.. type:: public class FollowerPlayer : MonoBehaviour
    
    Class for camera movement ¯\\_(ツ)_/¯
    
    .. variable:: private NavMeshAgent _agent
        
        Parameter for pathfinding and moving player
    
    .. variable:: private GameObject _player;
    
        GameObject of Main Player
    
    
    .. method:: public void Start()
    
        Initialization of agent and main player
    
    .. method:: public void Update()
    
        Changing follower's position, if main player is far away
    
.. end-type::
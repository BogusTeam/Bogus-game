Player module
=====================
.. default-domain:: sphinxsharp

.. namespace:: BogusGame

.. type:: public class Player : MonoBehaviour
    
    Class for player control ¯\\_(ツ)_/¯
    
    .. variable:: private Camera _cam
        
        Camera's GameObject
    
    .. variable:: private NavMeshAgent _agent
    
        Parameter for pathfinding and moving player
    
    .. variable:: private CharacterController _controller
    
        This is useless parameter (oh shit i'm sorry)
    
    .. variable:: private Animator _animator
    
        Parameter for object animation
    
    .. variable:: private String _walkingAnimation
    
        Name of walking animation in animator
    
    .. variable:: private String _idleAnimation
    
        Name of idle animation in animator
        
    .. variable:: private bool _walkingState
    
        Walking indicator
    
    .. method:: public void Start()
    
        Initialization of camera, agent and animator
    
    .. method:: public void Update()
    
        Processing of player's movement
    
.. end-type::
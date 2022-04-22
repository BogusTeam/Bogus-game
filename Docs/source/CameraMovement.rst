CameraMovement module
=====================
.. default-domain:: sphinxsharp

.. namespace:: BogusGame

.. type:: public class CameraMovement : MonoBehaviour
    
    Class for camera movement ¯\\_(ツ)_/¯
    
    .. variable:: public float cameraYAxisSpeed
    
        Parameter for determining the vertical component of camera's velocity vector
    
    .. variable:: public float cameraZAxisSpeed
    
        Parameter for determining the horizontal component of camera's velocity vector
    
    .. variable:: public float cameraXAngleBevel
    
        Parameter for determining the vertical component of camera's rotation vector
    
    .. variable:: public float cameraLookSpeed
    
        Parameter for determining the horizontal component of camera's rotation speed vector
    
    .. variable:: public GameObject player
    
        Player's GameObject ¯\\_(ツ)_/¯
        
    .. variable:: private readonly List<int> _localCameraPositions
    
        List of camera's states
        
    .. variable:: private int _currentCameraPos
    
        Current camera state
    
    .. variable:: private Camera _cam
    
        Camera's GameObject
    
    .. method:: public void Start()
    
        Initialization of camera
    
    .. method:: public void Update()
    
        Changing camera's position
    
.. end-type::
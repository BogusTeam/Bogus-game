using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private UnityEngine.Camera _cam;
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _cam = UnityEngine.Camera.main;
        _agent = GetComponent<NavMeshAgent>();
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
            }
        }
    }
}
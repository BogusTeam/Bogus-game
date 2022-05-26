using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraYAxisSpeed = 6.0f;
    public float cameraZAxisSpeed = 2.0f;
    public float cameraXAngleBevel = 3.0f;
    public float cameraLookSpeed = 10.0f;
    public int currentCameraPos = 1;
    
    private GameObject _player;
    private readonly List<int> _localCameraPositions = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    private Camera _cam;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        _player = Utils.GetPlayerObject();
        if (_player == null)
            Debug.Log("Player object is not found!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y != 0 &&
            (Input.mouseScrollDelta.y < 0 && currentCameraPos < _localCameraPositions.Last() ||
             Input.mouseScrollDelta.y > 0 && currentCameraPos > _localCameraPositions.First()))
        {
            // var pos = _cam.transform.localPosition;
            // pos.y -= 6 * Input.mouseScrollDelta.y;
            // pos.z += 2 * Input.mouseScrollDelta.y;
            // _cam.transform.localPosition = pos;
            // TODO: Replace Translate with func without side effects
            _cam.transform.Translate(new Vector3(0, 10 * cameraYAxisSpeed * -Input.mouseScrollDelta.y,
                10 * cameraZAxisSpeed * Input.mouseScrollDelta.y) * Time.deltaTime);
            _cam.transform.Rotate(Input.mouseScrollDelta.y * -cameraXAngleBevel, 0, 0);
            currentCameraPos -= (int)Input.mouseScrollDelta.y;
            Debug.Log($"Current Camera Position: {currentCameraPos}");
        }

        if (Input.GetMouseButtonDown(2))
            Debug.Log("ScrollButton pressed!");
        else if (Input.GetMouseButton(2))
            _cam.transform.RotateAround(
                _player.transform.position,
                new Vector3(0, 1.0f, 0),
                10 * Input.GetAxis("Mouse X") * Time.deltaTime * cameraLookSpeed
            );
    }
}
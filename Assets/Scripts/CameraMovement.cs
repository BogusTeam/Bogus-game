using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private readonly List<int> _localCameraPositions = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    private int _currentCameraPos = 1;

    private Camera _cam;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y != 0 &&
            (Input.mouseScrollDelta.y < 0 && _currentCameraPos < _localCameraPositions.Last() ||
             Input.mouseScrollDelta.y > 0 && _currentCameraPos > _localCameraPositions.First()))
        {
            var pos = _cam.transform.localPosition;
            pos.y -= 6 * Input.mouseScrollDelta.y;
            pos.z += 2 * Input.mouseScrollDelta.y;
            _cam.transform.localPosition = pos;
            _cam.transform.Rotate(Input.mouseScrollDelta.y * -3, 0, 0);
            _currentCameraPos -= (int)Input.mouseScrollDelta.y;
            Debug.Log(_currentCameraPos);
        }
        
        // if (Input.mouseScrollDelta.y != 0)
        // {
        //     var rot = _cam.transform.localRotation;
        //     Debug.Log($"{rot.w}, {rot.x}, {rot.y}, {rot.z}");
        //
        //     var pos2 = _cam.transform.position;
        //     Debug.Log($"{pos2.x}, {pos2.y}, {pos2.z}");
        //
        //     var pos3 = _cam.transform.localPosition;
        //     Debug.Log($"{pos3.x}, {pos3.y}, {pos3.z}");
        // }
    }
}
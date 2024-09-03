using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float _cameraSpeed;
    [SerializeField] GameObject _mainCameraObj;
    // Update is called once per frame
    void Update()
    {
        Vector3 camPos=_mainCameraObj.transform.position;
        if (Input.GetMouseButton(2))
        {
            camPos.x-=Input.GetAxis("Mouse X")*_cameraSpeed*Time.deltaTime;
            camPos.y -= Input.GetAxis("Mouse Y") * _cameraSpeed * Time.deltaTime;
        }
        _mainCameraObj.transform.position = camPos;
    }
}

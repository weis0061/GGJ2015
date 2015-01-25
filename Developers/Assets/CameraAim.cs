using UnityEngine;
using System.Collections;

public class CameraAim : MonoBehaviour
{


    public GameObject CameraXRot;
    public GameObject CameraYRot;
    GridMovingObject GridMovingObject;
    Vector3 CameraOffsetPos;

    // Use this for initialization
    void Start()
    {
        XRot = YRot = 0;
        GridMovingObject = GetComponent<GridMovingObject>();
        CameraOffsetPos = CameraXRot.transform.position - transform.position;
    }
    float XRot;
    float YRot;
	
    // Update is called once per frame
    void LateUpdate()
    {
        XRot += Input.GetAxis("Mouse X");
        YRot += Input.GetAxis("Mouse Y");
        XRot = Mathf.Clamp(XRot, -20, 20);
        YRot = Mathf.Clamp(YRot, -40, 40);


        
        //CameraXRot.transform.localEulerAngles = Vector3.Slerp(CameraXRot.transform.localEulerAngles, new Vector3(0, XRot, 0), Time.deltaTime);
        //CameraYRot.transform.localEulerAngles = Vector3.Slerp(CameraXRot.transform.localEulerAngles, new Vector3(YRot, 0, 0), Time.deltaTime);

        CameraXRot.transform.localEulerAngles = new Vector3(0, XRot, YRot);
        CameraXRot.transform.position = transform.position + CameraOffsetPos;// + new Vector3(0, Mathf.Sin(Time.deltaTime * 8) * GridMovingObject.Velocity, 0);



    }
}


using UdonSharp;
using Unity.Mathematics;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace DroneWorks
{

    
public class DroneWorksUI : UdonSharpBehaviour
{
    VRC.SDKBase.VRCDroneApi connectedDrone;

    public Vector3 OffsetPostion = new Vector3(0, 0, 0);

    public float localScale = 1.0f;

    Vector3 startPosition;

    void Start()
    {
        startPosition = this.gameObject.transform.position;
    }

    void Update()
    {
        if (connectedDrone != null)
        {
            FollowDrone();
        }
        else{
            this.gameObject.transform.position =  startPosition + OffsetPostion;
            this.gameObject.transform.localScale = new Vector3(localScale, localScale, localScale);
        }
    }

    public void SetDrone(VRC.SDKBase.VRCDroneApi drone)
    {
        connectedDrone = drone;
    }

    void FollowDrone()
    {
            Vector3 forward = connectedDrone.GetRotation() * Vector3.forward;
            Vector3 right  = connectedDrone.GetRotation() * Vector3.right;
            transform.position = connectedDrone.GetPosition() + forward * OffsetPostion.z + Vector3.up * OffsetPostion.y + right * OffsetPostion.x; 

            Quaternion lookRot = Quaternion.LookRotation(forward, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 2.5f);

            this.gameObject.transform.localScale = new Vector3(localScale, localScale, localScale);
    }

    public void Deactivate()
    {
        connectedDrone = null;
    }
}
} //namespace droneworks
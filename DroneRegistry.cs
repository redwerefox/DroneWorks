
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;


namespace DroneWorks
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class DroneRegistry : UdonSharpBehaviour
    {

        VRC.SDKBase.VRCDroneApi deployedDrone;
        GameObject deployedDroneGameObject;

        [SerializeField] GameObject droneUIPrefab;

        [SerializeField] WorldDebugLog DebugLog;

        [SerializeField] bool FLAG_DispatchUI = true;

        [SerializeField] bool FLAG_LogDroneAttributes = true;

        void Start()
        {

        }

        void Update()
        {

        }


        public override void OnDroneTriggerEnter(VRC.SDKBase.VRCDroneApi drone)
        {
            // Check if the player is a drone
            if (drone.IsDeployed())
            {
                deployedDrone = drone;
                DebugLog.Log("DroneRegistry: Drone registered of: " + deployedDrone.GetPlayer().displayName);
                if (FLAG_DispatchUI && droneUIPrefab != null)
                {
                    // Dispatch the UI to the drone
                    droneUIPrefab.SetActive(true);
                    droneUIPrefab.transform.localPosition = deployedDrone.GetPosition();
                    droneUIPrefab.transform.localRotation = deployedDrone.GetRotation();
                    droneUIPrefab.GetComponent<DroneWorksUI>().SetDrone(deployedDrone);
                    DebugLog.Log("DroneRegistry: Drone UI dispatched to: " + deployedDrone.GetPlayer().displayName);
                }
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if(other == null)
            {
                DebugLog.Log("DroneRegistry: OnTriggerEnter: other is null");
                return; 
            }
            if (other.gameObject == null)
            {
                DebugLog.Log("DroneRegistry: OnTriggerEnter: other.gameobject is null");
                return;
            }
                if (true)
                {
                    deployedDroneGameObject = other.gameObject;
                    DebugLog.Log("NEW Object detected " + deployedDroneGameObject.name);
                    if (FLAG_LogDroneAttributes)
                    {
                        TriggerGameObjectAnalysis(other.gameObject);
                    }
                }
        }

        public void TriggerGameObjectAnalysis(GameObject gameobject)
        {
            DebugLog.Log("DroneRegistry: GameObject Analysis: " + gameobject.name);
            DebugLog.Log("Children: " + gameobject.transform.childCount);
            foreach (Transform child in gameobject.transform)
            {
                DebugLog.Log("Child: " + child.name);
            }
            DebugLog.Log("Components: " + gameobject.GetComponents<Component>().Length);
            foreach (Component component in gameobject.GetComponents<Component>())
            {
                if (component == null)
                {
                    DebugLog.Log("Component: null");
                    continue;
                }
                else {

                    DebugLog.Log("Component: " + component.GetType());
                }
            }
            DebugLog.Log("Layer: " + gameobject.layer);
        }

        public bool DroneRegistered()
        {
            if (deployedDrone != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public VRC.SDKBase.VRCDroneApi GetDrone()
        {
            return deployedDrone;
        }

        public override void OnDroneTriggerExit(VRC.SDKBase.VRCDroneApi drone)
        {
            deployedDrone = null;
            DebugLog.Log("DroneRegistry: Drone unregistered : " + drone.GetPlayer().displayName);
            if (FLAG_DispatchUI && droneUIPrefab != null)
            {
                // Dispatch the UI to the drone
                droneUIPrefab.SetActive(false);
                DebugLog.Log("DroneRegistry: Drone UI deactivated for: " + drone.GetPlayer().displayName);
            }

        }

        //public override void On
    }
} //namespace

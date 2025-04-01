
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;
using Unity.Mathematics;

namespace DroneWorks
{
    // This class is a placeholder for the DroneWorksValueAdapterOffsetX functionality.
    // It currently does not implement any specific functionality but serves as a template for future development.
    // The class inherits from UdonSharpBehaviour, allowing it to interact with Udon and VRChat SDK features.
    // The Start method is empty and can be used for initialization if needed in the future.

public class DroneWorksValueAdapterOffsetX : DroneWorksValueAdapter
{
     [SerializeField] DroneWorksUI droneUIprefab;

        [SerializeField] float crement = 0.1f;

        [SerializeField] TMP_Text currentDisplay;

        void Start()
        {
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.U))
            {
                Increment();
            }
            else if(Input.GetKeyDown(KeyCode.I))
            {
                Decrement();
            }
        }

        public override void SetValue(float value)
        { 
            droneUIprefab.OffsetPostion = new Vector3(value, droneUIprefab.OffsetPostion.y, droneUIprefab.OffsetPostion.z);
            currentDisplay.text =  GetValue().ToString("F3");
        }

        public override float GetValue()
        {
            return droneUIprefab.OffsetPostion.x;
        }

        public override void Increment()
        {
            SetValue(GetValue() + crement);
        }

        public override void Decrement()
        {
            SetValue(GetValue() - crement);
        }
}

}
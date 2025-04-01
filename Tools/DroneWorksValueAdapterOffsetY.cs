
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

namespace DroneWorks
{
    // This class is responsible for adapting the offset Y value of a DroneWorksUI prefab.
    // It allows for incrementing and decrementing the offset value using keyboard input.
    // The current value is displayed in a TMP_Text component.
public class DroneWorksValueAdapterOffsetY : DroneWorksValueAdapter
{
     [SerializeField] DroneWorksUI droneUIprefab;

        [SerializeField] float crement = 0.1f;

        [SerializeField] TMP_Text CurrentDisplay;

        void Start()
        {
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.K))
            {
                Increment();
            }
            else if(Input.GetKeyDown(KeyCode.L))
            {
                Decrement();
            }
        }

        public override void SetValue(float value)
        { 
            droneUIprefab.OffsetPostion = new Vector3(droneUIprefab.OffsetPostion.x, value, droneUIprefab.OffsetPostion.z);
            CurrentDisplay.text =  GetValue().ToString("F3");
        }

        public override float GetValue()
        {
            return droneUIprefab.OffsetPostion.y;
        }

        public override void Increment()
        {
            SetValue( GetValue() + crement);
        }

        public override void Decrement()
        {
            SetValue(GetValue() - crement);
        }
}
} // namespace DroneWorks

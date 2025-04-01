
using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace DroneWorks
{

    public class DroneWorksValueAdapterOffsetZ : DroneWorksValueAdapter
    {
        [SerializeField] DroneWorksUI droneUIprefab;

        [SerializeField] float crement = 0.1f;

        [SerializeField] TMP_Text currentDisplay;

        void Start()
        {
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                Increment();
            }
            else if(Input.GetKeyDown(KeyCode.N))
            {
                Decrement();
            }
        }

        public override void SetValue(float value)
        { 
            droneUIprefab.OffsetPostion = new Vector3(droneUIprefab.OffsetPostion.x, droneUIprefab.OffsetPostion.y, value);
            currentDisplay.text =  GetValue().ToString("F3");
        }

        public override float GetValue()
        {
            return droneUIprefab.OffsetPostion.z;
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
} // namespace DroneWorks

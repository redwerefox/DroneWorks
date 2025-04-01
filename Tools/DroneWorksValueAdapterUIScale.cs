
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

namespace DroneWorks
{
    public class DroneWorksValueAdapterUIScale : DroneWorksValueAdapter
    {
        [SerializeField] DroneWorksUI droneUIprefab;

        [SerializeField] float crement = 0.1f;

        [SerializeField] TMP_Text valueDisplay;

        void Start()
        {
            valueDisplay.text = GetValue().ToString("F2");
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.H))
            {
                Increment();
            }
            else if(Input.GetKeyDown(KeyCode.J))
            {
                Decrement();
            }
            
        }

        public override void SetValue(float value)
        {
            droneUIprefab.localScale = value;
            valueDisplay.text = GetValue().ToString("F3");
        }

        public override float GetValue()
        {
            return droneUIprefab.localScale;
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

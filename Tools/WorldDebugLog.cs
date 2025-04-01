
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

namespace DroneWorks
{
    public class WorldDebugLog : UdonSharpBehaviour
    {
        [SerializeField] ScrollRect scrollRect;

        void Start()
        {
           Log("DroneRegistry started : >V< " + GetDroneWorksVersion());
        }

        private string GetDroneWorksVersion()
        {
            return "0.1.0";
        }

        public void Log(string message)
        {
            string formattedMessage = $"[{System.DateTime.Now:HH:mm:ss}] {message}";
            scrollRect.content.GetComponent<TextMeshProUGUI>().text += formattedMessage + "\n";
            if (scrollRect.verticalNormalizedPosition < 0.1f)
            {
                scrollRect.verticalNormalizedPosition = 0f; // Scroll to the bottom
            }
        }

    }
}


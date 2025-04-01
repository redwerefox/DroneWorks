
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

namespace DroneWorks
{
public class EditValueWorldUI : UdonSharpBehaviour
{
    float value;

    [SerializeField] DroneWorksValueAdapter droneAdapter;

    public void SetValue (float newValue)
    {
        value = newValue;
        UpdateText();
    }

    private void UpdateText()
    {
        TextMeshProUGUI textComponent = GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = value.ToString("F2");

            if (droneAdapter != null)
            {
                droneAdapter.SetValue(value);
            }
            else
            {
                Debug.LogWarning("DroneWorksUI component not found in the scene.");
            }
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI component not found on this GameObject.");
        }
    }
}
} // namespace DroneWorks

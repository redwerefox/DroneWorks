
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace DroneWorks
{
public  class DroneWorksValueAdapter : UdonSharpBehaviour
{
    public virtual void SetValue(float value)
    {
        // This method should be overridden in derived classes
        Debug.LogWarning("SetValue not implemented in base class");
    }

    public virtual float GetValue()
    {
        // This method should be overridden in derived classes
        Debug.LogWarning("GetValue not implemented in base class");
        return 0f;
    }

    public virtual void Increment()
    {
        // This method can be overridden in derived classes if needed
        Debug.LogWarning("Increment not implemented in base class");
    }

    public virtual void Decrement()
    {
        // This method can be overridden in derived classes if needed
        Debug.LogWarning("Decrement not implemented in base class");
    }
}
} // namespace DroneWorks


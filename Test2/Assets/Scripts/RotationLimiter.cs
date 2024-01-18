using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
public class RotationLimiter : MonoBehaviour, IMixedRealityTouchHandler
{
    void IMixedRealityTouchHandler.OnTouchStarted(HandTrackingInputEventData eventData)
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Clamp(transform.eulerAngles.y, 0, 90), transform.eulerAngles.z);
    }

    void IMixedRealityTouchHandler.OnTouchCompleted(HandTrackingInputEventData eventData) { }
    void IMixedRealityTouchHandler.OnTouchUpdated(HandTrackingInputEventData eventData) { }
}

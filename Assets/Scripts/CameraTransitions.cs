using UnityEngine;

public class CameraTransitions : MonoBehaviour
{
    // Update is called once per frame LerpColorScale
    void Update()
    {
        // animate the color scale value 
        float value = 0.5f * (1.0f + Mathf.Sin(2.0f * Mathf.PI * 0.1f * Time.time));

        // sets the color scale and offset on the Oculus XR Plugin.
        // with the animation defined above this causes a constant "fade in" -> "fade out" effect.
        Unity.XR.Oculus.Utils.SetColorScaleAndOffset(new Vector4(value, value, value, value), Vector4.zero);
    }
}

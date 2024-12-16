using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;

/// <summary>
/// Component which reads input values and drives the grip transforms
/// to animate a hand model.
/// </summary>
public class HandAnimator : MonoBehaviour
{
    [Header("Grip")]
    [SerializeField]
    Transform m_GripTransform;

    [SerializeField]
    Vector2 m_GripRightRange = new Vector2(-0.0125f, -0.011f);

    [SerializeField]
    XRInputValueReader<float> m_GripInput = new XRInputValueReader<float>("Grip");

    void OnEnable()
    {
        if (m_GripTransform == null)
        {
            enabled = false;
            Debug.LogWarning($"Controller Animator component missing references on {gameObject.name}", this);
            return;
        }

        m_GripInput?.EnableDirectActionIfModeUsed();
    }

    void OnDisable()
    {
        m_GripInput?.DisableDirectActionIfModeUsed();
    }

    void Update()
    {
        if (m_GripInput != null)
        {
            var gripVal = m_GripInput.ReadValue();
            var currentPos = m_GripTransform.localPosition;
            m_GripTransform.localPosition = new Vector3(Mathf.Lerp(m_GripRightRange.x, m_GripRightRange.y, gripVal), currentPos.y, currentPos.z);
        }
    }
}

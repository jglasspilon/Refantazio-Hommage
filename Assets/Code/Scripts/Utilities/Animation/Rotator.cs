using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_rotationDegreesPerSecond;

    private void Update()
    {
        Quaternion rotationQuaternion = Quaternion.Euler(m_rotationDegreesPerSecond * Time.deltaTime);
        transform.localRotation = transform.localRotation * (rotationQuaternion);
    }
}

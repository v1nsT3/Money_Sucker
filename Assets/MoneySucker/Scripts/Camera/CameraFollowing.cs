using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _width;
    [SerializeField] private float _distance;
    [SerializeField] private float _height;

    private void Start()
    {
        transform.LookAt(_target.transform.position, Vector3.forward);
    }

    private void Update()
    {
        transform.position = new Vector3(_target.transform.position.x - _width, _target.position.y + _height, _target.transform.position.z - _distance);
        transform.LookAt(_target.transform.position, Vector3.forward);
    }
}

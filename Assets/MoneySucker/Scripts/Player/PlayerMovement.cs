using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _vacuum;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _maxDistance;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    private int _moveFloat = Animator.StringToHash("IsMove");
    private Vector3 _targetVelocity;

    private void Start()
    {
        //_rigidbody = GetComponent<Rigidbody>();
        //_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(_moveFloat, (Mathf.Abs(_joystick.Vertical) + Mathf.Abs(_joystick.Horizontal)) != 0);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _speedMove, _rigidbody.velocity.y, _joystick.Vertical * _speedMove);


        if (_joystick.Vertical != 0 || _joystick.Horizontal != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_rigidbody.velocity), _speedRotate * Time.fixedDeltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_targetVelocity, 0.5f);
    }
}

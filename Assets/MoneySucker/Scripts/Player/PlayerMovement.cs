using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;

    private Rigidbody _rigidbody;
    private Animator _animator;
    private int _moveFloat = Animator.StringToHash("IsMove");

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_joystick.Vertical != 0 || _joystick.Horizontal != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_rigidbody.velocity), _speedRotate * Time.deltaTime);
        }

        _animator.SetBool(_moveFloat, (Mathf.Abs(_joystick.Vertical) + Mathf.Abs(_joystick.Horizontal)) != 0);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _speedMove, _rigidbody.velocity.y, _joystick.Vertical * _speedMove);
    }
}

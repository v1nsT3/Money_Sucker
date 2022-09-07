using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Money : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
}

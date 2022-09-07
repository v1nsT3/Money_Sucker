using UnityEngine;
using DG.Tweening;
using System.Collections;

public class SuctionDevice : MonoBehaviour
{
    [SerializeField] private float _durationSuction;
    [SerializeField] private Transform _container;
    [SerializeField] private float _maxDistance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Money money))
        {
            Excite(other.attachedRigidbody);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Money money))
        {
            float _currentDist = Vector3.Distance(_container.position, money.transform.position);

            if (_currentDist <= _maxDistance / 2)
                Sucking(other.attachedRigidbody);
        }
    }

    private void Sucking(Rigidbody rigidbody)
    {
        rigidbody.transform.SetParent(_container, true);
        rigidbody.transform.DOLocalMove(Vector3.zero, _durationSuction);
        rigidbody.transform.DOScale(0, _durationSuction);
        rigidbody.isKinematic = true;
    }

    private void Excite(Rigidbody rigidbody)
    {
        rigidbody.AddForce((transform.position - rigidbody.transform.position) * 0.25f, ForceMode.Impulse);
    }
}

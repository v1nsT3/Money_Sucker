using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System.Collections.Generic;

public class SuctionDevice : MonoBehaviour
{
    [SerializeField] private float _durationSuction;
    [SerializeField] private Transform _container;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _maxVacuumForce;

    [SerializeField] private List<Money> _moneyInTrigger = new List<Money>();

    public event UnityAction Sucked;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Money money))
        {
            if (_moneyInTrigger.Contains(money) == false)
            {
                _moneyInTrigger.Add(money);
            }

            Excite(money);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Money money))
        {
            if (_moneyInTrigger.Contains(money))
            {
                _moneyInTrigger.Remove(money);
            }
        }
    }

    private void Update()
    {
        if (_moneyInTrigger.Count == 0)
            return;

        for (int i = 0; i < _moneyInTrigger.Count; i++)
        {
            float _currentDist = Vector3.Distance(_container.position, _moneyInTrigger[i].transform.position);

            if (_currentDist <= _maxDistance / _maxVacuumForce)
                Sucking(_moneyInTrigger[i]);
        }
    }

    private void Sucking(Money money)
    {
        money.transform.SetParent(_container, true);
        money.transform.DOLocalMove(Vector3.zero, _durationSuction);
        money.transform.DOScale(0, _durationSuction).OnComplete(() =>
        {
            money.gameObject.SetActive(false);
        });
        _moneyInTrigger.Remove(money);
        Sucked?.Invoke();
    }

    private void Excite(Money money)
    {
        money.Rigidbody.AddForce((transform.position - money.transform.position) * 0.25f, ForceMode.Impulse);
    }
}

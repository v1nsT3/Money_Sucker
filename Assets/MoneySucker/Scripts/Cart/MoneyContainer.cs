using UnityEngine;
using DG.Tweening;

public class MoneyContainer : MonoBehaviour
{
    [SerializeField] private SuctionDevice _suctionDevice;
    [SerializeField] private Transform _panelMoeny;
    [SerializeField] private float _offsetScaleY;

    private void OnEnable()
    {
        _suctionDevice.Sucked += OnSucked;
    }

    private void OnDisable()
    {
        _suctionDevice.Sucked -= OnSucked;
    }

    private void OnSucked()
    {
        _panelMoeny.DOScaleY(_panelMoeny.localScale.y + _offsetScaleY, 1);
    }
}

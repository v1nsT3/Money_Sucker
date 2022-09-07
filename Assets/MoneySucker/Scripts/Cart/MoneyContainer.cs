using UnityEngine;

public class MoneyContainer : MonoBehaviour
{
    [SerializeField] private SuctionDevice _suctionDevice;
    [SerializeField] private GameObject _moneyPanelTemplate;
    [SerializeField] private float _offsetY;
    [SerializeField] private int _numbersPanelOnStart;

    private float _currentOffsetY;

    private void OnEnable()
    {
        _suctionDevice.Sucked += OnSucked;
    }

    private void OnDisable()
    {
        _suctionDevice.Sucked -= OnSucked;
    }

    private void Start()
    {
        for (int i = 0; i < _numbersPanelOnStart - 1; i++)
        {
            OnSucked();
        }
    }

    private void OnSucked()
    {
        GameObject panel = Instantiate(_moneyPanelTemplate, transform);
        panel.transform.localPosition = new Vector3(0, _currentOffsetY, 0);
        _currentOffsetY += _offsetY;
    }
}

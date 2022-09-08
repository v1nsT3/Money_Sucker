using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class RopeDeforme : MonoBehaviour
{
    [SerializeField] private float _offsetPannerPerSec;
    [SerializeField] private float _minOffsetPanner;
    [SerializeField] private float _maxOffsetPanner;

    private MeshRenderer _meshRenderer;
    private Material _currentMaterial;
    private float _offsetPanner;

    private const string _propertyPanner = "Vector1_386C6BEE";

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _currentMaterial = _meshRenderer.material;
    }

    private void Update()
    {
        _offsetPanner += Time.deltaTime / _offsetPannerPerSec;

        if (_offsetPanner >= _maxOffsetPanner)
            _offsetPanner = _minOffsetPanner;

        _currentMaterial.SetFloat(_propertyPanner, _offsetPanner);
    }
}

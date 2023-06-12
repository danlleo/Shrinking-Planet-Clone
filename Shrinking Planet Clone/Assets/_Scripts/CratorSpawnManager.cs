using UnityEngine;

public class CratorSpawnManager : Singleton<CratorSpawnManager>
{
    [SerializeField] private Transform _planetTransform;
    [SerializeField] private MeshFilter _planetMeshFilter;
    [SerializeField] private GameObject _testPrefab;

    [SerializeField] private float _maxTimeInSeconds;

    private float _elapsedTime;
    private float _verticalSpawnOffset = 10f;

    protected override void Awake()
    {
        base.Awake();
        ResetTimer();
    }

    private void Update()
    {
        HandleTimer();
    }

    private void HandleTimer()
    {
        _elapsedTime -= Time.deltaTime;

        if (_elapsedTime <= 0f)
        {
            SpawnAtRandomPosition();
            ResetTimer();
        }
    }

    private void ResetTimer() => _elapsedTime = _maxTimeInSeconds;

    private void SpawnAtRandomPosition()
    {
        Mesh mesh = _planetMeshFilter.mesh;

        Vector3[] verticies = mesh.vertices;

        int randomIndex = Random.Range(0, verticies.Length);

        Vector3 localPosition = verticies[randomIndex];
        Vector3 worldPosition = _planetMeshFilter.transform.TransformPoint(localPosition);
        Vector3 verticalOffset = Vector3.up * _verticalSpawnOffset;


        Instantiate(_testPrefab, worldPosition + verticalOffset, Quaternion.identity);
    }
}
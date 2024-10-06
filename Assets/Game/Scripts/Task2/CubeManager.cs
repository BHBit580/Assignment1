using UnityEngine;
using DG.Tweening;
using MoreMountains.Feedbacks;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private MMF_Player cubeFeedback;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Ease easeType = Ease.InOutQuad;
    [SerializeField] private float moveDistance = 1f;

    private Vector3 _initialPosition;
    private Tween _startTween;
    private bool _hasStarted;

    private void Start()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_hasStarted)
        {
            Move();
            _hasStarted = true;
        }
    }

    private void Move()
    {
        _startTween = transform.DOMoveX(transform.position.x + (speed > 0 ? moveDistance : -moveDistance), 1f / Mathf.Abs(speed)).SetEase(easeType);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            ReturnToStart();
            if(_startTween != null)
            {
                _startTween.Kill();
            }
            
            cubeFeedback?.PlayFeedbacks();
        }
    }

    private void ReturnToStart()
    {
        transform.DOMove(_initialPosition, 1f / Mathf.Abs(speed)).SetEase(easeType).onComplete += () => _hasStarted = false;
    }
}
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _agent;
    private Camera _mainCamera;
    private Vector3 _cameraOffset;
    private Vector3 _lastPosition;
    private int _groundMask;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _mainCamera = Camera.main;
        _cameraOffset = _mainCamera.transform.position - transform.position;
        _mainCamera.transform.SetParent(null, true);
        _lastPosition = transform.position;
        _groundMask = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToGround(_mainCamera.ScreenPointToRay(Input.mousePosition));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReturnToLastPosition();
        }

        _animator.SetBool("isMoving", _agent.velocity.sqrMagnitude > 0.01f);
    }

    private void MoveToGround(Ray mouseRay)
    {
        if (Physics.Raycast(mouseRay, out RaycastHit hit, Mathf.Infinity, _groundMask)
            && NavMesh.SamplePosition(hit.point, out NavMeshHit destination, 1f, _agent.areaMask))
        {
            Vector3 positionBeforeClick = transform.position;
            if (_agent.SetDestination(destination.position))
            {
                _lastPosition = positionBeforeClick;
            }
        }
    }

    private void ReturnToLastPosition()
    {
        if (_agent.Warp(_lastPosition))
        {
            _agent.ResetPath();
        }
    }

    private void LateUpdate()
    {
        _mainCamera.transform.position = transform.position + _cameraOffset;
    }
}

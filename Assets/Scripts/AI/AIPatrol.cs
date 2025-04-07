using UnityEngine;
using UnityEngine.AI;

public class AIPatrol : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Transform[] waypoints;
    public float fovAngle = 65f;
    public Transform eyes;

    private Animator _animator;

    private int _currentWaypoint;
    private bool playerInRange;
    private float _threshold;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentWaypoint = 0;
        agent.SetDestination(waypoints[_currentWaypoint].position);

        float halfFOV = fovAngle / 2f;
        _threshold = Mathf.Cos(halfFOV * Mathf.Deg2Rad);

        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange) // Perseguimos al jugador
        {
            Vector3 agentDir = transform.forward;
            Vector3 playerDir = player.position - transform.position;

            if(Vector3.Dot(agentDir, playerDir) > _threshold)
            {
                bool hit = Physics.SphereCast(eyes.position, 0.15f, transform.forward, out RaycastHit hitInfo);

                if(hit && hitInfo.collider.tag == player.tag)
                {
                    agent.SetDestination(player.position);
                    return;
                }
            }
        }

        if(agent.remainingDistance < 0.1f) // Perseguimos nuestro ultimo waypoint
        {
            // Nuevo waypoint objetivo.
            _currentWaypoint = (_currentWaypoint + 1) % waypoints.Length;
            agent.SetDestination(waypoints[_currentWaypoint].position);
        }

        _animator.SetFloat("Speed", agent.speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }

    private void OnDrawGizmos()
    {
        DrawFOV();
    }

    private void DrawFOV()
    {
        SphereCollider col = GetComponent<SphereCollider>();

#if UNITY_EDITOR
        UnityEditor.Handles.color = new Color(1f, 1f, 0f, 0.2f); // Semi-transparent yellow
        Vector3 forward = transform.forward * col.radius;
        Vector3 leftBoundary = Quaternion.Euler(0, -fovAngle / 2, 0) * forward;
        Vector3 rightBoundary = Quaternion.Euler(0, fovAngle / 2, 0) * forward;

        UnityEditor.Handles.DrawSolidArc(transform.position, Vector3.up, leftBoundary, fovAngle, col.radius);
#endif
    }
}

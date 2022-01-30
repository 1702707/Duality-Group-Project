using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] bool isStatic;
    [SerializeField] float speed = 1;
    bool FacingRight;

    Collider2D _Collider;
    Animator _Animator;

    [SerializeField] Vector2 waitTime;
    [SerializeField] Transform PathHolder;
    Vector3[] waypoints;
    Vector3 targetWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        _Collider = GetComponent<Collider2D>();
        _Animator = GetComponent<Animator>();
        waypoints = new Vector3[PathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = PathHolder.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, waypoints[i].y, transform.position.z);
        }
        if(!isStatic)
        if (_Animator != null)
            _Animator.SetBool("Moving", true);
        FacingRight = false;
        StartCoroutine(FollowPath(waypoints));
    }

    // Update is called once per frame
    void Update()
    {
        //Designate sprite orientation
        if (_Animator.GetBool("Moving"))
        {
            if (targetWaypoint.x > transform.position.x)
            {
                //right
                if (!FacingRight)
                {
                    Flip(true);
                }
            }
            else if (targetWaypoint.x < transform.position.x)
            {
                //left
                if (FacingRight)
                {
                    Flip(false);
                }
            }
        }
    }


    void Flip(bool facingRight)
    {
        FacingRight = facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        int targetWaypointIndex = 1;
        targetWaypoint = waypoints[targetWaypointIndex];

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            if (transform.position == targetWaypoint)
            {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointIndex];
                if (_Animator != null)
                    _Animator.SetBool("Moving", false);
                yield return new WaitForSeconds(Random.Range(waitTime.x,waitTime.y));
                if (_Animator != null)
                    _Animator.SetBool("Moving", true);
            }
            yield return null;
        }
    }

    public void Die()
    {
        //Stop moving
        StopCoroutine(FollowPath(waypoints));
        if (_Animator != null)
            _Animator.SetBool("Dead", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                //Hurt Player
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 pathStart = PathHolder.GetChild(0).position;
        Vector3 previousPosition = pathStart;
        foreach (Transform Waypoint in PathHolder)
        {
            Gizmos.DrawSphere(Waypoint.position, .05f);
            Gizmos.DrawLine(previousPosition, Waypoint.position);
            previousPosition = Waypoint.position;
        }
        Gizmos.DrawLine(previousPosition, pathStart);
    }
}

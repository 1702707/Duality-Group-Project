using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float YHeight;
    public bool trailing;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            Vector3 position = target.transform.position;
            position.y = YHeight;
            position.z = -10;
            transform.position = position;
        }
    }

    //For some reason the movement is jittery if they arent in these specific update functions
    void LateUpdate()
    {
        if (!trailing)
        {
            if (target != null)
            {
                Vector3 Targetposition = transform.position;
                Targetposition.x = target.transform.position.x;
                transform.position = Targetposition;
            }
        }
    }

    private void FixedUpdate()
    {
        if (trailing)
        {
            if (target != null)
            {
                Vector3 Targetposition = transform.position;
                Targetposition.x = Mathf.Lerp(transform.position.x, target.transform.position.x, speed * Time.deltaTime);
                transform.position = Targetposition;
            }
        }
    }
}

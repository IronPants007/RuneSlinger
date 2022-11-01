using System.Collections;
using UnityEngine;

public class Pull : MonoBehaviour
{

    public Transform hand;

    public string pullableTag;

    public float modifier = 1.0f;

    Vector3 pullForce;

    public Transform heldObject;

    public float positionDistanceThreshold;

    public float velocityDistanceThreshold;

    public float maxVelocity;

    public float throwVelocity;

    void Update()
    {

        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag.Equals(pullableTag))
                {
                    StartCoroutine(PullObject(hit.transform));
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (heldObject != null)
            {
                heldObject.transform.parent = null;
                heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                heldObject.GetComponent<Rigidbody>().velocity = transform.forward * throwVelocity;
                heldObject = null;
            }
        }
    }

    IEnumerator PullObject(Transform t)
    {
        Rigidbody r = t.GetComponent<Rigidbody>();
        while (true)
        {

            if (Input.GetMouseButtonDown(1))
            {
                break;
            }
            float distanceToHand = Vector3.Distance(t.position, hand.position);
            if (distanceToHand < positionDistanceThreshold)
            {
                t.position = hand.position;
                t.parent = hand;
                r.constraints = RigidbodyConstraints.FreezePosition;
                heldObject = t;
                break;
            }

            Vector3 pullDirection = hand.position - t.position;

            pullForce = pullDirection.normalized * modifier;

            if (r.velocity.magnitude < maxVelocity && distanceToHand > velocityDistanceThreshold)
            {
                r.AddForce(pullForce, ForceMode.Force);
            }
            else
            {
                r.velocity = pullDirection.normalized * maxVelocity;
            }

            yield return null;
        }
    }
}
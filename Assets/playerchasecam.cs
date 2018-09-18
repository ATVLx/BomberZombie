using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerchasecam : MonoBehaviour
{
    public float smoothspeed = 0.125f;
    // Use this for initialization
    void Start()
    { }

       [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    private void LateUpdate()
    {
        Refresh();
    }

    public void startshake(float duration, float magnitude)
    {
        Debug.Log("this was called");
        float d = duration;
        float m = magnitude;
        StartCoroutine(Shakecamera(d, m));
    }


        public IEnumerator Shakecamera(float duration, float magnitude)
    {
        Debug.Log("yeah this was called");
        Vector3 orignalpos = transform.localPosition;
        float elapsedtime = 0.0f;
        while (elapsedtime < duration)
        {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;
            transform.localPosition = new Vector3(x, y, orignalpos.z);
            elapsedtime += Time.fixedDeltaTime;
            yield return null;
        }
        transform.localPosition = orignalpos;
    }


    public void Refresh()
    {
        Vector3 smoothpos = Vector3.Lerp(transform.position, target.position,smoothspeed);
        transform.position = smoothpos;
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = transform.position + offsetPosition;
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }


   



}
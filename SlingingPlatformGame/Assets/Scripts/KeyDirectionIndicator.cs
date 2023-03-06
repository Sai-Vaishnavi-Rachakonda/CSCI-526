using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyDirectionIndicator : MonoBehaviour
{
    public float HideDistance;

    // Update is called once per frame
    void Update()
    {
        var keys = GameObject.FindGameObjectsWithTag("Key");
        if(keys.Length>0)
        {
            var key = FindClosestKey(keys);
            var dir = key.position - transform.position;

            if (dir.magnitude < HideDistance)
            {
                SetChildrenActive(false);
            }
            else
            {
                SetChildrenActive(true);
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }

    }

    void SetChildrenActive(bool val)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(val);
        }
    }

    Transform FindClosestKey(GameObject[] Keys)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in Keys)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t.transform;
                minDist = dist;
            }
        }
        return tMin;
    }
}
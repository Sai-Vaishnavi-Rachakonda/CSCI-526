using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class KeyDirectionIndicator : MonoBehaviour
{
    public float HideDistance;

    // Update is called once per frame
    void Update()
    {
        var keys = new List<GameObject>();
            keys.AddRange(GameObject.FindGameObjectsWithTag("Key").ToList());
            keys.AddRange(GameObject.FindGameObjectsWithTag("door color").ToList());
        if(keys.Count>0)
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
        else
        {
            SetChildrenActive(false);
        }

    }

    void SetChildrenActive(bool val)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(val);
        }
    }

    Transform FindClosestKey(List<GameObject> Keys)
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
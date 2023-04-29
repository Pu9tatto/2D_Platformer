using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Platform : LayerCheck
{
    private List<GameObject> _platformChilds = new List<GameObject>();
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.IsInLayer(_layer))
        {
            other.gameObject.transform.parent = transform;
            _platformChilds.Add(other.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.IsInLayer(_layer))
        {
            other.gameObject.transform.parent = null;
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
        //foreach(GameObject child in _platformChilds)
        //{
        //    child.transform.parent = null;
        //}
    }
}

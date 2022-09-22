using System.Collections;
using System.Linq;
using UnityEngine;

public class Batch : MonoBehaviour
{
    private int childrenCount, activeChildrenCount;
    private float left, right;
    private bool isActive = false;
    private bool goingRight = false;
    void Update()
    {
        if (isActive)
        {
            CalculateEdgeChildren();
            if (right > Constants.maxEnemyX)
            {
                goingRight = false;
            }
            if(left < Constants.minEnemyX)
            {
                goingRight = true;
            }
            transform.position += Time.deltaTime*(goingRight?Vector3.right:Vector3.left)* Constants.BatchHorizontalSpeed;
        }
    }

    public void SetChildrenCount(int childrenCount)
    {
        this.childrenCount = childrenCount;
    }

    public void SetChildrenActive()
    {
        activeChildrenCount++;
        if(activeChildrenCount == childrenCount)
        {
            isActive = true;
        }
    }

    private void CalculateEdgeChildren()
    {
        Transform[] childrenTransforms = gameObject.GetComponentsInChildren<Transform>();
        childrenTransforms = childrenTransforms.Where(transform => transform.gameObject.GetInstanceID() != gameObject.GetInstanceID()).ToArray();
        if (childrenTransforms.Length == 0)
        {
            isActive = false;
            Destroy(gameObject);
        }
        left = float.MaxValue;
        right = float.MinValue;
        foreach(Transform children in childrenTransforms)
        {
            left = Mathf.Min(left, children.position.x);
            right = Mathf.Max(right, children.position.x);
        }
    }

    private void ChildrenDestroyed()
    {
        StartCoroutine(ChildrenDestroyedCoroutine());
    }

    private IEnumerator ChildrenDestroyedCoroutine()
    {
        yield return new WaitForSeconds(Constants.ChildDestroyCoroutineDelay);
        Transform[] childrenTransforms = gameObject.GetComponentsInChildren<Transform>();
        childrenTransforms = childrenTransforms.Where(transform => transform.gameObject.GetInstanceID() != gameObject.GetInstanceID()).ToArray();
        if (childrenTransforms.Length == 0)
        {
            isActive = false;
            SendMessageUpwards("ChildrenDestroyed");
            Destroy(gameObject);
        }
    }
}

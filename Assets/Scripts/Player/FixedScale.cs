using UnityEngine;

[ExecuteInEditMode]
public class FixedScale : MonoBehaviour
{

    public float FixeScale = 1;
    public GameObject parent;

    public void Update()
    {
        transform.localScale = new Vector3(FixeScale / parent.transform.localScale.x, FixeScale / parent.transform.localScale.y, FixeScale / parent.transform.localScale.z);

    }
}
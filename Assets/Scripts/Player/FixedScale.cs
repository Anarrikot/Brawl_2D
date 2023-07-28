using UnityEngine;

[ExecuteInEditMode]
public class FixedScale : MonoBehaviour
{

    public float FixeScaleX = 1;
    public float FixeScaleY = 1;
    public GameObject parent;

    public void Update()
    {
        transform.localScale = new Vector3(FixeScaleX / parent.transform.localScale.x, FixeScaleY / parent.transform.localScale.y, 1);
    }
}
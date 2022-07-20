using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowEffect : MonoBehaviour
{
    public Vector2 Offset = new Vector2(-0.1f, -0.1f);
    public Material ShadowMaterial;
    public GameObject shadow;
    // Start is called before the first frame update
    void Start()
    {
        shadow = new GameObject("Shadow");
        shadow.transform.parent = this.gameObject.transform;

        shadow.transform.localPosition = Offset;
        shadow.transform.localRotation = Quaternion.identity;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        SpriteRenderer shadowRenderer = shadow.AddComponent<SpriteRenderer>();

        shadowRenderer.sprite = renderer.sprite;
        shadowRenderer.material = ShadowMaterial;

        shadowRenderer.sortingOrder = renderer.sortingOrder - 1;

    }

    private void LateUpdate()
    {
        shadow.transform.localPosition = Offset;
    }


}

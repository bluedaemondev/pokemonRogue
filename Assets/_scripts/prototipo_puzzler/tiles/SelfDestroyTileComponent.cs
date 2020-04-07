using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyTileComponent : MonoBehaviour
{
    public Transform tilesetCol;

    private void Start()
    {
        this.tilesetCol = this.GetComponentInParent<Transform>();
    }
}

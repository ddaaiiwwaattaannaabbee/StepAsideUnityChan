using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

    void OnBecameInvisible() {
        Destroy (this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionBig : MonoBehaviour
{
    static public bool found = false;

    void OnTriggerEnter (Collider Other) {
        if (Other.name == "PlayerBody") {
            found = true;
        }
    }

    private void OnTriggerExit (Collider Other) {
        if (Other.name == "PlayerBody") {
            found = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static FXManager inst;

    private void Awake() {
        inst = this;
    }
}

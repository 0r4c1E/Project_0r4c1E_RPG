using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class MainSystem : MonoBehaviour
{
    [Title("Game System", "to Scene")]
    [SerializeField] public static MainSystem inst;

    [Title("Status", "Datas")]
    public PlayerMoveData playerMoveData;
    [Title("Status", "Objects")]
    
    private void Awake() {
        inst = this;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RPGCharacterAnims;

[System.Serializable]
public class PlayerMoveData{
    public float speed;
    public float movePos;
}
public class PlayerController : MonoBehaviour
{
    public Transform body;
    private Animator myAnim;
    private PlayerMoveData playerMoveData;
    private Vector3 pos_Character;
    private Vector3 pos_Camera;
    public UnityEvent OnHit = new UnityEvent();
    public UnityEvent OnShoot = new UnityEvent();
    public UnityEvent OnFootR = new UnityEvent();
    public UnityEvent OnFootL = new UnityEvent();
    public UnityEvent OnLand = new UnityEvent();
    
    private Vector3 pos_BaseCamera;
    private void Start() {
        myAnim = transform.GetChild(0).GetComponent<Animator>();
        myAnim.gameObject.AddComponent<RPGCharacterAnimatorEvents>();
        myAnim.updateMode = AnimatorUpdateMode.AnimatePhysics;
        myAnim.cullingMode = AnimatorCullingMode.CullUpdateTransforms;
        // myRig = MainSystem.inst.player.GetComponent<Rigidbody>();
        playerMoveData = MainSystem.inst.playerMoveData;
        SetBaseCamera();
    }
    void SetBaseCamera(){
        pos_BaseCamera = Camera.main.transform.position;
    }
    void Update()
    {
        // pos_Camera = body.position;
        // pos_Camera.x += pos_BaseCamera.x;
        // pos_Camera.z += pos_BaseCamera.z;
        // Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, pos_Camera, Time.deltaTime * 10);
        // 위로이동
        if(Input.GetKey(KeyCode.W)){
            pos_Character = body.position;
            pos_Character.z += playerMoveData.movePos;
            body.position = Vector3.Lerp(body.position, pos_Character, Time.deltaTime * playerMoveData.speed);
            body.LookAt(pos_Character);
            myAnim.SetBool("Move", true);
        }
        // 좌측이동
        if(Input.GetKey(KeyCode.A)){
            pos_Character = body.position;
            pos_Character.x -= playerMoveData.movePos;
            body.position = Vector3.Lerp(body.position, pos_Character, Time.deltaTime * playerMoveData.speed);
            body.LookAt(pos_Character);
            myAnim.SetBool("Move", true);
        }
        // 아래이동
        if(Input.GetKey(KeyCode.S)){
            pos_Character = body.position;
            pos_Character.z -= playerMoveData.movePos;
            body.position = Vector3.Lerp(body.position, pos_Character, Time.deltaTime * playerMoveData.speed);
            body.LookAt(pos_Character);
            myAnim.SetBool("Move", true);
        }
        // 우측이동
        if(Input.GetKey(KeyCode.D)){
            pos_Character = body.position;
            pos_Character.x += playerMoveData.movePos;
            body.position = Vector3.Lerp(body.position, pos_Character, Time.deltaTime * playerMoveData.speed);
            body.LookAt(pos_Character);
            myAnim.SetBool("Move", true);
        }
        if(Input.GetKey(KeyCode.F1)){
            myAnim.SetTrigger("Hi");
        }
        if(Input.GetKey(KeyCode.Mouse0)){

        }
        if(Input.GetKey(KeyCode.Mouse1)){
            
        }
        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)){
            myAnim.SetBool("Move", false);
        }
    }
    
    public void Hit()
    {
    }
    public void Shoot()
    {
    }
    public void FootR()
    {
    }
    public void FootL()
    {
    }
    public void Land()
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    
    [SerializeField]
    private float moveSpeed = 0;
    private Quaternion currentAngle;

    Camera mCamera;

    [SerializeField]
    public List<StateMachine> pStates;

    PlayerStates currPlayerState = null;

    [SerializeField]
    private GameObject body, lArm, rArm;


    public GameObject handRotationAngle;

    public bool combatMode;

    public float cameraRotSpeed = 1;


    /*[SerializeField]
    [Range(10f, 100f)]
    private float rotateSpeed = 10f;

    private bool isIdle = true;*/

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Q))
        {
            mCamera.transform.rotation = Quaternion.Euler(mCamera.transform.rotation.eulerAngles.x, mCamera.transform.rotation.eulerAngles.y, mCamera.transform.rotation.eulerAngles.z + cameraRotSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            mCamera.transform.rotation = Quaternion.Euler(mCamera.transform.rotation.eulerAngles.x, mCamera.transform.rotation.eulerAngles.y, mCamera.transform.rotation.eulerAngles.z - cameraRotSpeed);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            combatMode = true;
        }
        if(Input.GetButtonUp("Fire1"))
        {
            if (currPlayerState != pStates.Find(x => x.name == "idle").playerState)
            {
                Debug.Log("Idle state found");
                if (pStates.Find(x => x.name == "idle") != null)
                    currPlayerState = pStates.Find(x => x.name == "idle").playerState;
                currPlayerState.AssignState(body: body, lArm: lArm, rArm: rArm);
            }
            combatMode = false;
        }
        if (GetComponent<Rigidbody2D>().velocity != new Vector2(0, 0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), moveSpeed * Input.GetAxis("Vertical"));
            GetComponent<Rigidbody2D>().velocity = Camera.main.transform.TransformDirection(GetComponent<Rigidbody2D>().velocity);

        }
        else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), moveSpeed * Input.GetAxis("Vertical"));
            GetComponent<Rigidbody2D>().velocity = Camera.main.transform.TransformDirection(GetComponent<Rigidbody2D>().velocity);
        }



        if (combatMode == false) {
            if (GetComponent<Rigidbody2D>().velocity.x < 0)
            {

                if (pStates.Find(x => x.name == "right") != null)
                    currPlayerState = pStates.Find(x => x.name == "right").playerState;
                currPlayerState.AssignState(body: body, lArm: lArm, rArm: rArm);
            }
            else if (GetComponent<Rigidbody2D>().velocity.x > 0)
            {

                if (pStates.Find(x => x.name == "left") != null)
                    currPlayerState = pStates.Find(x => x.name == "left").playerState;
                currPlayerState.AssignState(body: body, lArm: lArm, rArm: rArm);
            }

            else if (GetComponent<Rigidbody2D>().velocity.y > 0)
            {

                if (pStates.Find(x => x.name == "up") != null)
                    currPlayerState = pStates.Find(x => x.name == "up").playerState;
                currPlayerState.AssignState(body: body, lArm: lArm, rArm: rArm);
            }

            else if (GetComponent<Rigidbody2D>().velocity.y < 0)
            {

                if (pStates.Find(x => x.name == "down") != null)
                    currPlayerState = pStates.Find(x => x.name == "down").playerState;
                currPlayerState.AssignState(body: body, lArm: lArm, rArm: rArm);
            }
        }
        
        if (combatMode)
        {
            if (handRotationAngle.GetComponent<Transform>().localRotation.eulerAngles.z >= 71 && handRotationAngle.GetComponent<Transform>().localRotation.eulerAngles.z < 181)
            {
                if (currPlayerState != pStates.Find(x => x.name == "down").playerState)
                {
                    if (pStates.Find(x => x.name == "down") != null)
                        currPlayerState = pStates.Find(x => x.name == "down").playerState;
                    currPlayerState.AssignState(body: body, lArm: lArm, rArm: rArm);
                }
            }
            else if (handRotationAngle.GetComponent<Transform>().localRotation.eulerAngles.z >= 0 && handRotationAngle.GetComponent<Transform>().localRotation.eulerAngles.z < 71)
            {
                if (currPlayerState != pStates.Find(x => x.name == "right").playerState)
                {
                    if (pStates.Find(x => x.name == "right") != null)
                        currPlayerState = pStates.Find(x => x.name == "right").playerState;
                    currPlayerState.AssignState(body: body, lArm: lArm, rArm: rArm);
                }
            }
            else if (handRotationAngle.GetComponent<Transform>().localRotation.eulerAngles.z >= 181 && handRotationAngle.GetComponent<Transform>().localRotation.eulerAngles.z < 254)
            {
                if (currPlayerState != pStates.Find(x => x.name == "left").playerState)
                {
                    if (pStates.Find(x => x.name == "left") != null)
                        currPlayerState = pStates.Find(x => x.name == "left").playerState;
                    currPlayerState.AssignState(body: body, lArm: lArm, rArm: rArm);
                }
            }
            else if (handRotationAngle.GetComponent<Transform>().localRotation.eulerAngles.z >= 254 && handRotationAngle.GetComponent<Transform>().localRotation.eulerAngles.z < 360)
            {
                if (currPlayerState != pStates.Find(x => x.name == "up").playerState)
                {
                    if (pStates.Find(x => x.name == "up") != null)
                        currPlayerState = pStates.Find(x => x.name == "up").playerState;
                    currPlayerState.AssignState(body: body, lArm: lArm, rArm: rArm);
                }
            }
        }

        /*if (body.GetComponent<SpriteRenderer>().sprite == null && currPlayerState!= null)
        {
            currPlayerState.AssignState(body: body, lArm: lArm, rArm: rArm);
        }*/

        /*
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            rangerBody.gameObject.GetComponent<SpriteRenderer>().sprite = rBodyRight;
            rangerLArm.gameObject.GetComponent<SpriteRenderer>().sprite = rLArmRight;
            rangerRArm.gameObject.GetComponent<SpriteRenderer>().sprite = rRArmRight;
        }
        else if (GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            rangerBody.gameObject.GetComponent<SpriteRenderer>().sprite = rBodyUp;
            rangerLArm.gameObject.GetComponent<SpriteRenderer>().sprite = rLArmUp;
            rangerRArm.gameObject.GetComponent<SpriteRenderer>().sprite = rRArmUp;
        }
        else if (GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            rangerBody.gameObject.GetComponent<SpriteRenderer>().sprite = rBodyDown;
            rangerLArm.gameObject.GetComponent<SpriteRenderer>().sprite = rLArmDown;
            rangerRArm.gameObject.GetComponent<SpriteRenderer>().sprite = rRArmDown;
        }*/
    }

    private void FixedUpdate()
    {
        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(ray.origin, ray.direction * 10000, Color.cyan);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10000);
        if (hit.collider != null)
        {

            Vector3 hitPoint = hit.point;

            Vector3 targetDir = hitPoint - transform.position;

            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            
            Quaternion targetAngle = Quaternion.AngleAxis(angle, Vector3.forward);
            Debug.DrawRay(ray.origin, targetDir, Color.red);
            lArm.transform.rotation = Quaternion.Slerp(lArm.transform.rotation, targetAngle, rotateSpeed * Time.deltaTime);
            rArm.transform.rotation = Quaternion.Slerp(rArm.transform.rotation, targetAngle, rotateSpeed * Time.deltaTime);
            

        }*/
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        dir = Camera.main.transform.TransformDirection(dir);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var angleHandRot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (combatMode == true)
        {
            if (currPlayerState == pStates.Find(x => x.name == "down").playerState)
            {
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + lArm.transform.localRotation.z + 90;
                lArm.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                rArm.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            else if(currPlayerState == pStates.Find(x => x.name == "right").playerState)
            {
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + lArm.transform.localRotation.z - 180;
                lArm.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                rArm.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            else if(currPlayerState == pStates.Find(x => x.name == "left").playerState)
            {
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                lArm.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                rArm.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            else if(currPlayerState == pStates.Find(x => x.name == "up").playerState)
            {
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + lArm.transform.localRotation.z -90;
                lArm.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                rArm.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            handRotationAngle.transform.rotation = Quaternion.AngleAxis(angleHandRot, Vector3.forward);
        }

    }

    private void Start()
    {
        mCamera = Camera.main;
    }


}

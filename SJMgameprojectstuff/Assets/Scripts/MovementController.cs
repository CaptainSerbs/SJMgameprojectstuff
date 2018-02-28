using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    
    [SerializeField]
    private float moveSpeed = 0;
    private Quaternion currentAngle;
    // 0 = right, 1 = left
    private float charDir = 0;

    public GameObject rangerBody, rangerLArm, rangerRArm;
    public Sprite rBodyRight, rBodyLeft, rBodyUp, rBodyDown;
    public Sprite rLArmRight, rLArmLeft, rLArmUp, rLArmDown;
    public Sprite rRArmRight, rRArmLeft, rRArmUp, rRArmDown;

    public GameObject handRotationAngle;

    public bool combatMode;


    [SerializeField]
    [Range(10f, 100f)]
    private float rotateSpeed = 10f;

    [SerializeField]
    private GameObject lArm;
    [SerializeField]
    private GameObject rArm;

    // Update is called once per frame
    void Update () {

        if (Input.GetButton("Fire1"))
        {
            combatMode = true;
        }
        else
        {
            combatMode = false;
        }

        if(GetComponent<Rigidbody2D>().velocity != new Vector2(0, 0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), GetComponent<Rigidbody2D>().velocity.y);

            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, moveSpeed * Input.GetAxis("Vertical"));
            } else if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), GetComponent<Rigidbody2D>().velocity.y);

                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, moveSpeed * Input.GetAxis("Vertical"));
            }
        /*if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.localScale = new Vector2(1,1);
            
            rangerBody.gameObject.GetComponent<SpriteRenderer>().sprite = rBodyLeft;
            rangerLArm.gameObject.GetComponent<SpriteRenderer>().sprite = rLArmLeft;
            rangerRArm.gameObject.GetComponent<SpriteRenderer>().sprite = rRArmLeft;
            
        }
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
        if (combatMode == true)
        {
            var pos = Camera.main.WorldToScreenPoint(transform.position);
            var dir = Input.mousePosition - pos;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            lArm.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            rArm.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            handRotationAngle.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    
    [SerializeField]
    private float moveSpeed = 0;
    private Quaternion currentAngle;


    [SerializeField]
    [Range(10f, 100f)]
    private float rotateSpeed = 10f;

    [SerializeField]
    private GameObject lArm;
    [SerializeField]
    private GameObject rArm;

    // Update is called once per frame
    void Update () {

        if(GetComponent<Rigidbody2D>().velocity != new Vector2(0, 0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), GetComponent<Rigidbody2D>().velocity.y);

            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, moveSpeed * Input.GetAxis("Vertical"));
            } else if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), GetComponent<Rigidbody2D>().velocity.y);

                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, moveSpeed * Input.GetAxis("Vertical"));
            }
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            // Suunta on oikea
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            // Suunta on vasemmalle
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(ray.origin, ray.direction * 10000, Color.cyan);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10000);
        if (hit.collider != null)
        {
            Debug.Log("Hit!");
            Debug.Log(hit.collider.name);

            Vector3 hitPoint = hit.point;

            Vector3 targetDir = hitPoint - transform.position;

            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            Quaternion targetAngle = Quaternion.AngleAxis(angle, Vector3.forward);
            lArm.transform.rotation = Quaternion.Slerp(lArm.transform.rotation, targetAngle, rotateSpeed * Time.deltaTime);
            rArm.transform.rotation = Quaternion.Slerp(rArm.transform.rotation, targetAngle, rotateSpeed * Time.deltaTime);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D PlayerRb;
    private Animator PlayeraAnim;
    private Vector2 direction;
    [SerializeField] float speed;
    private Vector3 SelectedMapPosition;
    Camera cam;
    private bool canMove;
    void Start()
    {
        cam = Camera.main;
        PlayerRb = GetComponent<Rigidbody2D>();
        PlayeraAnim = GetComponent<Animator>(); 
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !canMove)
        {
            Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D rayHit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if(rayHit.transform != null)
            {
                SelectedMapPosition = rayHit.transform.position;
                SelectedMapPosition.z = transform.position.z;
                canMove = Mathf.Abs(SelectedMapPosition.x - transform.position.x) <= 1f &&
                    Mathf.Abs(SelectedMapPosition.y - transform.position.y) <= 0.1f ||
                    Mathf.Abs(SelectedMapPosition.y - transform.position.y) <= 1f &&
                    Mathf.Abs(SelectedMapPosition.x - transform.position.x) <= 0.1f;
            }
            Vector3 direction = SelectedMapPosition - transform.position;
            direction = direction.normalized;

            
        }

        if (Mathf.Abs(SelectedMapPosition.x - transform.position.x) > 0.001f && canMove || Mathf.Abs(SelectedMapPosition.y - transform.position.y) > 0.001f && canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, SelectedMapPosition, speed * Time.deltaTime);
            return;
        }

        canMove = false;
        //direction.x = Input.GetAxis("Horizontal");
        //direction.y = Input.GetAxis("Vertical");
    }
    
    void FixedUpdate()
    {
        //PlayeraAnim.SetFloat("Speed", direction.magnitude);
        //PlayeraAnim.SetFloat("Horizontal", direction.x);
        //PlayeraAnim.SetFloat("Vertical", direction.y);
        //PlayerRb.MovePosition(PlayerRb.position + direction.normalized * speed * Time.fixedDeltaTime);
        
       
    }

}

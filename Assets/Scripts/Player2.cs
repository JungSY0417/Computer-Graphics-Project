using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private Vector3 movement;
    Rigidbody rigidbody;
    GameObject playerEquipPoint;
    GameObject tennisBall;

    public float speed;
    public float force;
    public Animator anim;

    public bool canServe;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        
        playerEquipPoint = GameObject.FindGameObjectWithTag("leftHand2");
        tennisBall = GameObject.FindGameObjectWithTag("tennisBall");

        canServe = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
        forehand();
        backhand();
        if(canServe) {
            serve();
            
        }
    }

    void forehand() {
        if(Input.GetKey(KeyCode.LeftAlt) && 
                !anim.GetCurrentAnimatorStateInfo(0).IsName("forehand")) {
            anim.SetBool("IsForeHand", true);
        }
        else {
            anim.SetBool("IsForeHand", false);
        }
    }

    void backhand() {
        if(Input.GetKey(KeyCode.LeftControl) && 
                !anim.GetCurrentAnimatorStateInfo(0).IsName("backhand")) {
           anim.SetBool("IsBackHand", true);
        }
        else {
            anim.SetBool("IsBackHand", false);
        }
    }

    void serve() {
        if(Input.GetKey(KeyCode.LeftShift)) {
            anim.SetBool("IsServe", true);
            PickUp(playerEquipPoint, tennisBall);
            drop();
            GetComponent<Animator>().Play("Serve");
        }
        else
            anim.SetBool("IsServe", false);
    }

    //PickUp, Drop, SetEquip from 'https://m.blog.naver.com/gold_metal/220526236275'
    public void PickUp(GameObject playerEquipPoint, GameObject ball) {
        ball.transform.SetParent(playerEquipPoint.transform);
        ball.transform.localPosition = new Vector3(-0.0001f, -0.0001f, 0f);
        ball.transform.rotation =  new Quaternion(0, 0, 0, 0);

        SetEquip(ball, true);
    }

    void drop() {
        GameObject ball = playerEquipPoint.GetComponentInChildren<Rigidbody>().gameObject;
        Rigidbody rigidbody = ball.GetComponent<Rigidbody> ();

        SetEquip(ball, false);
        playerEquipPoint.transform.DetachChildren();

        Vector3 throwAngle = transform.up * 3.31f + transform.right * 1.2f;

        rigidbody.AddForce(throwAngle, ForceMode.Impulse);

        anim.SetBool("IsServe", false);
    }

    void SetEquip(GameObject ball, bool isEquip) {
        Collider[] ballColliders = ball.GetComponents<Collider> ();
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody> ();

        foreach(Collider ballCollider in ballColliders) {
            ballCollider.enabled = !isEquip;
        }

        ballRigidbody.isKinematic = isEquip;
    }

    void move() {
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)) {
            anim.SetBool("IsBackWardRun", false);
            anim.SetBool("IsRun", true);
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, Quaternion.LookRotation(Vector3.left + Vector3.forward), 10 * Time.deltaTime);
            movement = (Vector3.left + Vector3.forward) * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + movement);
        }
        else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)) {
            anim.SetBool("IsBackWardRun", false);
            anim.SetBool("IsRun", true);
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, Quaternion.LookRotation(Vector3.right + Vector3.forward), 10 * Time.deltaTime);
            movement = (Vector3.right + Vector3.forward) * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + movement);
        }
        else if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) {
            anim.SetBool("IsBackWardRun", true);
            anim.SetBool("IsRun", false);
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, Quaternion.LookRotation(Vector3.right + Vector3.forward), 10 * Time.deltaTime);
            movement = (Vector3.left + Vector3.back) * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + movement);
        }
        else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)) {
            anim.SetBool("IsBackWardRun", true);
            anim.SetBool("IsRun", false);
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, Quaternion.LookRotation(Vector3.left + Vector3.forward), 10 * Time.deltaTime);
            movement = (Vector3.right + Vector3.back) * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + movement);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            anim.SetBool("IsBackWardRun", false);
            anim.SetBool("IsRun", true);
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, Quaternion.LookRotation(Vector3.left), 10 * Time.deltaTime);
            movement = Vector3.left * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + movement);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            anim.SetBool("IsBackWardRun", false);
            anim.SetBool("IsRun", true);
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, Quaternion.LookRotation(Vector3.right), 10 * Time.deltaTime);
            movement = Vector3.right * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + movement);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            anim.SetBool("IsBackWardRun", false);
            anim.SetBool("IsRun", true);
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, Quaternion.LookRotation(Vector3.forward), 10 * Time.deltaTime);
            movement = Vector3.forward * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + movement);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            anim.SetBool("IsRun", false);
            anim.SetBool("IsBackWardRun", true);
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, Quaternion.LookRotation(Vector3.forward), 10 * Time.deltaTime);
            movement = Vector3.back * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + movement);
        }
        else
        {
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, Quaternion.LookRotation(Vector3.forward), 10 * Time.deltaTime);
            anim.SetBool("IsRun", false);
            anim.SetBool("IsBackWardRun", false);
        }
    }
}

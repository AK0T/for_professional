using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField]
    private Vector3 startpos;
    [SerializeField]
    private Vector3 endpos;
    private Rigidbody rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float time;
    private bool start_timer;
    public bool is_fly = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        is_fly = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startpos = Input.mousePosition;
            start_timer = true;
            StartCoroutine("timer");
            
        }

        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            start_timer = false;
            endpos = Input.mousePosition;
            CheckSpeed();
            startpos = Vector3.zero;
            endpos = Vector3.zero;
            time = 0;
            if (!is_fly)
            {
                is_fly = true;
                if (speed < 300)
                {
                    rb.AddForce(Vector3.fwd * 10, ForceMode.Impulse);
                    rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
                }
                else if (speed > 300 && speed < 500)
                {
                    rb.AddForce(Vector3.fwd * 30, ForceMode.Impulse);
                    rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
                }
                else if (speed > 300)
                {
                    rb.AddForce(Vector3.fwd * 50, ForceMode.Impulse);
                    rb.AddForce(Vector3.up * 20, ForceMode.Impulse);
                }
            }
        }

        if (transform.position.y < -0.664f)
        {
            Destroy(this.gameObject);
            is_fly = false;
        }
    }

    private void OnMouseDown()
    {
        //rb.AddForce(Vector3.fwd * 50,  ForceMode.Impulse);
        //rb.AddForce(Vector3.up * 20, ForceMode.Impulse);
        //rb.velocity = new Vector3(rb.velocity.x, 5, 30);
    }

    public void CheckSpeed()
    {
        speed = Mathf.Sqrt(((endpos.x - startpos.x)*(endpos.x - startpos.x)) + ((endpos.y - startpos.y) * (endpos.y - startpos.y)) + ((endpos.z - startpos.z) * (endpos.z - startpos.z))) / time;
    }

    IEnumerator timer()
    {
        while (start_timer)
        {
            yield return new WaitForSeconds(0.1f);
            time += 1;
        }

    }
   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggler : MonoBehaviour
{
	Rigidbody2D rbWiggler;
	[SerializeField] float speed = 3f;
    [SerializeField] Transform point1, point2;
    [SerializeField] LayerMask layer;
    [SerializeField] bool iscolliding;

    private void Awake()
    {
        rbWiggler = GetComponent<Rigidbody2D>();
    }

    void Start()
	{

	}

    private void FixedUpdate()
    {
		rbWiggler.velocity = new Vector2(speed, rbWiggler.velocity.y);

		iscolliding = Physics2D.Linecast(point1.position, point2.position, layer);

        if (iscolliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            speed *= -1;
        }
    }

    void Update()
	{

	}

}

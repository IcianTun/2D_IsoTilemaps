using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{

    public GameObject projectilePrefab;

    public float movementSpeed = 2.5f;
    IsometricCharacterRenderer isoRenderer;

    Rigidbody2D rbody;

    [HideInInspector]
    public bool isMoving = false;
    public Vector2 movementInput;
    public Vector2 lookDir;

    [HideInInspector]
    public bool isAttacking = false;
    public float attackInterval = 0.7f;
    public float attackTimer = -1f;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();

    }

    private void Start()
    {

        lookDir = new Vector2(0, -1);
        isoRenderer.SetDirection(lookDir);
    }

    private void Update()
    {
        if (isAttacking && attackTimer <= 0)
        {
            Attack();
            attackTimer = attackInterval;
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Application.isEditor)
        //{
        //    Vector2 currentPos = rbody.position;
        //    float horizontalInput = Input.GetAxis("Horizontal");
        //    float verticalInput = Input.GetAxis("Vertical");
        //    Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        //    inputVector = Vector2.ClampMagnitude(inputVector, 1);
        //    Vector2 movement = inputVector * movementSpeed;
        //    Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        //    isoRenderer.SetDirection(movement);
        //    rbody.MovePosition(newPos);
        //}
        if (isMoving)
        {
            Move();
        }
        else
        {
            isoRenderer.SetDirection(Vector2.zero);
        }
    }

    private void Move()
    {
        Vector2 currentPos = rbody.position;
        Vector2 movement = Vector2.ClampMagnitude(movementInput, 1) * movementSpeed;

        if (movement != Vector2.zero)
        {
            lookDir = movement.normalized;
        }
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
    }


    private void Attack()
    {
        Debug.Log("Attack!");
        //Vector3 spawnPos = transform.position +
        GameObject shootedProjectile = Instantiate(projectilePrefab, transform.position + ((Vector3)lookDir) * 0.3f, Quaternion.identity);
        shootedProjectile.GetComponent<Projectile>().Launch(lookDir);
    }

    public void AttackButtonHandler(bool isPressing)
    {
        isAttacking = isPressing;
    }


}

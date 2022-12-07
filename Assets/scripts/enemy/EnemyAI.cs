using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    enemyAction _enemyState;

    [SerializeField] Transform groundCheck;
    float groundDistance = 0.38f;
    [SerializeField] LayerMask groundMask;

    public GameObject Player;
    public NavMeshAgent AINavMeshAgent;

    public float JumpHeight;
    public float MoveSpeed;
    Rigidbody _rb;

    float _randomJumpTime;
    bool _justJumped;
    public bool isGrounded;
    float _jumpTimer;
    // Start is called before the first frame update
    private void Awake()
    {
        AINavMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        _rb = gameObject.GetComponent<Rigidbody>();
        AINavMeshAgent.enabled = false;
        _rb.isKinematic = false;
        _rb.useGravity = true;
        JumpHeight = 10;
    }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        setRandomJumpTime();
        _justJumped = false;
        _enemyState = GameObject.Find("infoManager").GetComponent<battleInfo>().AIInput;

    }

    // Update is called once per frame
    void Update()
    {
        bodyFacePlayer();
        enemyMovement();
        checkingForGround();
    }

    private void FixedUpdate()
    {
        if (_enemyState != enemyAction.EarthAttack)
        {
            enemyJump();
        }
    }
    void bodyFacePlayer()
    {
        Vector3 difference = Player.transform.position - transform.position;
        float rotationY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, rotationY, 0.0f);
    }

    void enemyMovement()
    {
        if (AINavMeshAgent.enabled == true)
        {
            if (Vector3.Distance(Player.transform.position, transform.position) >= 25)
            {
                AINavMeshAgent.SetDestination(Player.transform.position);

            }
            if (Vector3.Distance(Player.transform.position, transform.position) < 25)
            {
                AINavMeshAgent.SetDestination(findRandomPos());
            }
        }
    }
    void enemyJump()
    {
        if (_randomJumpTime <= Time.time)
        {
            _rb.useGravity = false;
            AINavMeshAgent.enabled = false;
            _rb.isKinematic = false;
            _rb.useGravity = true;
            _rb.AddRelativeForce(new Vector3(0, 1f* JumpHeight, 0), ForceMode.Impulse);
            _rb.AddRelativeForce(new Vector3(Random.Range(-2,2) * JumpHeight, 0, 0), ForceMode.Impulse);
            setRandomJumpTime();
            _justJumped = true;
            _jumpTimer = Time.time + 2;
        }

    }

    Vector3 findRandomPos()
    {
        Vector3 newPos;
        float randomX = Player.transform.position.x + Random.Range(-20, 20);
        float randomZ = Player.transform.position.z + Random.Range(-20, 20);
        newPos = new Vector3(randomX, Player.transform.position.y, randomZ);
        return newPos;
    }

    void setRandomJumpTime()
    {
        _randomJumpTime = Time.time + Random.Range(3, 15);
    }

    void checkingForGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (_justJumped == false && isGrounded == true)
        {
            _rb.isKinematic = true;
            _rb.useGravity = false;
            AINavMeshAgent.enabled = true;
        }
        if (_jumpTimer <= Time.time)
        {
            _justJumped = false;
        }
    }
}

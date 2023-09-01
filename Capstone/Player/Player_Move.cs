using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;

public class Player_Move : MonoBehaviour
{
    public PhotonView pv;
    public Player_Spine player_Spine;
    public Skill_Cooldown dashCooldown;

    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    ParticleSystem dashParticle;
    Transform dashParticleContainer;

    public AudioClip footStepSound;
    public float footStepDelay;

    private float nextFootstep = 0;

    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float xTurnSpeed;
    [SerializeField] float yTurnSpeed;
    [SerializeField] float jumpHeight = 3f;

    public Transform cam_group_Tr;

    Rigidbody m_rb;
    Animator animator;
    AudioSource audioSource;

    [SerializeField] bool recoil_right;
    [SerializeField] float recoil_h;
    [SerializeField] float recoil_v;
    [SerializeField] float recoil_h_force;
    [SerializeField] float recoil_v_force;

    float preRox = 0;
    float rox = 0;
    [SerializeField] private bool canDash = true;
    [SerializeField] private bool isDashing = false;
    float dashingTime = 0.1f;
    public float dashCooldownTime;
    public float dashingPower;
    public Vector3 dashingVelocity;

    public float gravityScale = 1.0f;
    public float gravity = -9.81f;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameManager GM = GameObject.Find("GM").GetComponent<GameManager>();

        if (pv && pv.IsMine)
        {
            pv.RPC("SaveActorNumbers", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber);
            GM.myPlayer = gameObject;
        }
        
        if (pv && !pv.IsMine)
        {
            gameObject.tag = "Team_Player";
            Destroy(this);
            return;
        }

        dashCooldown = GM.dashCooldown;
        dashParticle = GM.dashParticle;
        dashParticleContainer = GM.dashParticleContainer;
        player_Spine.theCam = GM.main_camera;
        player_Spine.uiCam = GM.ui_camera;
        player_Spine.cameraShake = GM.cameraShake;
        player_Spine.theCam.transform.SetParent(cam_group_Tr);
        player_Spine.theCam.transform.localPosition = Vector3.zero;
        player_Spine.theCam.transform.localEulerAngles = Vector3.zero;
        player_Spine.uiCam.transform.SetParent(cam_group_Tr);
        player_Spine.uiCam.transform.localPosition = Vector3.zero;
        player_Spine.uiCam.transform.localEulerAngles = Vector3.zero;
        
    }


    private void Update()
    {
        if (pv && !pv.IsMine)
            return;
        m_rb.AddForce(gravity * gravityScale * Vector3.up, ForceMode.Acceleration);

        Move();

        if (ETC_Memory.Instance.windowDepth > 0)
            return;

        // TPS MODE
        //TPS_Mode_Update();

        // FPS MODE
        FPS_Mode_Update();
    }

    private void Move()
    {
        if (isDashing)
        {
            controller.Move(dashingVelocity * Time.deltaTime);
            return;
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h != 0 || v != 0)
        {
            animator.SetBool("Run", true);

            if (canDash && Input.GetKey(KeyCode.LeftShift))
            {
                StartCoroutine(Dash(h, v));
                return;
            }
        }
        else
        {
            animator.SetBool("Run", false);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        Vector3 normalized_hv = new Vector3(h,0,v).normalized;
        Vector3 motion = transform.right * normalized_hv.x + transform.forward * normalized_hv.z;
        controller.Move(motion * moveSpeed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W)) && isGrounded)
        {
            nextFootstep -= Time.deltaTime;
            if (nextFootstep <= 0)
            {
                audioSource.PlayOneShot(footStepSound, 0.3f);
                nextFootstep += footStepDelay;
            }
        }
    }



    private void FPS_Mode_Update()
    {

        float recoil_h_delta = 0;
        if (recoil_h > 0)
        {
            recoil_h -= Time.deltaTime * recoil_h_force;
            if (recoil_h <= 0)
                recoil_h = 0;
            recoil_h_delta = recoil_right ? Time.deltaTime * recoil_h_force : -Time.deltaTime * recoil_h_force;
        }
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * xTurnSpeed + recoil_h_delta, 0));
        if (transform.position.y < -20)
            transform.position = new Vector3(20, 20, 20);
        

        rox = rox - Time.deltaTime * Input.GetAxis("Mouse Y") * 200 * yTurnSpeed;
        if (recoil_v > 0)
        {
            rox -= Time.deltaTime * recoil_v_force;
            recoil_v -= Time.deltaTime * recoil_v_force;
            if (recoil_v <= 0)
                recoil_v = 0;
        }
        if (rox > 180f)
            rox -= 360f;
        if (rox > 90f)
            rox = 90f;
        if (rox < -90f)
            rox = -90f;

        if(Mathf.Abs(preRox-rox) >= 1f)
        {
            if(pv)
                player_Spine.Send_Rox(rox);
            preRox = rox;
        }
        player_Spine.rox = rox;
    }

    public void SetRecoil(bool _recoil_right, float _recoil_h, float _recoil_v)
    {
        this.recoil_right = _recoil_right;
        this.recoil_h = _recoil_h;
        this.recoil_v = _recoil_v;
    }

    public void SetMoveSpeed(float _speed)
    {
        moveSpeed = _speed;
    }

    IEnumerator Dash(float h, float v)
    {
        canDash = false;
        isDashing = true;
        float originalGravityScale = gravityScale;
        gravityScale = 0;
        Vector3 direction = transform.forward * v + transform.right * h;
        dashingVelocity = direction.normalized * dashingPower;
        dashParticleContainer.localRotation = Quaternion.FromToRotation(Vector3.right, new Vector3(v, 0, -h));
        dashParticle.Play();
        StartCoroutine(Dashing(originalGravityScale));
        yield return dashCooldown.CooldownCoroutine(dashCooldownTime);
        canDash = true;
    }

    IEnumerator Dashing(float originalGravityScale)
    {
        yield return new WaitForSeconds(dashingTime);
        dashingVelocity = Vector3.zero;
        gravityScale = originalGravityScale;
        isDashing = false;
    }

    [PunRPC]
    public void SaveActorNumbers(int index)
    {
        GameManager GM = GameObject.Find("GM").GetComponent<GameManager>();
        GM.target_count++;
        GM.targetsDic.Add(index, transform);
        GM.targets.Add(index);
    }
}

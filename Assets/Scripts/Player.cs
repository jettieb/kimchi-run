using UnityEngine;

public class Player : MonoBehaviour
{
    [Header ("Settings")]
    public float jumpForce; //외부에서 테스트하기 위함.

    [Header ("References")]
    public Rigidbody2D PlayerRigiBody;
    public Animator PlayerAnimator;

    private bool isGrounded = true; //계속 점프하지 못하도록 땅에 있는지 확인용.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            //플레이어를 움직이게 하는 두 가지 방법이 있음.
            //1. X와 Y축의 선형 속도를 높이는 방법.
            //2. Impulse Force를 추가하는 방법.
            PlayerRigiBody.AddForceY(jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            PlayerAnimator.SetInteger("state", 1); 
        }
    }

    //땅에 닿았는지 확인해주는 메소드
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Platform"){
            if(!isGrounded){
                //플레이어어가 달리기 시작하는 순간 땅에 착지할거기 때문에, 게임이 시작되는 순간 state가 2가 될 것.
                PlayerAnimator.SetInteger("state", 2);
            }
            isGrounded = true;
        }
    }
}

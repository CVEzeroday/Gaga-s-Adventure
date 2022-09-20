using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playermove : MonoBehaviour
{
    private float moveSpeed = 2.0f;
    private Rigidbody2D rigid2D;
    private float jumpSpeed = 5.0f;
    public float maxSpeed;

    private enum keyInputEnum { None, Right, Left, Up};
    private keyInputEnum keyInput = None;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        keyInput = keyInputEnum.None;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            keyInput = keyInputEnum.Left;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            keyInput = keyInputEnum.Right;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
            keyInput = keyInputEnum.Up;
    }

    private void FixedUpdate() {
        private float h = 0;
        

        rigid2D.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        
        //Max speed Right
        if (rigid2D.velocity.x > maxSpeed)  //���������� �̵� (+) , �ִ� �ӷ��� ������ 
            rigid2D.velocity = new Vector2(maxSpeed, rigid2D.velocity.y); //�ش� ������Ʈ�� �ӷ��� maxSpeed 

        //Max speed left
        else if (rigid2D.velocity.x < maxSpeed * (-1)) // �������� �̵� (-) 
            rigid2D.velocity = new Vector2(maxSpeed * (-1), rigid2D.velocity.y); //y���� ������ �����̹Ƿ� 0���� ������ �θ� �ȵ� 
}

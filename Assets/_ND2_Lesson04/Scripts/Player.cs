using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        }

        RaycastHit raycast;

        CreateAndShowOfRay(Vector3.zero, transform.position, out raycast, Color.red);

        Vector3 moveVector = transform.position + new Vector3(0, 0, moveSpeed * Time.deltaTime);
        CreateAndShowOfRay(transform.position, moveVector, out raycast,  Color.yellow);
        
        Vector3 downVector = transform.position + new Vector3(0, -2, 0);
        CreateAndShowOfRay(transform.position, downVector, out raycast, Color.blue);

        Vector3 normalVector = raycast.point + raycast.normal;
        CreateAndShowOfRay(raycast.point, normalVector, out raycast, Color.green);
    }

    public void CreateAndShowOfRay(Vector3 start, Vector3 target, out RaycastHit Hit, Color color)
    {
        // ベクトルの差分
        // 差分 = ベクトル2 - ベクトル1;
        Vector3 difference = target - start;

        float distance = Vector3.Distance(start, target);

        // ベクトルの可視化
        Debug.DrawRay(start, difference, color, 0, false);
        //Raycast(開始点,　向き, out 衝突情報);
        Physics.Raycast(start, difference, out Hit, distance, LayerMask.GetMask("Terrain"));
    }
}
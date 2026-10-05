using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent( typeof( PlayerController))]
public class PlayerAttackController: MonoBehaviour
{

    PlayerController m_playerController;

    public GameObject m_bulletPrefab;

    public float m_attackSpeed;

    Vector3 aimPosition;

    public enum m_FireMode
    {
        SemiAuto,
        FullAuto
    }

    public m_FireMode m_fireMode;

    void Start()
    {
        m_playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        PlayerInput();
    }

    void PlayerInput()
    {

        aimPosition.z = 0;


        Vector3 aimDirection = aimPosition.normalized;

        if (aimPosition != Vector3.zero)
        {
            SpawnBullet(aimDirection);
        }
    }

    void SpawnBullet(Vector3 aimDirection)
    {

        GameObject bullet = Instantiate(m_bulletPrefab, transform.position, Quaternion.identity);
        var bC = bullet.GetComponent<BulletController>();
        bC.m_direction = aimDirection;
        bC.m_damage = m_playerController.m_attackDamage;

    }

    public void OnAttack(InputValue value)
    {
        aimPosition = value.Get<Vector2>();
    }
    
}

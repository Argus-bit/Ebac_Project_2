using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour//, IDamageable
{
	public Animator animator;
	public CharacterController characterController;
	public float speed = 1f;
	public float turnSpeed = 1f;
	public float gravity = -9.8f;
	public float jumpSpeed = 15f;

	[Header("Run Setup")]
	public KeyCode keyRun = KeyCode.LeftShift;
	public float speedRun = 40f;

	private float vSpeed = 0f;

	[Header("Flash")]
	public List<FlashColor> flashColors;

	[Header("Life")]
	public HealthBase healthBase;
	private bool _alive = true;

	private void OnValidate()
	{
		if (healthBase == null) healthBase = GetComponent<HealthBase>();
	}
	private void Awake()
	{
		OnValidate();
		healthBase.OnDamage += Damage;
		healthBase.OnKill += OnKill;
	}
	public void Damage(HealthBase h)
	{
		flashColors.ForEach(i => i.Flash());
		EffectsManager.Instance.ChangeVignette();
		ShakeCamera.Instance.Shake();
	}

	private void OnKill(HealthBase h)
	{
		if (_alive)
		{
			_alive = false;
			animator.SetTrigger("Death");
			Invoke(nameof(Revive), 3f);
		}
	}
	public void Damage(float damage, Vector3 dir)
	{}

	void Update()
	{
		transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
		var inputAxisVertical = Input.GetAxis("Vertical");
		var speedVector = transform.forward * inputAxisVertical * speed;

		if (characterController.isGrounded)
		{
			vSpeed = 0;
			if (Input.GetKeyDown(KeyCode.Space))
			{
				vSpeed = jumpSpeed;
			}
		}
		var isWalking = inputAxisVertical != 0;
		if (isWalking)
		{
			if (Input.GetKey(keyRun))
			{
				speedVector *= speedRun;
				animator.speed = speedRun;
			}
			else
			{
				animator.speed = 1;
			}
		}
		vSpeed -= gravity * Time.deltaTime;
		speedVector.y = vSpeed;
		characterController.Move(speedVector * Time.deltaTime);
		animator.SetBool("Run", isWalking);
	}
	[NaughtyAttributes.Button]
	public void Respawn()
    {
		if(CheckpointManager.Instance.HasCkeckpoint())
        {
			transform.position =  CheckpointManager.Instance.GetPositionFromLastCheckpoint();
        }
    }
	private void Revive()
    {
		healthBase.ResetLife();
		animator.SetTrigger("Revive");
		Respawn();
    }
}

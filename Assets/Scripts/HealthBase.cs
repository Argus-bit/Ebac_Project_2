using Cloth;
using System;
using UnityEngine;
using Ebac.StateMachine;
using System.Collections;
using System.Collections.Generic;

public class HealthBase : MonoBehaviour, IDamageable
{
	public float startLife = 10f;
	public bool destroyOnKill = false;
	[SerializeField] 
	private float _currentLife;
	public Action<HealthBase> OnDamage;
	public Action<HealthBase> OnKill;

	public UIGunUpdater uiFillUpdater;

	public float damageMutiply = 1;

	private void Awake()
	{
		Init();
	}
	public void Init()
	{
		ResetLife();
	}
	public void ResetLife()
	{
		_currentLife = startLife;
		UpdateUI();
	}
	protected virtual void Kill()
	{
		if (destroyOnKill)
			Destroy(gameObject, 3f);
			OnKill?.Invoke(this);
	}
	[NaughtyAttributes.Button]
	public void Damage()
	{
		Damage(5);
	}
	public void Damage(float f)
	{
		_currentLife -= f * damageMutiply;   
		if (_currentLife <= 0)
		{
			Kill();
		}
		UpdateUI();
		OnDamage?.Invoke(this);
	}
	public void Damage(float damage, Vector3 dir)
	{
		Damage(damage);
	}
    private void UpdateUI()
    {
        if(uiFillUpdater != null)
        {
			uiFillUpdater.UpdateValue((float)_currentLife / startLife);
        }
    }
	public void ChangeDamageMultiply(float damage, float duration)
	{
		StartCoroutine(ChangeDamageMultiplyCoroutine(damageMutiply, duration));
	}
	IEnumerator ChangeDamageMultiplyCoroutine(float damageMultiply, float duration)
	{
		this.damageMutiply = damageMultiply;
		yield return new WaitForSeconds(duration);
		this.damageMutiply = 1;
	}
}

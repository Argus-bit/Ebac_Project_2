using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{/*
	public ProjectileBase prefabProjectile;
	public Transform positionToShoot;
	public float timeBetweenShoot = .3f;
	private Coroutine _currentCoroutine;
	public KeyCode keycode = KeyCode.Z;

	void Update()
	{
		if (Input.GetKeyDown(keycode))
		{
			_currentCoroutine = StartCoroutine(StartShoot());
		}
		else if (Input.GetKeyDown(keycode))
		{
			if (_currentCoroutine != null) 
				StopCoroutine(_currentCoroutine);
		}
	}
	IEnumerator StartShoot()
	{
		while (true)
		{
			Shoot();
			yield return new WaitForSeconds(timeBetweenShoot);
		}
	}
	public void Shoot()
	{
		var projectile = Instantiate(prefabProjectile);
		projectile.transform.position = positionToShoot.position;
		projectile.transform.rotation = positionToShoot.rotation;
	}*/

	public ProjectileBase prefabProjectile;
	public Transform positionToShoot;
	public float timeBetweenShoot = .2f;
	public float speed = 50f;

	private Coroutine _currentCoroutine;

	protected virtual IEnumerator ShootCoroutine()
	{
		while (true)
		{
			Shoot();
			yield return new WaitForSeconds(timeBetweenShoot);
		}
	}
	public virtual void Shoot()
	{
		var projectile = Instantiate(prefabProjectile);
		projectile.transform.position = positionToShoot.position;
		projectile.transform.rotation = positionToShoot.rotation;
		projectile.speed = speed;
	}
	public void StartShoot()
	{
		StopShoot();
		_currentCoroutine = StartCoroutine(ShootCoroutine());
	}
	public void StopShoot()
	{
		if (_currentCoroutine != null)
		StopCoroutine(_currentCoroutine);
	}
}

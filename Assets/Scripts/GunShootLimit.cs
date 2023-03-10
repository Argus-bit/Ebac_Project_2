using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootLimit : GunBase
{
	public UIGunUpdater uiFillUpdater;
	public float maxShoot = 5f;
	public float timeToRecharge = 1f;

	private float _currentShoots;
	private bool _recharging = false;

	private void Awake()
	{
		GetAllUIs();
	}

	protected override IEnumerator ShootCoroutine()
	{
		if (_recharging) yield break;

		while (true)
		{
			if (_currentShoots < maxShoot)
			{
				Shoot();
				_currentShoots++;
				CheckRecharge();
				UpdateUI();
				yield return new WaitForSeconds(timeBetweenShoot);
			}
		}
	}

	private void CheckRecharge()
	{
		if (_currentShoots >= maxShoot)
		{
			StopShoot();
			StartRecharge();
		}
	}
	private void StartRecharge()
	{
		_recharging = true;
		StartCoroutine(RechargeCoroutine());
	}

	IEnumerator RechargeCoroutine()
	{
		float time = 0;
		while (time < timeToRecharge)
		{
			time += Time.deltaTime;
			Debug.Log("Rechargin: " + time);
			yield return new WaitForEndOfFrame();
		}
		_currentShoots = 0;
		_recharging = false;
	}
	private void UpdateUI()
	{
		uiFillUpdater.UpdateValue(maxShoot, _currentShoots);
	}
	private void GetAllUIs()
	{
		//uiFillUpdater = GameObject.FindObjectsOfType<UIGunUpdater>().ToList();
	}
}

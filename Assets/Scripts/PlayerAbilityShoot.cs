using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
	public GunBase gunBase;
	public GunBase gunOne;
	public GunBase gunTwo;
	public Transform gunPosition;
	public KeyCode gunCodeOne = KeyCode.Alpha1;
	public KeyCode gunCodeTwo = KeyCode.Alpha2;

	private GunBase _currentGun;
    private void Update()
    {
		if (Input.GetKeyDown(gunCodeOne))
		{
			gunBase = gunOne;
		}
		else if (Input.GetKeyDown(gunCodeTwo))
		{
			gunBase = gunTwo;
		}
	}
	protected override void Init()
	{
		base.Init();
		CreateGun();
		inputs.Gameplay.Shoot.performed += cts => StartShoot();
		inputs.Gameplay.Shoot.canceled += cts => CancelShoot();

	}
	private void CreateGun()
    {
		_currentGun = Instantiate(gunBase, gunPosition);
		_currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }
	private void StartShoot()
	{
		gunBase.StartShoot();
		Debug.Log("Start Shoot");
	}
	private void CancelShoot()
	{
		gunBase.StopShoot();
		Debug.Log("Cancel Shoot");
	}
}
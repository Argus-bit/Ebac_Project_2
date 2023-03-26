using UnityEngine;
using EBAC.Core.Singleton;
using System.IO;
using System;
using Cloth;

public class SaveManager : Singleton<SaveManager>
{
	[SerializeField] private SaveSetup _saveSetup;
	private string _path = Application.streamingAssetsPath + "/save.txt";
	public int lastlevel;
	public Action<SaveSetup> FileLoaded;
	private ClothType clothType;

	public SaveSetup Setup
	{
		get { return _saveSetup; }
	}

	protected override void Awake()
	{
		base.Awake();
		DontDestroyOnLoad(gameObject);
	}

	private void CreateNewSave()
    {
		_saveSetup = new SaveSetup();
		_saveSetup.lastlevel = 0;
	}
    private void Start()
    {
		Invoke(nameof(Load), 1f);
	}
    public void SaveItems()
	{
		_saveSetup.coins = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.COIN).soInt.value;
		_saveSetup.health = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.LIFE_PACK).soInt.value;
		_saveSetup.checkpoint = CheckpointManager.Instance.lastCheckPointKey;

		Save();
	}
	public void SaveCloth(ClothSetup setup)
	{
		_saveSetup.cloth = setup;
		Save();
	}

	[NaughtyAttributes.Button]
	public void Save()
	{
		string setupToJson = JsonUtility.ToJson(_saveSetup, true);
		SaveFile(setupToJson);
	}
	private void SaveFile(string json)
	{
		File.WriteAllText(_path, json);
	}
	public void SaveLastLevel(int level)
    {
		_saveSetup.lastlevel = level;
		SaveItems();
		Save();
    }

	[NaughtyAttributes.Button]
	public void Load()
	{
		string fileLoaded = "";
		if (File.Exists(_path))
		{
			fileLoaded = File.ReadAllText(_path);
			_saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoaded);
			lastlevel = _saveSetup.lastlevel;
		}
        else
        {
			CreateNewSave();
			Save();
        }
	}
}

[System.Serializable]
public class SaveSetup
{
	public float coins;
	public float health;
	public int lastlevel;
	public int checkpoint;
	public ClothSetup cloth;
}
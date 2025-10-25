using Godot;
using System;
using System.Collections.Generic;

public enum eSceneNames {
	Main = 10,
	Other = 20
}

public partial class SceneManager : Node
{
	public static SceneManager instance;
	
	public Dictionary<eSceneNames, SceneData> sceneDictionary = new Dictionary<eSceneNames, SceneData>() {
		{eSceneNames.Main, new SceneData("res://Scenes/MainMenuScene/menuScene.tscn", "Main menu")},
		{eSceneNames.Other, new SceneData("res://Scenes/scene/World.tscn", "other")},
	};
	
	public override void _Ready()
	{
		instance = this;
	}

	public void ChangeScene(eSceneNames mySceneName) {
		string myPath = sceneDictionary[mySceneName].path;
		GetTree().ChangeSceneToFile(myPath);
	}
}

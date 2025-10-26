using Godot;
using System;
using System.Collections.Generic;

public partial class SceneManager : Node
{
	public static SceneManager instance;
	
	public override void _Ready()
	{
		instance = this;
	}

	public void ChangeScene(String sceneName) {
		GetTree().ChangeSceneToFile($"res://Scenes/{sceneName}.tscn");
	}
}

using Godot;
using System;

public partial class MainMenu : Node2D
{
	
	public override void _Process(double delta){}
	
	public void _on_button_1_button_up(){
		SceneManager.instance.ChangeScene("Level1");
	}
}

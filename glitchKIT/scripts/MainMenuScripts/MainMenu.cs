using Godot;
using System;

public partial class MainMenu : Node2D
{

  [Export]
  public InputComponent inputComponent;
	
	public override void _Process(double delta){
    if(inputComponent.getStart()) play();
  }
	
	public void _on_button_1_button_up(){ play(); }

  public void play(){
		SceneManager.instance.ChangeScene("Level1");
  }
}

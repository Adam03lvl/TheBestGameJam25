using Godot;
using System;

public partial class InputComponent : Node
{
	public float inputHorizontal = 0.0f;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		inputHorizontal = Input.GetAxis("move_left", "move_right");
	}
	
	public bool getJumpInput()
	{
		return Input.IsActionJustPressed("jump");
	}
}

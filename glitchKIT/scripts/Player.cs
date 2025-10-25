using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[ExportSubgroup("Nodes")]
	[Export]
	public GravityComponent gravityComponent;
	[Export]
	public InputComponent inputComponent;
	[Export]
	public MovementComponent movementComponent;

	public override void _PhysicsProcess(double delta)
	{
		gravityComponent.handleGravity(this, delta);
		movementComponent.handleHorizontalMovement(this, inputComponent.inputHorizontal);
		
		MoveAndSlide();
	}
}

using Godot;

public partial class MovementComponent : Node
{
	[ExportSubgroup("Settings")]
	[Export]
	public float Speed = 100.0f;
	
	public void handleHorizontalMovement(CharacterBody2D body, float direction)
	{
		body.Velocity = new Vector2(direction * Speed, body.Velocity.Y);
	}
}

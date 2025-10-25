using Godot;

public partial class GravityComponent : Node
{
	[ExportSubgroup("Settings")]
	[Export]
  public float Gravity = 980.0f;
	
	public bool IsFalling = false;
	
	public void handleGravity(CharacterBody2D body, double delta)
	{
    body.Velocity = new Vector2(body.Velocity.X, body.Velocity.Y + Gravity * (float)delta);
			
		IsFalling = body.Velocity.Y > 0 && !body.IsOnFloor();
	}
}

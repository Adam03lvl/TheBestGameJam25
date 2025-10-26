using Godot;

public partial class GravityComponent : Node
{
	[ExportSubgroup("Settings")]
	[Export]
  public float Gravity = 980.0f;
	[Export]
  public float MaxSpeed = 340f;
	
	public bool IsFalling = false;
	public bool stopMoving = false;
	
	public void handleGravity(CharacterBody2D body, double delta)
	{
    if(stopMoving) return;
    body.Velocity = new Vector2(
        body.Velocity.X, 
        Mathf.Min(body.Velocity.Y + Gravity * (float)delta, MaxSpeed)
        );

    IsFalling = body.Velocity.Y > 0 && !body.IsOnFloor();
  }
}

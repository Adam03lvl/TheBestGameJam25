using Godot;

public partial class MovementComponent : Node
{
	[ExportSubgroup("Settings")]
	[Export]
	public float Speed = 100.0f;
	[Export]
  public float JumpVelocity = -350f;

  private bool IsJumping = false;
	
	public void handleHorizontalMovement(CharacterBody2D body, float direction)
	{
		body.Velocity = new Vector2(direction * Speed, body.Velocity.Y);
	}

  public void HandleJump(CharacterBody2D body, bool wantToJump){
	if(wantToJump && body.IsOnFloor())
	  body.Velocity = new Vector2(body.Velocity.X, JumpVelocity);

	IsJumping = body.Velocity.Y < 0 && !body.IsOnFloor();
  }
}

using Godot;

public partial class MovementComponent : Node
{
  [ExportSubgroup("Settings")]
  [Export]
  public float JumpSpeed = 340f;
  [Export]
  public float jumpAcceleration = 400f;
  [Export]
  public float deceleration = 0.1f;
  [Export]
  public float speed = 120f;

  public bool IsJumping = false;
  public bool stopMoving = false; 

  public void handleHorizontalMovement(CharacterBody2D body, float direction)
  {
    if(stopMoving) direction = 0;

    if(direction != 0){
      body.Velocity = new Vector2(direction * speed, body.Velocity.Y);
    }else{
      body.Velocity = new Vector2(Mathf.MoveToward(body.Velocity.X, 0, speed * deceleration), body.Velocity.Y);
    }
  }

  public void HandleJump(CharacterBody2D body, bool wantToJump, float gravity){
    if(stopMoving) return;
    if(wantToJump && body.IsOnFloor()){
      body.Velocity -= new Vector2(body.Velocity.X, (float) Mathf.Lerp(JumpSpeed, jumpAcceleration, 0.1));
    }

    if(Input.IsActionJustReleased("jump")){
      body.Velocity = new Vector2(body.Velocity.X, Mathf.Lerp(body.Velocity.Y, gravity, 0.05f));
    }

    IsJumping = body.Velocity.Y < 0 && !body.IsOnFloor();
  }
}

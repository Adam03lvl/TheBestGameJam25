using Godot;

public partial class Player : CharacterBody2D
{
  [ExportSubgroup("Nodes")]
  [Export]
  public GravityComponent gravityComponent;
  [Export]
  public InputComponent inputComponent;
  [Export]
  public MovementComponent movementComponent;
  [Export]
  public AnimationComponent animationComponent;

  public float spawnX = -250; 
  public float spawnY = 50; 
  public float deathY = 175; 
  public bool shouldDie = false;

  float time = 0;

  float timer(double delta, float a){
	return a += 1 * (float) delta;
  }

  public void handleDeath(double delta){
	
	
	if(Position.Y > deathY) shouldDie = true;

	if(shouldDie){
	  Position = new Vector2(Position.X, deathY+50);
	  time = timer(delta,  time);
	  if  (time > 2.0f){
		Position = new Vector2(spawnX, spawnY);
		time = 0;
	  }
	  shouldDie = false;
	}
  }

  public override void _PhysicsProcess(double delta)
  {
	gravityComponent.handleGravity(this, delta);
	movementComponent.handleHorizontalMovement(this, inputComponent.inputHorizontal);
	animationComponent.handleMoveAnimation(inputComponent.inputHorizontal);
	animationComponent.handleJumpAnimation(movementComponent.IsJumping);
	movementComponent.HandleJump(this, inputComponent.getJumpInput(), gravityComponent.Gravity);
	
	if (collision.get_collider().is_in_group("Spikes")) {
		shouldDie = true;
	}
	
	handleDeath(delta);


	MoveAndSlide();
  }

}

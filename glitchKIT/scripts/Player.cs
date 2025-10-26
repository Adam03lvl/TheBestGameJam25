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

  public Area2D key;
  public Area2D spikes;

  public float spawnX = -250;
  public float spawnY = 50;
  public float deathY = 175;
  public bool shouldDie = false;
  public bool isDying= false;
  public bool hasKey = false;

  float time = 0;
  float timer(double delta, float a)
  {
	return a += 1 * (float)delta;
  }

  public override void _Ready()
  {
	key = GetNode<Area2D>("../Key");
	spikes = GetNode<Area2D>("../Spikes");
  }

  public void reset()
  {
	Position = new Vector2(spawnX, spawnY);
	time = 0;
	shouldDie = false;
	hasKey = false;
  }

  public void handleDeath(double delta)
  {

	if (Position.Y > deathY) shouldDie = true;

	if (shouldDie && !isDying)
	{
	  isDying = true;
	  SceneManager.instance.ShowImage("res://assets/death.png", .5f, .2f);
	  Position = new Vector2(Position.X, deathY + 50);
	  GetTree().CreateTimer(.7f).Timeout += ()=> {
		reset();
		isDying = false;
	  };
	}
  }

  public override void _PhysicsProcess(double delta)
  {
	gravityComponent.handleGravity(this, delta);
	movementComponent.handleHorizontalMovement(this, inputComponent.inputHorizontal);
	animationComponent.handleMoveAnimation(inputComponent.inputHorizontal);
	animationComponent.handleJumpAnimation(movementComponent.IsJumping);
	movementComponent.HandleJump(this, inputComponent.getJumpInput(), gravityComponent.Gravity);

	if (spikes.OverlapsBody(this)) shouldDie = true;

	if (!hasKey && key.OverlapsBody(this))
	{
	  movementComponent.stopMoving = true;
	  gravityComponent.stopMoving = true;
	  SceneManager.instance.ShowImage("res://assets/Keycollected.png", .5f, .2f);
	  GetTree().CreateTimer(1.0f).Timeout += ()=> {
	  movementComponent.stopMoving=false;
	  gravityComponent.stopMoving = false;
	};
	  hasKey = true;
	}

	handleDeath(delta);
	MoveAndSlide();
  }

}

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

  public override void _PhysicsProcess(double delta)
  {
	gravityComponent.handleGravity(this, delta);
	movementComponent.handleHorizontalMovement(this, inputComponent.inputHorizontal);
	movementComponent.HandleJump(this, inputComponent.getJumpInput());
	animationComponent.handleMoveAnimation(inputComponent.inputHorizontal);
	animationComponent.handleJumpAnimation(movementComponent.IsJumping);

	MoveAndSlide();
  }
}

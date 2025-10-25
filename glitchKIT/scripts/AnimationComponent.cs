using Godot;

public partial class AnimationComponent : Node
{

 	[ExportSubgroup("Nodes")]
 	[Export]
	public AnimatedSprite2D sprite;

	public void HandleHorizontalFlip(float moveDirection){

		if (moveDirection == 0) return;

		sprite.FlipH = moveDirection > 0 ? false : true;
  	}

  	public void handleMoveAnimation(float moveDirection)
	{
		HandleHorizontalFlip(moveDirection);
	
		if(moveDirection != 0)
	  		sprite.Play("run");
		else
	  		sprite.Play("idle");
  	}

	public void handleJumpAnimation(bool isJumping)
	{
		if (isJumping)
			sprite.Play("jump");
		else
			sprite.Play("fall");
	}
}

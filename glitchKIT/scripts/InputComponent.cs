using Godot;

public partial class InputComponent : Node
{	
	public float inputHorizontal = 0.0f;

	public override void _Process(double delta)
	{
		inputHorizontal = Input.GetAxis("move_left", "move_right");
	}
	
	public bool getMoveInput()
	{
		return (Input.IsActionPressed("move_left") || Input.IsActionPressed("move_right"));
	}

  public bool getRestart(){
		return Input.IsActionJustPressed("restart");
  }
	
	public bool getJumpInput()
	{
		return Input.IsActionJustPressed("jump");
	}

  public bool getToggleInput(){
	return Input.IsActionJustPressed("toggle"); 
  }
  
  public bool getStart(){
    return Input.IsActionJustPressed("start"); 
  }
}

using Godot;

public partial class Level : Node
{
  [ExportSubgroup("Nodes")]
  [Export]
  public ToggleScreenComponent toggleScreenComponent;
	[Export]
	public InputComponent inputComponent;
	[Export]
	public int lvl;
  [Export]
  public Player player;
  [Export]
  public Area2D finish;
  public TileMapLayer real;
  public TileMapLayer fake;

  public bool isFinished = false;
  public bool isReal = true;

	public override void _Ready()
	{
	real = GetNode<TileMapLayer>("Tilemaps/real");
	fake = GetNode<TileMapLayer>("Tilemaps/fake");
  finish = GetNode<Area2D>("Finish");

	real.Enabled = true;
	fake.Visible = false;
	fake.CollisionEnabled = false;
  }

	public override void _Process(double delta)
	{
	handleRestart();
	handleFinish();

	if(inputComponent.getToggleInput()){
	  toggleScreenComponent.toggleScreen(real, fake);
	isReal = !isReal;
  }

  if(isFinished){
	SceneManager.instance.ChangeScene($"Level{lvl+1}");
  }
  }

  public void handleFinish(){
	if(player.hasKey && finish.OverlapsBody(player))
	  isFinished = true;
  }

  public void handleRestart(){
	if(player.shouldDie && !isReal){
	  toggleScreenComponent.toggleScreen(real, fake);
	  isReal = !isReal;
	}
  }
}

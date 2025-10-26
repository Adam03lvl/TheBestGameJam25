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
  public Node2D player;

  public TileMapLayer real;
  public TileMapLayer fake;


  public bool isFinished = false;

	public override void _Ready()
	{
	real = GetNode<TileMapLayer>("Tilemaps/real");
	fake = GetNode<TileMapLayer>("Tilemaps/fake");

	real.Enabled = true;
	fake.Visible = false;
	fake.CollisionEnabled = false;
  }

	public override void _Process(double delta)
	{
	if(inputComponent.getToggleInput()){
	  toggleScreenComponent.toggleScreen(real, fake);
	}
	if(player.Position.X >= 260){
	  SceneManager.instance.ChangeScene($"Level{lvl+1}");
	}
	}
}

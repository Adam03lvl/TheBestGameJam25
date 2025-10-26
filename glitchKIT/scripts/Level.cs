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

  public bool AR = SceneManager.instance.AR;

	public Area2D finish;
	public CollisionShape2D keyCollider;

	public TileMapLayer real;
	public TileMapLayer fake;

  public Area2D realSpikes;
  public Area2D fakeSpikes;

	public bool isFinished = false;
	public bool isReal = true;

  public override void _Ready()
  {

	real = GetNode<TileMapLayer>("Tilemaps/real");
	fake = GetNode<TileMapLayer>("Tilemaps/fake");

	realSpikes = GetNode<Area2D>("RealSpikes");
	fakeSpikes = GetNode<Area2D>("FakeSpikes");

	finish = GetNode<Area2D>("Finish");
	keyCollider = GetNode<CollisionShape2D>("Key/KeyCollider");

	if(AR){
	  real.Enabled = true;
	  fake.Visible = false;
	  fake.CollisionEnabled = false;
	}else{
	  real.Enabled = true;
	  fake.Enabled = false;
	}


	foreach(CollisionShape2D node in fakeSpikes.GetChildren()){
	  node.Disabled = true;
	}

	foreach(CollisionShape2D node in realSpikes.GetChildren()){
	  node.Disabled = false;
	}

	keyCollider.Disabled = true;
  }

	public override void _Process(double delta)
	{
		handleRestart();
		handleFinish();

	if(inputComponent.getRestart()){
	  SceneManager.instance.ChangeScene("Menu");
	}

		if (inputComponent.getToggleInput())
		{
			toggleScreenComponent.toggleScreen(AR, real, fake, realSpikes, fakeSpikes, keyCollider);
			isReal = !isReal;
		}

	if(isReal){
	  if (realSpikes.OverlapsBody(player)) {
	  player.shouldDie = true;
	}
	}else if (fakeSpikes.OverlapsBody(player)){
	  player.shouldDie = true;
	}

		if (isFinished)
		{
			SceneManager.instance.ChangeScene($"Level{lvl + 1}");
			player.reset();
			isFinished = false;
		}
	}

	public void handleFinish()
	{
		if (player.hasKey && finish.OverlapsBody(player))
			isFinished = true;
	}

	public void handleRestart()
	{
		if (player.shouldDie && !isReal)
		{
			toggleScreenComponent.toggleScreen(AR, real, fake, realSpikes, fakeSpikes, keyCollider);
			isReal = !isReal;
		}
	}
}

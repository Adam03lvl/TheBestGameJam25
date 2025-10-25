using Godot;

public partial class ToggleScreenComponent : Node
{

	// private CanvasLayer uiLayer;
	// private bool isScreenVisible = true;
	public override void _Ready()
	{
		// uiLayer = GetNode<CanvasLayer>("UI");
	}

  public void toggleScreen(TileMapLayer real, TileMapLayer fake)
  {
	// isScreenVisible = !isScreenVisible;
	// uiLayer.Visible = isScreenVisible;
	// GD.Print($"Toggled screen! Visible: {isScreenVisible}");

	real.CollisionEnabled = !real.CollisionEnabled;
	fake.CollisionEnabled = !fake.CollisionEnabled;
  }
}

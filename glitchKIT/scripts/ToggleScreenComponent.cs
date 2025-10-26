using Godot;

public partial class ToggleScreenComponent : Node
{
  public void toggleScreen(TileMapLayer real, TileMapLayer fake)
  {

	SceneManager.instance.ToggleShader();
	real.CollisionEnabled = !real.CollisionEnabled;
	fake.CollisionEnabled = !fake.CollisionEnabled;
  // real.Enabled = !real.Enabled;
  // fake.Enabled = !fake.Enabled;
  }
}

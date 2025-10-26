using Godot;

public partial class ToggleScreenComponent : Node
{
  public void toggleScreen(bool ar, TileMapLayer real, TileMapLayer fake, Area2D realS, Area2D fakeS, CollisionShape2D key)
  {
	if(ar){
	  real.CollisionEnabled = !real.CollisionEnabled;
	  fake.CollisionEnabled = !fake.CollisionEnabled;
	}else{
	  real.Enabled = !real.Enabled;
	  fake.Enabled = !fake.Enabled;
	}

	SceneManager.instance.ToggleShader();

	key.Disabled = !key.Disabled;

	foreach(CollisionShape2D node in fakeS.GetChildren()){
	  node.Disabled = !node.Disabled;
	}

	foreach(CollisionShape2D node in realS.GetChildren()){
	  node.Disabled = !node.Disabled;
	}
  }
}

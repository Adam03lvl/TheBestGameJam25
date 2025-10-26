using Godot;
using System;
using System.Collections.Generic;

public partial class SceneManager : Node
{
  public static SceneManager instance;

  private CanvasLayer _uiLayer;
  private TextureRect _keyImage;
  private ColorRect _glitchShader;
  private Tween _currentTween;
  public bool AR = false;

  public override void _Ready()
  {
	instance = this;

	_uiLayer = new CanvasLayer();
	_uiLayer.Layer = 100;
	AddChild(_uiLayer);

	_keyImage = new TextureRect();
	_keyImage.Visible = false;

	_keyImage.SetAnchorsPreset(Control.LayoutPreset.FullRect);

	_keyImage.ExpandMode = TextureRect.ExpandModeEnum.IgnoreSize;
	_keyImage.StretchMode = TextureRect.StretchModeEnum.Scale;

    _glitchShader = new ColorRect();
    _glitchShader.Visible = false;

    _glitchShader.SetAnchorsPreset(Control.LayoutPreset.FullRect);

    var shader = GD.Load<Shader>("res://scripts/shaders/glitch.gdshader");
    if (shader != null)
    {
        var shaderMaterial = new ShaderMaterial();
        shaderMaterial.Shader = shader;
        _glitchShader.Material = shaderMaterial;
    }
    else
    {
        GD.PrintErr("Failed to load shader");
    }

    _uiLayer.AddChild(_keyImage);
    _uiLayer.AddChild(_glitchShader);
  }

  public void ShowImage(string imagePath, float displayTime = 2.0f, float fadeOutTime = 0.5f)
  {
	if (_currentTween != null && _currentTween.IsValid())
	{
	  _currentTween.Kill();
	}
	var texture = GD.Load<Texture2D>(imagePath);
	if (texture == null)
	{
	  GD.PrintErr($"Failed to load image at path: {imagePath}");
	  return;
	}
	_keyImage.Texture = texture;
	_keyImage.Modulate = new Color(1, 1, 1, 1); // Reset alpha to fully opaque
	_keyImage.Visible = true;
	_currentTween = CreateTween();
	_currentTween.TweenInterval(displayTime);
	_currentTween.TweenProperty(_keyImage, "modulate:a", 0.0f, fadeOutTime);
	_currentTween.TweenCallback(Callable.From(() => _keyImage.Visible = false)); 
  }

  public void HideImage(float fadeTime = 0.5f)
  {
	if (_currentTween != null && _currentTween.IsValid())
	{
	  _currentTween.Kill();
	}

	var tween = CreateTween();
	tween.TweenProperty(_keyImage, "modulate:a", 0.0f, fadeTime);
	tween.TweenCallback(Callable.From(() => _keyImage.Visible = false));
  }

  public void ToggleShader(){
    _glitchShader.Visible = !_glitchShader.Visible;
  }

  public void ChangeScene(String sceneName) {
	GetTree().ChangeSceneToFile($"res://Scenes/{sceneName}.tscn");
  }
}

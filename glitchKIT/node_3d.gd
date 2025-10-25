extends Node2D

@export var speed = 400
@export var velocity = 0
# Called when the node enters the scene tree for the first time.
func get_input():
	var input_direction = Input.get_vector("left", "right", "up", "down")
	velocity = input_direction * speed

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float):
	get_input()
	move_and_slide()

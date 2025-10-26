shader_type canvas_item;

uniform sampler2D screen_texture : hint_screen_texture, filter_linear_mipmap;
uniform float time = 0.0;
uniform float intensity : hint_range(0.0, 1.0) = 0.3;

void fragment() {
	vec2 uv = SCREEN_UV;

	vec2 distortion = vec2(
		sin(uv.y * 10.0 + TIME * 2.0) * 0.01,
		cos(uv.x * 10.0 + TIME * 2.0) * 0.01
	);

	vec3 col = texture(screen_texture, uv + distortion * intensity).rgb;

	vec3 tint = vec3(
		0.5 + 0.5 * sin(TIME),
		0.5 + 0.5 * sin(TIME + 2.0),
		0.5 + 0.5 * sin(TIME + 4.0)
	);

	col = mix(col, col * tint, 0.5);

	COLOR = vec4(col, 1.0);
}
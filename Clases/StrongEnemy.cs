using Godot;
using System;

public partial class StrongEnemy : CharacterBody2D
{
	[Export] public float Speed = 70;

	private Vector2 direction;
	private Vector2 screenSize;

	public override void _Ready()
	{
		RandomNumberGenerator rng = new RandomNumberGenerator();
		rng.Randomize();

		
		direction = new Vector2(
			rng.RandfRange(0.2f, 1f),
			rng.RandfRange(-1f, 1f)
		).Normalized();

		screenSize = GetViewportRect().Size;
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = direction * Speed;
		MoveAndSlide();

		if (Position.X < 0 || Position.X > screenSize.X)
			direction.X *= -1;

		if (Position.Y < 0 || Position.Y > screenSize.Y)
			direction.Y *= -1;

		
		if (direction.X < 0)
			direction.X *= -1;
	}
}

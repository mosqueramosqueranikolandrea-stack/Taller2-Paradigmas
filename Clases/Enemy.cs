using Godot;
using System;

public partial class Enemy : Character
{
	public override void _PhysicsProcess(double delta)
	{
		
		Velocity = new Vector2(50, 0);

		MoveAndSlide();
	}
}

using Godot;
using System;

public partial class FastEnemy : Character
{
	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = new Vector2(1, 0);
		MoveCharacter(direction);
	}
}

using Godot;
using System;

public partial class StrongEnemy : Character
{
	public override void _Ready()
	{
		Health = 200;
		Damage = 20;
		Speed = 50;
	}
}

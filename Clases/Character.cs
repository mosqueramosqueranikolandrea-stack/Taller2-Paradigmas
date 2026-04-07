using Godot;
using System;

public partial class Character : CharacterBody2D
{
	[Export] public float Speed = 100;
	[Export] public int Health = 100;
	[Export] public int Damage = 10;

	public override void _PhysicsProcess(double delta)
	{
		MoveAndSlide();
	}

	public void TakeDamage(int amount)
	{
		Health -= amount;
		GD.Print("Vida restante: " + Health);

		if (Health <= 0)
		{
			Die();
		}
	}

	public virtual void Attack(Character target)
	{
		target.TakeDamage(Damage);
	}

	public virtual void Die()
	{
		QueueFree();
	}
}

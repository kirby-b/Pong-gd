using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class ball : CharacterBody2D
{
	public const float Speed = 300.0f;
	public int direction = 1;

	public bool can_bounce = true;

	Timer bounce = null;

    public override void _Ready()
    {
        base._Ready();
		bounce = GetNode<Timer>("../BounceTime");
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.

		velocity.X = direction * Speed;

		if(IsOnWall() && can_bounce){
			direction *= -1;
			bounce.Start();
			can_bounce = false;
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void OnBounceTimeTimeout(){
		can_bounce = true;
	}
}

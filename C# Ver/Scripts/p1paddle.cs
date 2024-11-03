using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class p1paddle : CharacterBody2D
{
	public const float Speed = 350.0f;
    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Player 1 is controlled with W and D (A and D do nothing obviously)
		Vector2 direction = Input.GetVector("ui-a", "ui-d", "ui-w", "ui-s");
		if (direction != Vector2.Zero)
		{
			// Gets the velocity by multiplying the direction(1 or -1) by the speed
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	// Controls what happens when the ball hits the zones or leaves them
	public void OnTopEntered(Node2D body){
		if (body is ball Ball){
			// Sends the ball up
			Ball.SetVertical(1);
		}
	}
	public void OnBottomEntered(Node2D body){
		if (body is ball Ball){
			// Sends the ball down
			Ball.SetVertical(-1);
		}
	}
	public void OnBodyExit(Node2D body){
		if (body is ball Ball){
			// Sends the ball on its normal path
			Ball.SetVertical(0);
		}
	}
}

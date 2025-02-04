using Godot;
using System;

public partial class p2paddle : CharacterBody2D
{
	public const float Speed = 350.0f;
    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		//  Player 2 is controlled with the up and down arrows
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.Y = direction.Y * Speed;
			// Gets the velocity by multiplying the direction(1 or -1) by the speeds
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
			Ball.SetVertical(-1);
		}
	}
	public void OnBottomEntered(Node2D body){
		if (body is ball Ball){
			// Sends the ball down
			Ball.SetVertical(1);
		}
	}
	public void OnBodyExit(Node2D body){
		if (body is ball Ball){
			// Sends the ball on its normal path
			Ball.SetVertical(0);
		}
	}
}

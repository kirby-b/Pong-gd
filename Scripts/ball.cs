using Godot;
using System;
using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;

public partial class ball : CharacterBody2D
{
	public float Horizonal_Speed = 300.0f;

	public float Vertical_Speed = 0.0f;

	public int UpOrDown = 0;

	public int direction = 1;

	public bool can_bounce = true;

	Timer bounce = null;

	Timer spawn_wait = null;

	Vector2 spawn;

    public override void _Ready()
    {
        base._Ready();
		bounce = GetNode<Timer>("../BounceTime");
		spawn_wait = GetNode<Timer>("../SpawnWait");
		spawn = Position;
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.

		velocity.X = direction * Horizonal_Speed;
		velocity.Y = direction * Vertical_Speed;

		if(IsOnWall() && can_bounce){
			direction *= -1;
			Horizonal_Speed *= 1.1f;
			if (UpOrDown == 1){
				Vertical_Speed = -300;
			}
			else if(UpOrDown == -1){
				Vertical_Speed = 300;
			}
			bounce.Start();
			can_bounce = false;
		}
		if((IsOnFloor() || IsOnCeiling()) && can_bounce){
			Vertical_Speed *= -1;
			bounce.Start();
			can_bounce = false;
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void SetVertical(int new_direction){
		UpOrDown = new_direction;
		// Control if they will bounce up(1), down(-1), or continue at current angle(0)
	}

	public void Respawn(){
		Horizonal_Speed = 0.0f;
		Vertical_Speed = 0.0f;
		Position = spawn;
		spawn_wait.Start();
	}

	public void OnBounceTimeTimeout(){
		can_bounce = true;
	}

	public void OnSpawnWaitTimeout(){
		Horizonal_Speed = 300.0f;
		direction *= -1;
	}
}

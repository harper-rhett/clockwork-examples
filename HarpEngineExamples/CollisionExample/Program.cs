using HarpEngine;

EngineSettings settings = new()
{
	WindowName = "Collision Example",
	GameWidth = 128,
	GameHeight = 128
};
Engine.Initialize(settings);
CollisionExample collisionExample = new();
Engine.Start(collisionExample);
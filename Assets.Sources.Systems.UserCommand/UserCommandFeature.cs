namespace Assets.Sources.Systems.UserCommand;

public sealed class UserCommandFeature : Feature
{
	public UserCommandFeature(Contexts contexts)
	{
		Add(new UserCommandInitSystem(contexts)).Add(new KeyboardEventSystem(contexts)).Add(new MouseLockSystem(contexts)).Add(new CreateUserCommandSystem(contexts))
			.Add(new ComputeUserCommandSystem(contexts))
			.Add(new PostProcessUserCommandSystem(contexts))
			.Add(new SendUserCommandSystem(contexts))
			.Add(new LocalKeyDownSystem(contexts));
	}
}

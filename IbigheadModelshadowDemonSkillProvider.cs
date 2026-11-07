public interface IbigheadModelshadowDemonSkillProvider : IModuleProvider
{
	bool isHasSkill(int index);

	bool isShow();

	bool isShowEffect(int index);

	string getEffectUrl(int index);

	bool isShowMask(int index);

	float getMaskProgress(int index);

	bool isShowTime(int index);

	float getTime(int index);
}

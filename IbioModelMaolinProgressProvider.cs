public interface IbioModelMaolinProgressProvider : IModuleProvider
{
	float getPercent();

	bool isShow();

	bool isLightShow();

	float getLightEffectAlpha();
}

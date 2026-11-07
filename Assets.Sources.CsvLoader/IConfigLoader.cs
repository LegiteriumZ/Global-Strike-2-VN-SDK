using System.Collections;

namespace Assets.Sources.CsvLoader;

public interface IConfigLoader
{
	IEnumerator Load();
}

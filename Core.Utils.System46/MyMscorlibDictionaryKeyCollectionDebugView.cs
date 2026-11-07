using System.Collections.Generic;
using System.Diagnostics;

namespace Core.Utils.System46;

internal sealed class MyMscorlibDictionaryKeyCollectionDebugView<TKey, TValue>
{
	private ICollection<TKey> _collection;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public TKey[] Items
	{
		get
		{
			TKey[] array = new TKey[_collection.Count];
			_collection.CopyTo(array, 0);
			return array;
		}
	}

	public MyMscorlibDictionaryKeyCollectionDebugView(ICollection<TKey> collection)
	{
		if (collection == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
		}
		_collection = collection;
	}
}

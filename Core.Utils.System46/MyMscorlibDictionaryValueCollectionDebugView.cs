using System.Collections.Generic;
using System.Diagnostics;

namespace Core.Utils.System46;

internal sealed class MyMscorlibDictionaryValueCollectionDebugView<TKey, TValue>
{
	private ICollection<TValue> _collection;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public TValue[] Items
	{
		get
		{
			TValue[] array = new TValue[_collection.Count];
			_collection.CopyTo(array, 0);
			return array;
		}
	}

	public MyMscorlibDictionaryValueCollectionDebugView(ICollection<TValue> collection)
	{
		if (collection == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
		}
		_collection = collection;
	}
}

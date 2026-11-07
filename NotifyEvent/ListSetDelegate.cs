namespace NotifyEvent;

public delegate void ListSetDelegate<T, TF>(T val, int idx, TF oldfs, TF newfs, ElementStatus status);

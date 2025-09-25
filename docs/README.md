# CodeEvents Documentation

This is a lightweight, fast event system designed for decoupled communication between components. It is inspired by the UnityEvent system but is standalone and dependency-free.

## Usage

Define static events in a central hub:
```csharp
public static class MyEvents
{
    public static readonly EventSystem OnSomethingHappened = new();
    public static readonly EventSystem<int> OnDataChanged = new();
}
```

Publish events:
```csharp
MyEvents.OnSomethingHappened.Invoke();
MyEvents.OnDataChanged.Invoke(42);
```

Subscribe to events:
```csharp
MyEvents.OnSomethingHappened.AddListener(MyHandler);
MyEvents.OnDataChanged.AddListener(MyDataHandler);
```

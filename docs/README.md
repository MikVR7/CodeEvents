# CodeEvents Documentation

## Overview

CodeEvents is a simple, lightweight, and thread-safe event system for C#. It allows for decoupled communication between different parts of an application.

## Features

- **EventSystem**: Synchronous event handling.
- **EventSystemAsync**: Asynchronous event handling.
- Support for events with zero to five parameters.
- Easy to integrate and use.

## Usage

### Defining an Event

```csharp
public static class MyEvents
{
    public static readonly EventSystem<string> OnSomethingHappened = new();
}
```

### Subscribing to an Event

```csharp
MyEvents.OnSomethingHappened.AddListener(HandleSomethingHappened);

private void HandleSomethingHappened(string message)
{
    Console.WriteLine($"Event received: {message}");
}
```

### Publishing an Event

```csharp
MyEvents.OnSomethingHappened.Invoke("Hello, World!");
```



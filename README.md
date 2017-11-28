#Sharpy

C# custom event handling library, useful for creating various hooks, creating modular/plugin systems, etc.

----
## Usage

Create instance, all your events and handlers will be stored there

```c#
var events = new Sharpy.EventManager();
```

Now you can add some handlers
> Note: First parameter is your event name, and second is the callback

```c#
events.On("MyEvent", (e) => {
    // MyHandler
});
```

After some time, and some calculations you can trigger your event
> Note: There may be multiple event handlers on single event

```c#
events.Trigger("MyEvent");
```

## Examples
>Note: Full examples can be found in "examples" folder

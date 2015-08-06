using System;

namespace SharpyExamples {

    public class Example2 {

        public static void Main(string[] args) {
            
            // Create event manager
            var events = new Sharpy.EventManager();


            // Register callback on event: "myEvent"
            // If you want to pass data, define your event class (see example event)
            events.On("myEvent", (e) => {
                // Cast event argrument to your event object
                var obj = (MyEvent) e;

                // Get (set) your event object data
                if (obj.x == 42) {
                    obj.title = "This is the right answer!";
                }

                // Other code
            });


            // Somewhere in code, trigger your event
            // Create and pass event
            events.Trigger("myEvent", new MyEvent(42));
        }
    }

    public class MyEvent : Sharpy.IEvent {

        public int x;
        public string title;

        public MyEvent(int x) {
            this.x = x;
            this.title = "Unknown answer :(";
        }
    }
}
using System;

namespace SharpyExamples {

    public class Example1 {

        public static void Main(string[] args) {
            
            // Create event manager
            var events = new Sharpy.EventManager();


            // Register callback on event: "myEvent"
            events.On("myEvent", (e) => {
                // Your code here
            });


            // Somewhere in code, trigger your event
            events.Trigger("myEvent");
        }
    }
}
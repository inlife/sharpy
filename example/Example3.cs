using System;

namespace SharpyExamples {

    // Or you can event extend EventManager, to add all these abilieties to your own object
    public class MyPlayer : Sharpy.EventManager {

        public MyPlayer() : base() {
            this.x = 0;
            this.y = 0;
        }

        // Add trigger ev
        public void Move(int x, int y) {
            this.x = x;
            this.y = y;

            this.Trigger("Move", new PlayerEvent(this));
        }

    }

    // Then add custom event
    public class PlayerEvent : Sharpy.IEvent {

        public MyPlayer player;

        public PlayerEvent(MyPlayer player) {
            this.player = player;
        }
    }

    public class Example3 {

        public static void Main(string[] args) {
            
            // Create event manager
            var player = new MyPlayer();


            // Register callback on event: "Move"
            // If you want to pass data, define your event class (see example event)
            player.On("Move", (e) => {
                // Cast event argrument to your event object
                var obj = (PlayerEvent) e;

                // Get (set) your event object data
                if (obj.x == 42 && obj.y == 42) {
                    // Player is in the perfect spot :)
                }

                // Other code
            });

        }
    }
}
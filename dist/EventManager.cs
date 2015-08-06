using System;
using System.Collections.Generic;

/**
 * Event System
 * Gives ability to subscribe on events, and to trigger them later
 * All user defined events must impletement IEvent interface 
 * 
 * @namespace Sharpy
 * @author Vladislav Gritsenko (Inlife)
 * @year 2015
 * @licence MIT
 */
namespace Sharpy {

    /**
     * Event Manager
     * You can subscribe to events and trigger them
     * @depends System.Action, System.Collections.Generic.Dictionary
     */
    public class EventManager {

        /**
         * Stores all information about event and handlers
         * @property
         */
        private Dictionary<string, List<Action<IEvent>>> __register;

        /**
         * Creates Manager entity
         * @constructor
         */
        public EventManager() {
            this.__register = new Dictionary<string, List<Action<IEvent>>>();
        }

        /**
         * Regiser an event handlers, that will be listening events by "name"
         * 
         * @param {string} name - Name of event to register
         * @param {Action<Event>} callback - Callback anonymous function 
         * @return {void}
         */
        public void On(string name, Action<IEvent> callback) {
            if (!this.__register.ContainsKey(name)) {
                this.__register[name] = new List<Action<IEvent>>();
            }
            this.__register[name].Add(callback);
        }
        
        /**
         * Triggers the event, by it's name, default event object will be passed to callback
         * 
         * @param {string} name - Name of event to trigger
         * @return {void}
         */
        public void Trigger(string name) {
            this.Trigger(name, new DefaultEvent());
        }

        /**
         * Triggers the event by it's name, "data" event object will be passed to callback
         * 
         * @param {string} name - Name of event to trigger
         * @param {Event} e - Event that will be passed to handler
         * @return {void}
         */
        public void Trigger(string name, IEvent data) {
            if (this.__register.ContainsKey(name)) {
                foreach (Action<IEvent> callback in this.__register[name]) {
                    callback(data);
                }
            }
        }

    }

}
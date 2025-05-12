# What Is Event Sourcing
As far as I understand `Event Sourcing` is a design pattern that helps store state of the application's data as a sequence of the changes that happened. These changes are called events.

This means instead of updating a column/JSON property we create events for changes like: addition, modification, and deletion. 

These **events are immutable** this means: an event can never be modified after it is created but rather another event needs to be created to reverse the state. If I modify data such that the state changes I will need to create another modify event to revert to the previous state.

The aggregation of events means current state. That is `function([event1,...,event]) => current_state_of_data`. So if I can list all the events I should be able to make up the current state.

This means I can travel back in history and see the full aduit of how the data changed for an entity in my application's lifetime.

### Some Concepts.

- `Event` - An action at a given time that caused state to change.
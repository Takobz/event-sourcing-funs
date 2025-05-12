# What The POC Does.

## Use cases:
Just some stupid cases for an excuse to have some event sourcing brewing

- User can create cart
- User can add, modify and remove items in the cart
- User should be able to see all actions (deletes, addition, etc) that happened in the cart.

## Events
The events I will be interested in for this POC.

- CreateUserEvent - for init creation of the user.
- CreateCartEvent - for init creation of the cart.
- AddItemEvent - for adding item to cart.
- ModifyItemEvent - for modifying an item in the cart.
- DeleteItemEvent - for removing an item in the cart.
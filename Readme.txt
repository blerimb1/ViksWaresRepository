Hello and welcome to Viks Wares, a small shop selling some of the fines goods in town.
Unfortunately the goods we stock are constantly degrading in value as they approach the sell by date.
The shop has a system in place that automatically updates the inventory daily. 
We need your help to add more functionality to the system and get it to a better state.

Before we start, here's how the system works:
- All items have a SellBy which indicates the number of days by which the item has to be sold
- All items have a Value which indicates how valuable the item is
- At the end of each day the system lowers both SellBy and Value for all items

That's the simple part, now let's get to the finer details:
- Once the SellBy date has passed, the Value degrades twice as fast
- The value of an item can never be negative
- "Aged Parmigiano" actually increases in Value the older it gets
- The value of an item is never more than 50
- "Saffron Powder", being a rare item, never has to be sold or decrease in Value
- "Concert Tickets" increase in Value as it's SellBy approaches;
Value increases by 2 when there are 10 days or less, by 3 when there are 5 days or less, but falls to 0 after the concert

For Clarification: An item cannot have it's Value increased above 50 or below 0, however "Saffron Powder" has a Value of 80 and is never altered.


Recently we signed a contract to get refrigerated items, this requires an update to the system:
- "Refrigerated" items degrade in Value twice as fast as normal items

From the last release we noticed that any changes can break the system, with this in mind We also need a way to ensure that the system is working correctly.

Feel free to make any changes to the UpdateValue method and add any new code as long as everything still works. However, make sure to not edit the 
Item class or Items property as these are shared by other shops and we don't want any lawsuits.


Summary
- Refactor Code
- Add functionality for refrigerated items
- Add Unit Tests
- Do not modify Item.cs
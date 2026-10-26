“Alright Lucas, next one. Let’s design a vending machine.

The machine holds different products, each with a price and a quantity. A customer selects a product, inserts money, and gets the product and any change back. They can also cancel and get their money refunded.

Take a moment, and ask me anything you need before you start.”

## Questions
1. Can a customer select more than one product at once?
    “One product per transaction. If they want another, they start a new one.”
1. What is the machine behavior when the customer select a product that is empty?
    “The machine should tell them it’s sold out and let them pick something else. No money should be taken.”
1. What to do when the money is less than product price?
    “They can keep inserting money until it’s enough, or cancel and get a full refund.”
1. The machine accepts coins, money paper? What to do when the machine does not have the change?
    “Coins only — 10c, 20c, 50c, €1 and €2. If the machine can’t give exact change, it should refuse the purchase and refund the money.”
1. The customer select the product first or insert the money first?
    “The customer selects the product first, then inserts money. They can’t insert money before selecting.”
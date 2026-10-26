“Alright Lucas, let’s do something a bit different. I’d like you to design and implement an LRU cache — least recently used.

It has a fixed capacity, set when it’s created. It should support two operations: Get(key) and Put(key, value). When the cache is full and a new item is added, it should remove the item that was used least recently.

Take a moment, and ask me anything before you start.”

## Question
1. What is the capacity? items count, mb..?
    “Item count. Let’s say the capacity is passed in the constructor, like 3 or 100.”
1. What is value? can be a object or other type?
    “Any type. Make it generic if you can.”
1. What means used least recently? The last inserted or the last get?
    “Both count as a use. Inserting or updating an item makes it the most recently used, and so does reading it with Get.”
1. The key is a string?
    “Keys can be any type too — generic is fine.”




“Great, let’s do one more. I’d like you to design a rate limiter.

Imagine we have an API, and we want to limit how many requests each client can make. For example, a client can make at most 10 requests per minute. If they go over the limit, the request should be rejected.

The main method would be something like bool AllowRequest(string clientId).

Take a moment, and ask me anything before you start.”

## Questions
1. How do I retrieve the clientId? 
1. The reject is a 409?
1. What happens in case our service restart, it restart the limit?

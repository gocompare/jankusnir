# Coding Challenge

This challenge is designed to showcase your capability to develop high-quality, production-ready code. Spend the necessary amount of time you feel is needed to demonstrate your standard for quality code.

Should you encounter any difficulties in submitting your solution within a 7-day timeframe from receiving this challenge, please communicate this to us as soon as possible.

## Problem Description

Your task involves creating a supermarket checkout API that calculates the total price of a basket of items. Items are identified by Stock Keeping Units (SKUs), denoted by the letters A, B, C, and D, and have both individual prices and potential multi-buy offers.

### Price and Offer Table:

```
| Item | Price | Offer      |
|------|-------|------------|
| A    | 50    | 3 for 130  |
| B    | 30    | 2 for 45   |
| C    | 20    | No offer   |
| D    | 15    | No offer   |
```

Items can be scanned in any order, with discounts applied accordingly.

Currently, our system only accommodates one type of offer — multi-buy discounts. However, we anticipate introducing a variety of offer types in the future, details of which are yet to be confirmed. **We encourage you to design your solution with flexibility in mind, allowing for easy integration of new offer types as they become available.**

## Implementation Guidance

Develop a RESTful API that features at least one POST method, capable of receiving a string of SKU letters and returning the total price. While additional materials to aid in understanding or testing your API are welcome, they are not required.

## Example Unit Tests

For testing purposes, consider the following scenarios:

```
- Assert.That(0, Is.EqualTo(price_of("")))
- Assert.That(50, Is.EqualTo(price_of("A")))
- Assert.That(80, Is.EqualTo(price_of("AB")))
- Assert.That(115, Is.EqualTo(price_of("CDBA")))
- Assert.That(100, Is.EqualTo(price_of("AA")))
- Assert.That(130, Is.EqualTo(price_of("AAA")))
- Assert.That(175, Is.EqualTo(price_of("AAABB")))
```

## Submission Guidelines

Upon completion of your code:
1. Ensure all changes are committed and pushed to the `work` branch.
2. Inform us of your submission by emailing petr.kunc@futurenet.com, hywel.rees@futurenet.com, and chris.farmer@futurenet.com.

We eagerly await to review your innovative solutions and discuss your thought process regarding the integration of potential future offer types.

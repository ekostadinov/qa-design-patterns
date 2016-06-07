---
layout: pattern
title: Lazy Initialization
categories: Other
---

## Intent
Lazy loading is a design pattern commonly used to defer
initialization of an object until the point at which it is needed. It can
contribute to efficiency in the program's operation if properly and
appropriately used.

## Applicability
Use the Lazy Loading idiom when

* eager loading is expensive or the object to be loaded might not be needed at all

## Real world examples

* JPA annotations @OneToOne, @OneToMany, @ManyToOne, @ManyToMany and fetch = FetchType.LAZY

## Credits

* [J2EE Design Patterns](http://www.amazon.com/J2EE-Design-Patterns-William-Crawford/dp/0596004273/ref=sr_1_2)

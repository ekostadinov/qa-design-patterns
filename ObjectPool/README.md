---
layout: pattern
title: Object Pool
categories: Creational
---

## Intent
When objects are expensive to create and they are needed only for
short periods of time it is advantageous to utilize the Object Pool pattern.
The Object Pool provides a cache for instantiated objects tracking which ones
are in use and which are available.

## Applicability
Use the Object Pool pattern when

* the objects are expensive to create (allocation cost)
* you need a large number of short-lived objects (memory fragmentation)

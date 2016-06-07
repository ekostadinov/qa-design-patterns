---
layout: pattern
title: PageLoader
categories: Behavioral
---

## Intent
Encapsilate navigation logic over site's pages via Bidirected and Cyclic graph.

## Applicability
Use the PageLoader pattern in any of the following situations

* when you can represent Web site as graph containing pages
* each Vertex (single node in the graph) encapsulate some sort of information
* Edges connect one or more vertices

## Typical Use Case

* chaining Page objects and traverse them based on some algorithm

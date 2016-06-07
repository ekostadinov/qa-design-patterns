---
layout: pattern
title: Resource Acquisition Is Initialization
categories: Structural
---

## Also known as
Constructor Acquires, Destructor Releases (CADRe) 

## Intent
Hold a resource is a class invariant, and is tied to object lifetime: resource allocation (acquisition) 
is done during object creation (specifically initialization), by the constructor, while resource deallocation (release)
is done during object destruction (specifically finalization), by the destructor. 
Thus the resource is guaranteed to be held between when initialization finishes and 
finalization starts (holding the resources is a class invariant), and to be held only when the object is alive.
Thus if there are no object leaks, there are no resource leaks.

## Applicability
Use the RAII pattern when

* for controlling mutex locks in multi-threaded applications
* interacting with files

## Credits

* [Resource Acquisition Is Initialization](https://en.wikipedia.org/wiki/Resource_Acquisition_Is_Initialization)

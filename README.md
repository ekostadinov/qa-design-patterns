# Design patterns QA - PoC 

# Implemented in CSharp

Design patterns are formalized best practices that the programmers can use to
solve common problems when designing an application or system. They can speed up the development process by providing tested, proven development paradigms.

Reusing design patterns helps to prevent subtle issues that can cause major
problems, and it also improves code readability for coders and architects who
are familiar with the patterns.

# Getting started

Before you dive into the material, you should be familiar with various
[Programming/Software Design Principles](http://webpro.github.io/programming-principles/).

All designs should be as simple as possible. You should start with KISS, YAGNI,
and Do The Simplest Thing That Could Possibly Work principles. Complexity and
patterns should only be introduced when they are needed for practical
extensibility.

NOTE: Every real data, configurations and resources used for demos has been obfuscated.

#  Content

 - Blackboard 

Building a software system for WebElements' image recognition. Input is screenshot recorded as image and output is accessible WebElement.

 - ChainOfResponsibility 

Using this pattern we encapsulates the test steps inside a "pipeline" abstraction and have scripts "launch and leave" their requests at the entrance of the pipeline.

 - Composite 

Helps us to create Page Objects by forming a tree structure and ask each node in the tree structure to perform a task (loading, verifing itself). 

 - Flyweight 

 - Interpreter 

Can be used as rules engine to support business logic in tests or on creation of their fixtures.

 - LazyInitialization 

Provides delayed execution of certain tasks. Good example is a Shared fixture scenario or DB sandboxing.

 - Mediator 

Since it encapsulates how a set of objects interact, we can use it to share test execution data and analysis between Reporting systems.

 - Module 

Extensibility modules let us consolidate our plug-ins into a centralized place. Good fit for this case are the different  Reporting systems we use.

 - Multiton 

Helps us to manage a map of named instances as key-value pairs. Also simplifies retrieval of shared objects (fixtures). 

 - ObjectPool 

Uses a set of initialized objects kept ready to use, rather than allocating and destroying them on demand. Such expensive objects could be our test fixtures which we would like to re-use, but only one at a time between multiple parallel tests.

 - Observer 

Since it define a one-to-many dependency between objects so that when one (test) object changes state, all its dependents are notified and updated automatically. Good fit are the Reporting systems that needs to be notified of test's status. 

 - PageLoader 

Encapsilates navigation logic over site's pages via Bidirected and  Cyclic graph.

 - RAII  

By holding a resource tied to object lifetime, we can destroy all of them at the end. Good examples are Transaction roll-back and DB cleaning.

 - Servant  

Shared code for a group of classes, that appears in only one class without defining that functionality in each of them. Typical example is REST RequestSender that takes care of the multiple Contracts between the APIs.

 - State

Allow an object (fixtures) to alter its behavior when its internal state changes, so our tests could make use of it.

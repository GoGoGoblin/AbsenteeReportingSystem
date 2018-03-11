# AbsenteeReportingSystem
Sample C# Program

Revised my school assignment based on a Dependency Inversion Principle (DIP) which states “entities must depend on abstractions not on concretions.”

The program accesses to the database and obtains today's absentee information to create an absentee report.

In order to eliminate dependency, an interface "IStorageAgent" was created.
Both the high level class (ClsReport.cs) and the low level class (ClsStorageAgent.cs) depend on the abstraction provided by this interface.
When a storage system is replaced, only ClsStorageAgent.cs needs to be modified.


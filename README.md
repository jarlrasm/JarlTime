JarlTime
========
A simple .NET library for time.

Ideas
-----
* Separation of logic and presentation: Time struct ignores all information about timezones and calendars.
* Testability: Inject context to your classes for different meanings of Now
* Immutability
* Simplicity?

Examples
--------
If you like to inject code:
```csharp
ITimeContext timeContext = new TimeContext();
Time time = timeContext.Now();
Gregorian gregorian=time.Projection<Gregorian>(timeContext.Here());
int year=gregorian.Year;
```

If you are lazy
```csharp
Time time = Rigth.Now;
Gregorian gregorian=time.Projection<Gregorian>(Rigth.Here)
...
```

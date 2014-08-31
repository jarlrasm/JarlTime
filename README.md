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
time=10.Days().And(10.Hours()).From(time);
Gregorian gregorian=time.Projection<Gregorian>(timeContext.Here());
int hour=gregorian.Hour;
string datestring=gregorian.ToString("yyyy MM dd");
```

If you are lazy
```csharp
Time time = Rigth.Now;
Gregorian gregorian=time.Projection<Gregorian>(Rigth.Here)
...
```

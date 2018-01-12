# log4net adapter for Unity container
Unity extension to integrate with popular [log4net](https://github.com/apache/logging-log4net) logger.

## Getting Started
- Reference the `Unity.log4net ` package from NuGet.
```
Install-Package Unity.log4net 
```

## Registration:
- Add `Log4NetExtension` extension to the container

```C#
container = new UnityContainer();
container.AddNewExtension<Log4NetExtension>();
```
- Where required add `ILog` interface to resolved constructor. 

```C#
public class LoggedType
{
    public LoggedType(ILog log)
    {
    }
  ...
}
```
- Log normally...

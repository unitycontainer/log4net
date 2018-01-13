[![Build status](https://ci.appveyor.com/api/projects/status/3x9gf21l6qqxo9rn/branch/master?svg=true)](https://ci.appveyor.com/project/IoC-Unity/log4net/branch/master)
[![License](https://img.shields.io/badge/license-apache%202.0-60C060.svg)](https://github.com/IoC-Unity/log4net/blob/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/dt/Unity.log4net.svg)](https://www.nuget.org/packages/Unity.log4net)
[![NuGet](https://img.shields.io/nuget/v/Unity.log4net.svg)](https://www.nuget.org/packages/Unity.log4net)


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

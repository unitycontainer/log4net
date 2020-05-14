[![Build status](https://ci.appveyor.com/api/projects/status/3x9gf21l6qqxo9rn/branch/v5.x?svg=true)](https://ci.appveyor.com/project/IoC-Unity/log4net/branch/v5.x)
[![License](https://img.shields.io/badge/license-apache%202.0-60C060.svg)](https://github.com/IoC-Unity/log4net/blob/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/dt/Unity.log4net.svg)](https://www.nuget.org/packages/Unity.log4net)
[![NuGet](https://img.shields.io/nuget/v/Unity.log4net.svg)](https://www.nuget.org/packages/Unity.log4net)

# log4net adapter for Unity container

Unity extension to integrate with popular [log4net](https://github.com/apache/logging-log4net) logger.

## Getting Started

- Reference the `Unity.log4net` package from NuGet.

```shell
Install-Package Unity.log4net
```

## Registration

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

## Code of Conduct

This project has adopted the code of conduct defined by the [Contributor Covenant](https://www.contributor-covenant.org/) to clarify expected behavior in our community. For more information, see the [.NET Foundation Code of Conduct](https://www.dotnetfoundation.org/code-of-conduct)

## Contributing

See the [Contributing guide](https://github.com/unitycontainer/unity/blob/master/CONTRIBUTING.md) for more information.

## .NET Foundation

Unity Container is a [.NET Foundation](https://dotnetfoundation.org/projects/unitycontainer) project

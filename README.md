
# .NET Core

## .NET Core Command

[.NET Core CLI 命令](https://docs.microsoft.com/zh-cn/dotnet/core/tools/index?tabs=netcore2x) 形式为
```bash
dotnet [runtime-options] [path-to-application]
```
基本命令 [runtime-options]

| 命令 | 说明 | 操作 |
| :------| :------ |:------|
| new | 初始化 .NET 项目,根据指定的模板，创建新的项目、配置文件或解决方案。 |  [选项](#dotnetnew)  |
| restore |还原 .NET 项目中指定的依赖项| |
| run |编译并立即执行 .NET 项目| |
| build | 生成 .NET 项目。 | |
| publish | 发布 .NET 项目以进行部署(包括运行时)。| |
| test |使用项目中指定的测试运行程序运行单元测试。| |
| pack |创建 NuGet 包。| |
| migrate | 将基于 project.json 的项目迁移到基于 MSBuild 的项目。| |
| clean |清除生成输出。| |
| sln | 修改解决方案(SLN)文件。| |
| add | 将引用添加到项目中。| |
| remove |从项目中删除引用。| |
| list | 列出项目参考或安装的工具。| |
| nuget |提供其他 NuGet 命令。| |
| vstest | 运行 Microsoft 测试执行命令行工具。| |
| store | 在运行时存储中存储指定的程序集。| |
| tool | 安装或使用扩展 .NET 体验的工具。| |
| build-server |与由生成版本启动的服务器进行交互。| |
| help | 显示帮助。| |

 
<span id="dotnetnew">dotnet new <span>  

根据指定的模板，创建新的项目、配置文件或解决方案。查看帮助命令为 `dotnet new -h`
```base
dotnet new <TEMPLATE> [--force] [-i|--install] [-lang|--language] [-n|--name] [--nuget-source] [-o|--output] [-u|--uninstall] [Template options]
```

自变量
----
| 模板 | 短名称 | 语言 |标记|
| :------| :------ |:------|:------|                                                                   
|Console Application|console|[C#], F#, VB|Common/Console                   
|Class library|classlib|[C#], F#, VB|Common/Library                   
|Unit Test Project|mstest|[C#], F#, VB|Test/MSTest                      
|xUnit Test Project|xunit|[C#], F#, VB|Test/xUnit                       
|Razor Page|page|[C#]| Web/ASP.NET                      
|MVC ViewImports|viewimports|[C#]|Web/ASP.NET                      
|MVC ViewStart|viewstart|[C#]|Web/ASP.NET                      
|ASP.NET Core Empty|web|[C#], F#|Web/Empty                        
|ASP.NET Core Web App (Model-View-Controller)|mvc|[C#], F#|Web/MVC                          
|ASP.NET Core Web App|razor|[C#]|Web/MVC/Razor Pages              
|ASP.NET Core with Angular|angular|[C#]|Web/MVC/SPA                      
|ASP.NET Core with React.js|react|[C#]|Web/MVC/SPA                      
|ASP.NET Core with React.js and Redux| reactredux|[C#]|Web/MVC/SPA                      
|Razor Class Library|razorclasslib|[C#]|Web/Razor/Library/Razor Class Library
|ASP.NET Core Web API|webapi|[C#], F#| Web/WebAPI                       
|global.json file|globaljson|Config |                          
|NuGet Config|nugetconfig| Config |                          
|Web Config|webconfig|Config   |                        
|Solution File|sln|Solution  |    
例如创建一个名为 myApp 的 Console 项目
```base
dotnet new console -o myApp
```

<span id="dotnetpublish">dotnet publish <span> 

 将应用程序及其依赖项打包到文件夹以部署到托管系统,.NET Core 提供了两种两种部署方式

 * 依赖框架的部署
    
    此方式需要在目标计算机上必须安装 [.NET Core 运行时环境 ](https://www.microsoft.com/net/download/thank-you/dotnet-runtime-2.1.2-windows-hosting-bundle-installer),也可安装 .NET Core SDK,优点在于部署文件相对独立部署要小。

 * 独立部署

    此方式在发布时需指定运行平台版本,打包时会将将 SDK 和 运行时同时打包在项目中,相对部署文件也会很大。
```base
dotnet publish [<PROJECT>] [-c|--configuration] [-f|--framework] [--force] [--manifest] [--no-build] [--no-dependencies]
    [--no-restore] [-o|--output] [-r|--runtime] [--self-contained] [-v|--verbosity] [--version-suffix]
dotnet publish [-h|--help]
```

**常见的RID**

*Windows RID 可移植*

`win-x86`、`win-x64`

*Windows 7 / Windows Server 2008 R2*

`win7-x64`、`win7-x86`

*Windows 8 / Windows Server 2012*

`win8-x64`、`win8-x86`、`win8-arm`

*Windows 8.1 / Windows Server 2012 R2*

`win81-x64`、`win81-x86`、`win81-arm`

*Windows 10 / Windows Server 2016*

`win10-x64`、`win10-x86`、`win10-arm`、`win10-arm64`

**Linux RID**
*可移植*

`linux-x64`

*CentOS*

`centos-x64`、`centos.7-x64`

*Debian*
`debian-x64`、`debian.8-x64`

*Fedora*

`fedora-x64`、`fedora.24-x64`、`fedora.25-x64`（.NET Core 2.0 或更高版本）、`fedora.26-x64`（.NET Core 2.0 或更高版本）

*Gentoo（.NET Core 2.0 或更高版本）*

`gentoo-x64`

*openSUSE*

`opensuse-x64`、`opensuse.42.1-x64`

*Oracle Linux*

`ol-x64`、`ol.7-x64`、`ol.7.0-x64`、`ol.7.1-x64`、`ol.7.2-x64`

*Red Hat Enterprise Linux*

`rhel-x64`、`rhel.6-x64`（.NET Core 2.0 或更高版本）、`rhel.7-x64`、`rhel.7.1-x64`、`rhel.7.2-x64`、`rhel.7.3-x64`（.NET Core 2.0 或更高版本）、`rhel.7.4-x64`（.NET Core 2.0 或更高版本）

*Tizen（.NET Core 2.0 或更高版本）*

`tizen`

*Ubuntu*

`ubuntu-x64`、`ubuntu.14.04-x64`、`ubuntu.14.10-x64`、`ubuntu.15.04-x64`、`ubuntu.15.10-x64`、`ubuntu.16.04-x64`
、`ubuntu.16.10-x64`

*Ubuntu 衍生内容*

`linuxmint.17-x64`、`linuxmint.17.1-x64`、`linuxmint.17.2-x64`、`linuxmint.17.3-x64`、`linuxmint.18-x64`、`linuxmint.18.1-x64`（.NET Core 2.0 或更高版本）

**macOS RID**

`osx-x64`（NET Core 2.0 或更高版本，最低版本为 osx.10.12-x64）、`osx.10.10-x64`、`osx.10.11-x64`、`osx.10.12-x64`（.NET Core 1.1 或更高版本）、`osx.10.13-x64`


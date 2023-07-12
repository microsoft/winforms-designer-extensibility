# Control library NuGet Package Spec

Windows Forms has a rich ecosystem of vendors that provide controls and other UI components the developers can use to quickly build a fully functioning app.  

In the past (with .NET Framework Windows Forms), control vendors could depend on their designer being loaded into the same process as Visual Studio (VS). This enabled them to call Visual Studio API and manipulate the painting of their controls directly from within Visual Studio.  

However, .NET Core Windows Forms is rendered in a separate process from Visual Studio, so control authors are going to need a mechanism to package their controls that works with this new architecture.  

NuGet is the most popular way to package libraries in .NET, and vendors tend to ship their proprietary libraries by installing them to a local folder as NuGet packages, and turning that into a NuGet feed for the developer.  

In order to make this scenario work today, control library developers need to be able to specify which assemblies should be loaded by Visual Studio, and which assemblies should be loaded by the Windows Forms Design Tools Server process. This will be done by a folder convention within the NuGet package itself. 

## Prerequisites

Your package must build against the [WinForms Designer SDK](https://www.nuget.org/packages/Microsoft.WinForms.Designer.SDK).

## Assembly Locations

Windows Forms will attempt to load from the following locations: 

1. Runtime controls are expected to be in `lib\<tfm>` 
   * `tfm` stands for Target Framework Moniker (`net472`, `netcoreapp3.1`, or `net5.0`, for example) 
   * This should be the framework that the runtime controls target 
1. Visual Studio designers are expected to be in `lib\<tfm>\Design\WinForms` 
   * These should all target `.NET Framework 4.7.2`, since that's the framework that Visual Studio targets 
1. WinForms Design Tools Server process designers are expected to be in `lib\<tfm>\Design\WinForms\Server` 
   * These should all target `.NET Core 3.1` (or whatever framework the WinForms Design Tools Server process is targeting) 
1. There is no specific naming convention for the assemblies - WinForms attempts to load them all

If `lib\<tfm>\Design\WinForms` exists, we will only load files under that root. If it doesn’t, we will fall back to using the `lib\<tfm>\Design` folder as the root.  
  * This allows control developers to ship Windows Forms and WPF controls and designers in the same package (without file collisions) if they wish.
  
## Scenarios and User Experience

### Scenario 1: A control with no custom designer

For a runtime control that does not have a custom designer (`ProgressBar`, for example) we would simply use the default designer. The control files go under `lib\<tfm>`:

  ![Image of the NuGet package for control that does not have a designer](/docs/sdk/images/no-designer.png)

### Scenario 2: A control designer with custom designer UI only

For a control that needs a custom designer (but does not need complex UI interactions to occur in Visual Studio), the designer will be loaded by the Windows Forms .NET Core Design Tools Server process.  

The designer files go under `lib\<tfm>\Design\WinForms\Server`:

  ![Image of hte NuGet package structure for a control with only custom designer UI](/docs/sdk/images/custom-designer-only.png)
    
### Scenario 3: A control designer with custom interactions (using our communication protocol)

Control designers that are more complicated (intercepts interactive events, intercepts type converters, provides custom TypeConverters and/or UITypeEditors that are proxy-aware) can still use our existing protocols (for Visual Studio <-> Server Process communication). 

The designer files go in `lib\<tfm>\Design\WinForms`: 

  ![Image of the NuGet package structure of a control with custom interactions](/docs/sdk/images/custom-interactions.png)
   
These assemblies will be loaded into Visual Studio and MEF composed by the WinForms code. 

### Scenario 4: A control designer with custom interactions (using its own communication protocol) 

Control designers that are more complicated and wish to use their own communication protocols can do so. 

Microsoft.VisualStudio.WinForms.Protocol multi-targets two different frameworks: `net472` (.NET Framework 4.7.2) and `netcoreapp3.1` (.NET Core 3.1). Customers would need to create a multi-targeted project for their protocol extension and ship both versions: 

  ![Image of the structure of a control NuGet package that uses their own custom protocal](/docs/sdk/images/custom-protocol.png)

These assemblies are loaded in both the Server process and the Visual Studio process and used to pass messages between the two processes. 

### Scenario 5: A control with different designers depending on the runtime 

Controls that have different designers depending on the runtime target can specify additional assemblies. These will be loaded based upon what the referencing project is targeting: 

  ![Image of the NuGet package structure when the control has different designers depending on the specific runtime targeted ](/docs/sdk/images/different-runtime.png)

## Frequently Asked Questions

1. How do control developers deploy dependencies for their designers?
   * Developers will need to place all assemblies necessary to load and run their designers in the same folder.
   * If your designer depends on other NuGet packages, be sure to include those dependencies in your package's nuspec.

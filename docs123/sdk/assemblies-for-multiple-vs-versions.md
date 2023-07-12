## Shipping Windows Forms design-time assemblies for multiple Visual Studio versions in a single NuGet package

You may find that you need to ship more than one version of your design-time assemblies, each targeting a different version of Visual Studio.  For example, you might have basic design-time support for your controls starting in Visual Studio 17.6, but due to the introduction of some new designer extensibility APIs in 17.7 etc. you might be able to provide a better user experience in 17.8 and later Visual Studio versions. In that case you would want to ship two sets of design-time assemblies, one for Visual Studio version 17.6 and the other for 17.8 in a single NuGet package.  

This feature to support design-time assemblies targeting multiple Visual Studio versions in a single NuGet package is supported from 17.0 onwards.

#### NuGet package structure supporting design-time assemblies targeting multiple Visual Studio versions:

![NuGet package structure supporting design-time assemblies targeting multiple Visual Studio versions](/docs/sdk/images/multi-vs-versions-nuget-structure.png)
    
Design-time assemblies targeting different Visual Studio versions must be placed as follows: 
 
```
lib\<Target Framework Moniker>\Design\WinForms\<VS minimum supported version>
```
where
* `Target Framework Moniker` is like `net7.0`, `net6.0`, etc.
* `Visual Studio minimum supported version` is like `17.2`, `17.1`, `17.0,` `16.11` etc.

When the designer looks for design-time assemblies for your control assemblies and finds more than one Visual Studio versioned directories, it will choose the assemblies from the directory with highest version less than or equal to version of running instance of Visual Studio and  will load those dlls. 

If such directory is not available, designer will fall back to design-time assemblies present under ‘WinForms’ directory, if present. If assemblies are not available in ‘**WinForms**’ directory as well then, as a last step, designer will look for assemblies under ‘**Design**’ directory. 

The following table shows how the Windows Forms out-of-process designer in Visual Studio 17.3 would react when presented with two different versions of design-time assemblies targeting Visual Studio 17.0, and 17.2: 

Visual Studio Versioned Directory | Will the designer load it in Visual Studio 17.3?
------- | --------- |
| 17.0 | No. It is a candidate for loading, but a higher version is available |
| 17.2  | Yes. Closest to the designer's version |

**Note**: Feature to support design-time assemblies targeting multiple Visual Studio versions is not available in Visual Studio 16.11 and older versions. Hence 16.11 and older versions will ignore Visual Studio Versioned directories and will choose design-time assemblies first from ‘**WinForms**’ directory if available, else from ‘**Design**’ directory.

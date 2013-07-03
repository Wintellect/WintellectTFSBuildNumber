# Wintellect.TFSBuildNumber

Build numbers are kind of important. The TFS build system has a build number associated with each build you do, but does not expose it to you so you can use that version in your binary's version string. Also, best practices say that the binary version string files should never be checked in and generated every time you build. Many of the approaches people have taken with TFS to get build numbers working involve custom build work flows and installing custom assemblies on the build server.

My idea is different; build numbers should come from the build server but require nothing but pure MSBuild goodness to do the work. That way you can have an easy way to add version generation through your project files and it will work on build machines you don't control. So if your network admins have everything locked down so tight you can't do anything or you are using Hosted TFS Build Servers, where you can't do anything anyway, you now have a solid and reliable way to get version information based on the build into your binaries. 

The Wintellect.TFSBuildNumber target file makes it easy to incorporate the TFS build number from your TFS On Premises build server, Hosted TFS Build Servers (AKA TFS in the Cloud), and from developer local builds for both TFS 2012 and TFS 2013. The MSBuild tasks have been around a while on my [blog](http://www.wintellect.com/blogs/jrobbins) but it's time to be hosted more officially on GitHub so others can add and extend.

## Overview ##
The basic idea with Wintellect.TFSBuildNumber is that it will create a file with the build number in it which you can link add to your project. For example, if you're using C#, the Wintellect.TFSBuildNumber creates a file with the following information in it.

	using System; 
	using System.Reflection; 
	[assembly:AssemblyFileVersion("6.1.00702.65535")]

You then link add the file to your project and now you have the AssemblyFileVersion matching the build number.

Currently, Wintellect.TFSBuildNumber  supports .CSPROJ, .VBPROJ, .VCXPROJ, or .WIXPROJ project types. If you're working with additional project types, please do add support for those project types through a pull request of Wintellect.TFSBuildNumber.targets. Any and all accepted!

Included in this project is a sample, HostTest, that shows exactly how to integrate the MSBuild task into a project .CSPROJ file and to include the resulting version information file. You will need to edit your .CSPROJ files manually in notepad to add the correct imports. After that you never have to touch them again.

## Preempting a Lot of Questions ##

If you do not know anything about MSBuild you will probably not understand using Wintellect.TFSBuildNumber. Before asking any questions, please read the [MSBuild documentation](http://msdn.microsoft.com/en-us/library/0k6kkbsd.aspx). All the questions I've gotten in the past were because people didn't know what's going on in MSBuild files.

Before asking a question make sure to debug your MSBuild-based projects at the command line with the /v:diag switch. All the answers are in that output. :)

If you're getting errors with TFS Hosted Builds or TFS On Premises Builds about being unable to write the output files, that means you checked in the generated version files produced from Wintellect.TFSBuildNumber. You never check those files in. If you are using local work spaces in TFS, you might get the error that the build server has the produced file checked out instead. 



 
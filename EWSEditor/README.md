ToBuild.txt
Build notes as of 11/26/2019.

============
Description:
============

EWSEditor is an API explorer - an application which is used by programmers to explore the usage of an API.  In this case it was created to demonstrates 
the EWS Managed API and EWS calls.  It is an open-source sample and is not a Microsoft application.  There is no support for this code or any of its builds.

EWSEditor has three goals:

    1.Demonstrate the Exchange Web Services Managed API functionality and simplicity to developers through its source code. 
    2.Demonstrate the Exchange Web Services SOAP traffic used to perform actions initiated through an explorer user interface. 
    3.Assist non-developers in debugging and understanding Exchange stores by exploring items, folders, and their properties in depth. 

Each release of EWSEditor includes the distribution of the EWS Managed API it was built for. This version of EWSEditor uses EWS Managed API built from GIT. 
This version of EWSEditor uses .NET Framework version 4.7.2 and a build of the EWS Managed API built as of check-in 25a393d on Jul 24, 2018. 

===================
To build EWSEditor:
===================

Add the following NuGet packages:

    Microsoft.IdentityModel.Clients.ActiveDirectory  (For oAuth)

    System.Management.Automation.dll   

	Microsoft.Bcl

    Microsoft.Bcl.Build

    Microsoft.Net.Http

There is a reference to CDOSYS, for which Visual Studio generated the ADODB and CDO interops.  If you need to regenerate them 
then remove the references and be sure to delete the interop files. Next set a new reference to CDOSYS and Visual studio will 
regenerate both interop files.  CDOSYS is a COM component which comes with Windows and has both 64bit and 32bit registrations.
CDOSYS is used in EWSEditor for its MIME parsing functions.

The version of .NET used is .Net 4.7.2.  So, be sure this version of .NET is installed.

	 https://dotnet.microsoft.com/download/dotnet-framework/net472

You should be able to use a newer version of .NET, however it’s not been tested against higher versions. The reason 4.7.2 was
chosen is that it is widely installed and had needed features and fixes for EWSEditor, so it’s used as the minimum bar for .NET. 
Later builds of EWSEditor may use a newer version of .NET.

If you have issues with the referenced components then update the components and references.

==========================
About the EWS Managed API:
==========================

EWSEditor relies heavily on the EWS Managed API.  The EWS Managed API requires a minimal of .NET 3.5 - however, its best to use a recent build from 
the published source code. The build of the EWS Managed API included with EWSEditor is from 25a393d on Jul 24, 2018.  The GitHub source for the 
EWS Managed API has fixes which are not in the MSDN release.  If you think you are running into an issue with the EWS Managed API which might have 
been fixed then you should consider pulling fresh code for the EWS Managed API and building it for usage with EWSEditor and other code.   

Here is where can download the source code for the EWS Managed API.  

	https://github.com/OfficeDev/ews-managed-api

Here is where you can get the old 2.2 built version of the EWS Managed API.  There has not been a build published on MSDN in many years. 
So, if you want the fixes done over the past few years then you should not use this download and instead download the source code and build it.

	https://www.microsoft.com/en-us/download/details.aspx?id=40779

WARNING: If you are tempted to use a build of the EWS Managed API you found on the web (including NuGet) then you should pass. Such downloads may contain 
malicious code. One of my customers security software started screaming at them that a build of what seemed to be the EWS Managed API from a published
download from NuGet was causing security violations. I looked at the publisher and it was nobody I know from Microsoft.  So, unless you want to run 
the risk of a toxic download then you should be downloading the EWS Managed API and building it yourself.


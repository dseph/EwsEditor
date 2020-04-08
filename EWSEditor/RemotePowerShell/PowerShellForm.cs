using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
 
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Remoting;
using System.Management.Automation.Runspaces;
using System.Security;      // used for SecureString type.

using Microsoft.IdentityModel.Clients.ActiveDirectory;  // for oAuth

using System.IO;

using EWSEditor.Forms;
using EWSEditor.Common;
using EWSEditor.RemotePowerShell;

// #1 - Download the WindowsPowershell SDK 2.0
//
//      Windows PowerShell 2.0 Software Development Kit (SDK)
//      http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=2560
//      This will install the needed assemblies.
//
//      Installing the Windows PowerShell 2.0 SDK
//      http://technet.microsoft.com/en-us/library/ff458115(VS.85).aspx
//
// #2 - Set a reference to the Powershell automation assembly:
//
//      C:\Program Files (x86)\Reference Assemblies\Microsoft\WindowsPowerShell\v1.0\System.Management.Automation.dll
//
//      Note: Code that is compiled against the Windows PowerShell 2.0 assemblies cannot 
//      be loaded into Windows PowerShell 1.0 installations. However, code that is compiled 
//      against the Windows PowerShell 1.0 assemblies can be loaded into Windows PowerShell 2.0 installations.
// 
// #3 - Set these where automation code is called:
//
//      using System.Security;   
//      using System.Management.Automation;
//      using System.Management.Automation.Runspaces;
//      using System.Management.Automation.Remoting;
//      using System.Collections.ObjectModel;
//
// References:
//      Installing the Windows PowerShell 2.0 SDK
//      http://technet.microsoft.com/en-us/library/ff458115(VS.85).aspx
//
//  Things to note:
//      1) Exchange Powershell automation code for Exchange 2010 is totally different than it was for Exchange 2007.
//      2) Only Remote Powershell calls are supported against Exchange 2010.  Local Powershell calls 
//         through automation are not supported.
//      3) Remote Powershell calls require that you have the appropriate RBAC permssions to execute 
//         Powersehll calls.  These permissions are different than they were with EXchange 2007.
//      4) If PowerShell automation does not work, then try to execute the same code from the 
//         PowerShell command shell using the same account as the automation code is running.
//      5) If your Powershell automation code fails under COM+ or IIS, then try running the same 
//         code from either a console or winapp form. Doing this helps elminate the runtime 
//         environment from the problem being debugged.
//      6) Statements where-object and for-each may not work properly under .net automated code. In such
//         cases its best to return the initial result locally and then do another call.
//          http://blogs.msdn.com/b/dvespa/archive/2011/07/20/exchange-powershell-get-help-where-object.aspx
//      7)  Automation does not like formatting, etc commands such as format-list. Such commands would be for screen output and not data being returned, eh?

// For Exchange PowerShell 2010 and latter calls  --------------
// References:
//     Need to reference to: 
//        C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Management.Automation\v4.0_3.0.0.0__31bf3856ad364e35\System.Management.Automation.dll
//        or see:  https://www.nuget.org/packages/System.Management.Automation.dll/10.0.10586 
//     Bring in these namespaces:
//        System.Collections.ObjectModel
//        System.Management.Automation 
//        System.Management.Automation.Remoting 
//        System.Management.Automation.Runspaces 
//  The PowerShell URI:
//      http://schemas.microsoft.com/powershell/Microsoft.Exchange
//  The PowerShell URL for Exchange Online is:
//      https://outlook.office365.com/powershell-liveid/"),
// Note:
//      PowerShell 2.0+ is needed for going against Exchange 2010 and later.
//      For Exchange 2007 you need to use 
//      Remote PowerShell calls are REQUIRED for PowerShell calls to Exchange 200 and later.  DO NOT use local PowerShell calls.
//      The account doing PowerShell automation REQUIRES local admin privileges. 
//      The account accessing the Exchange server (the one being used for authentication) REQUIRES Exchange Admin privileges.
//      The Powershell URI is: http://schemas.microsoft.com/powershell/Microsoft.Exchange
// Documents:
//      PowerShell Automation from .Net
//      https://blogs.msdn.microsoft.com/emeamsgdev/2014/03/04/powershell-automation-from-net/
//      About Language Modes
//      https://msdn.microsoft.com/powershell/reference/5.1/Microsoft.PowerShell.Core/about/about_Language_Modes
//      About: Exchange PowerShell Automation
//      https://blogs.msdn.microsoft.com/webdav_101/2015/05/18/about-exchange-powershell-automation/
//      PowerShell Automation from .Net
//      http://blogs.msdn.com/b/emeamsgdev/archive/2014/03/04/powershell-automation-from-net.aspx
//      HOW TO: Migrating Exchange 2007 PowerShell Managed code to work with Exchange 2010
//      http://blogs.msdn.com/b/akashb/archive/2010/03/25/how-to-migrating-exchange-2007-powershell-managed-code-to-work-with-exchange-2010.aspx
// For Exchange 2007 local PowerShell is used.  This code is not written to go against 2007. The code also needs to run on the Exchange 2007 server.
//      See:
//         Howto: Calling Exchange Powershell from an impersonated thread.
//         https://blogs.msdn.microsoft.com/webdav_101/2008/09/25/howto-calling-exchange-powershell-from-an-impersonated-thread/
//         HOW TO: Migrating Exchange 2007 PowerShell Managed code to work with Exchange 2010
//         https://blogs.msdn.microsoft.com/akashb/2010/03/25/how-to-migrating-exchange-2007-powershell-managed-code-to-work-with-exchange-2010/
//         HOWTO: csharp – powershell – call get-clusteredmailboxserverstatus with managed code.
//         https://blogs.msdn.microsoft.com/webdav_101/2007/11/29/howto-csharp-powershell-call-get-clusteredmailboxserverstatus-with-managed-code/
//         Links on Common PowerShell Automation Questions
//         http://blogs.msdn.com/b/webdav_101/archive/2008/09/26/links-on-common-powershell-automation-questions.aspx
// oAuth Token for use with PowerShell:
//          https://blogs.msdn.microsoft.com/emeamsgdev/2018/09/07/acquiring-oauth2-access-tokens-for-automating-exchange-management-shell-cmdlets/


// my ported sample - D:\work machine\dev\TestRemotePowerShellCaller\TestRemotePowerShellCaller 

namespace EWSEditor.RemotePowerShell
{
    public partial class PowerShellForm : Form
    {
        //string _PowerShell_URL1 = "https://outlook.office365.com/powershell-liveid/";
        //string _PowerShell_URL2 = "https://Exchange-Server/powershell?serializationLevel=Full";
        //string _PowerShell_URL3 = "https://ps.outlook.com/powershell/";
        //string _schemaURI = "http://schemas.microsoft.com/powershell/Microsoft.Exchange";



        public bool IsLoading = false;
        public bool RunFromPipeline = false;
        SetVariablesMethod oSetVariableType = SetVariablesMethod.SetUsingCommandPrameterSetVariable;

        // Connect to Exchange Online PowerShell https://docs.microsoft.com/en-us/powershell/exchange/exchange-online/connect-to-exchange-online-powershell/connect-to-exchange-online-powershell?view=exchange-ps
        // for 365 - user peruser with an app password.  

        public PowerShellForm()
        {
            InitializeComponent();
            SetCallType();
        }

        private enum SetVariablesMethod
        {
            SetUsingSessionStateProxySetVariable,
            SetUsingCommandPrameterSetVariable,
            SetUsingInvokeScript

        }

        public enum PsAuthenticationMechanism
        {
            Default = 0,
            Basic = 1,
            Negotiate = 2,
            NegotiateWithImplicitCredential = 3,
            Credssp = 4,
            Digest = 5,
            Kerberos = 6,
            oAuth = 7
        }


        private void PowerShellForm_Load(object sender, EventArgs e)
        {
            this.cmboAuthentication.Text = "Basic";
            SetAuthFieldsEnablement(AuthTypeNeedsSpecifiedCredentials(cmboAuthentication.Text));
            cmboSetVariablesUsing.SelectedIndex = 0;
        }
        private void SetAuthFieldsEnablement(bool bEnablement)
        {
            this.txtUser.Enabled = bEnablement;
            this.txtPassword.Enabled = bEnablement;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

        }


        void Test()
        {
            //InitialSessionState iss = InitialSessionState.CreateDefault();


            string sResults_Errors = string.Empty;
            string sResults_Output = string.Empty;
            string sResults_Certificates = string.Empty;

            string password = string.Empty;
            string userName = string.Empty;
            System.Uri uri = null;
            PSCredential creds = null;

            Runspace oRunspace = null;
            PowerShell oPowerShell = null;
            WSManConnectionInfo oWSManConnectionInfo = null;
            Pipeline oPipeline = null;
            PSSessionOption oPSSessionOption = new PSSessionOption();
            AuthenticationMechanism oAuthenticationMechanism = AuthenticationMechanism.Default;
            PsAuthenticationMechanism oPsAuthenticationMechanism = PsAuthenticationMechanism.Default;
            PSCommand oCommand = new PSCommand();
            System.Security.SecureString securePassword = null;

            RunFromPipeline = false;

            if (rdoExecuteWithPipeline.Checked)
                RunFromPipeline = true;

            this.txtCertificates.Text = string.Empty;
            this.txtResults.Text = string.Empty;
            this.txtErrors.Text = string.Empty;
            this.txtCertificates.Update();
            this.txtResults.Update();
            this.txtErrors.Update();

            PsCertificateCallbackHandler oCertificateCallbackHandler = new PsCertificateCallbackHandler();
            ServicePointManager.ServerCertificateValidationCallback = oCertificateCallbackHandler.PsCertificateValidationCallBack;

            password = this.txtPassword.Text.Trim();
            userName = this.txtUser.Text.Trim();
            uri = new Uri(this.cmboURI.Text.Trim());


            bool bSpecifyCredentials = false;
            GetAuthenticationMechanism(cmboAuthentication.Text.Trim(), ref oAuthenticationMechanism, ref oPsAuthenticationMechanism, ref bSpecifyCredentials);

            if (bSpecifyCredentials == true)
            {
                securePassword = String2SecureString(password);
                creds = new PSCredential(userName, securePassword);
            }
            else
            {
                creds = (PSCredential)null;
            }
          
            // Special case - oAuth
            string oAuthTokenString = string.Empty;
            if (oPsAuthenticationMechanism == PsAuthenticationMechanism.oAuth)
            {    
                // See https://blogs.msdn.microsoft.com/emeamsgdev/2018/09/07/acquiring-oauth2-access-tokens-for-automating-exchange-management-shell-cmdlets/ 
                oWSManConnectionInfo.AuthenticationMechanism = AuthenticationMechanism.Default;
                oAuthTokenString = GetExchangeManagementShellToken().Result; 
                if (oAuthTokenString != string.Empty)
                {
                    System.Security.SecureString SecureTokenString = new System.Security.SecureString();
                    foreach (char c in oAuthTokenString)
                    {
                        SecureTokenString.AppendChar(c);
                    }
                    creds = new PSCredential("", SecureTokenString);
                }
                 
            }



            // OK, now we can invoke:
            try
            {
                #region Setup New WSManConnectionInfo 
                // WSManConnectionInfo
                if (this.rdoUseWSManConnectionInfo.Checked == true)
                {

                    oWSManConnectionInfo = new WSManConnectionInfo(uri, cmboShellUri.Text.Trim(), creds);
                    oWSManConnectionInfo.AuthenticationMechanism = oAuthenticationMechanism;

                    oWSManConnectionInfo.SkipCACheck = this.chkSkipCACheck.Checked;
                    oWSManConnectionInfo.SkipCNCheck = this.chkSkipCNCheck.Checked;
                    oWSManConnectionInfo.SkipRevocationCheck = this.chkSkipRevocationCheck.Checked;
               

                    oRunspace = RunspaceFactory.CreateRunspace(oWSManConnectionInfo);
                     
                    oRunspace.Open();

          

                    oPowerShell = PowerShell.Create();
                    oPowerShell.Runspace = oRunspace;

                }
                #endregion Setup New WSManConnectionInfo 

                #region Setup New PSSSession    

                if (this.rdoUseNewPSSession.Checked == true)
                {
                    //   Use new PSSession 
                    oRunspace = System.Management.Automation.Runspaces.RunspaceFactory.CreateRunspace();
                    oPowerShell = PowerShell.Create();
                    PSCommand oLocalPSCommand = new PSCommand();
                    oLocalPSCommand.AddCommand("New-PSSession");
                    oLocalPSCommand.AddParameter("ConfigurationName", "Microsoft.Exchange");
                    oLocalPSCommand.AddParameter("ConnectionUri", uri);
                    oLocalPSCommand.AddParameter("Credential", creds);
                    oLocalPSCommand.AddParameter("Authentication", cmboAuthentication.Text.Trim());
                    oLocalPSCommand.AddParameter("AllowRedirection");  // 365?

                    oPSSessionOption = new PSSessionOption();
                    oPSSessionOption.SkipCACheck = this.chkSkipCACheck.Checked;
                    oPSSessionOption.SkipCNCheck = this.chkSkipRevocationCheck.Checked;
                    oPSSessionOption.SkipRevocationCheck = this.chkSkipRevocationCheck.Checked;

                    oLocalPSCommand.AddParameter("SessionOption", oPSSessionOption);

                    oPowerShell.Commands = oLocalPSCommand;

                    oRunspace.Open();

                    oPowerShell.Runspace = oRunspace;
                    Collection<PSSession> oLocalResult = oPowerShell.Invoke<PSSession>();
                    foreach (ErrorRecord current in oPowerShell.Streams.Error)
                    {
                        Console.WriteLine("The following Error happen when opening the remote Runspace: " + current.Exception.ToString() +
                                            " | InnerException: " + current.Exception.InnerException);
                    }
                    if (oLocalResult.Count != 1)
                    {
                        throw new Exception("Unexpected number of Remote Runspace connections returned.");
                    }

                    // Set the runspace as a local variable on the runspace
                    oPowerShell = PowerShell.Create();

                    oLocalPSCommand = new PSCommand();
                    oLocalPSCommand.AddCommand("Set-Variable");
                    oLocalPSCommand.AddParameter("Name", "ra");
                    oLocalPSCommand.AddParameter("Value", oLocalResult[0]);

                    oPowerShell.Commands = oLocalPSCommand;
                    oPowerShell.Runspace = oRunspace;
                    oPowerShell.Invoke();

                    // Import the cmdlets in the current runspace (using Import-PSSession)
                    oLocalPSCommand = new PSCommand();
                    oLocalPSCommand.AddScript("Import-PSSession -Session $ra");
                    oPowerShell.Commands = oLocalPSCommand;
                    oPowerShell.Runspace = oRunspace;
                    oPowerShell.Invoke();

                    // oPowerShell.Runspace = oRunspace;

                    // At this point, we should have the runspace brought locally.
                    // oPowerShell should not be reset using oPowerShell = PowerShell.Create(); after this point.

                }
                #endregion Setup New PSSSession 

                #region Invoke

                oCommand = new PSCommand();
                SetUpInputVariablesAsCommandParameter(ref oRunspace, ref oCommand, oSetVariableType);
                SetCommandsAndScripts(ref oCommand);

                // PS C:\> set-variable -name processes -value (Get-Process) -option constant -scope global -description  "All processes" -passthru | format-list -property *
                // $global:a = 1
                // http://blogs.msdn.com/b/powershell/archive/2009/04/02/many-ways-you-can-set-a-variable-value.aspx
                // http://stackoverflow.com/questions/10907923/how-to-create-variables-using-powershell-in-c-sharp
                //oCommand.Parameters.Add(new CommandParameter("Certificate", "$cert"));
                // runspace.SessionStateProxy.SetVariable("username", "SomeUser");

                Collection<PSObject> oResultsCollection = null;
                if (rdoExecuteWithPipeline.Checked == true)
                {
                    if (chkFromPipeline.Checked == true)
                    {
                        oPipeline = oRunspace.CreatePipeline(this.txtFromPipeline.Text);
                        oResultsCollection = oPipeline.Invoke();
                    }

                }
                else
                {
                    if (chkFromPipeline.Checked == true)
                    {
                        oPipeline = oRunspace.CreatePipeline(this.txtFromPipeline.Text);
                    }
                    oPowerShell.Commands = oCommand;
                    oPowerShell.Runspace = oRunspace;
                    oResultsCollection = oPowerShell.Invoke();
                }

                System.Diagnostics.Debug.WriteLine(oPowerShell.Streams.ToString());
                System.Diagnostics.Debug.WriteLine(oPowerShell.Streams.Verbose.ToString());

                if (oPowerShell.Streams.Error.Count > 0)
                {

                    sResults_Errors = ProcessErrors(oPowerShell);

                    //this.txtCertificates.Text = sResults_Certificates;
                    //this.txtErrors.Text = sResults_Errors;

                    //oPowerShell.Runspace.Close();
                    //return;
                }

                #endregion Invoke

                if (oPowerShell.Streams.Error.Count == 0)
                {


                    if (this.txtVarName1Output.Text.Trim().Length != 0)
                        if (oRunspace.SessionStateProxy.GetVariable(txtVarName1Output.Text.Trim()) as string != null)
                            this.txtVarValue1Output.Text = string.Format("{0}", oRunspace.SessionStateProxy.GetVariable(txtVarName1Output.Text.Trim().ToString()));
                    if (this.txtVarName2Output.Text.Trim().Length != 0)
                        if (oRunspace.SessionStateProxy.GetVariable(txtVarName2Output.Text.Trim()) as string != null)
                            txtVarValue2Output.Text = string.Format("{0}", oRunspace.SessionStateProxy.GetVariable(txtVarName2Output.Text.Trim().ToString()));
                    if (this.txtVarName3Output.Text.Trim().Length != 0)
                        if (oRunspace.SessionStateProxy.GetVariable(txtVarName3Output.Text.Trim()) as string != null)
                            txtVarValue3Output.Text = string.Format("{0}", oRunspace.SessionStateProxy.GetVariable(txtVarName3Output.Text.Trim().ToString()));

                }

                sResults_Output = ProcessResponses(oResultsCollection);

            }
            catch (Exception ex)
            {
                // handle the error in some way.
                string sError = string.Empty;

                sError += "Message: " + ex.Message + "\r\n";
                sError += "InnerException: " + ex.InnerException + "\r\n";
                sError += "Source: " + ex.Source + "\r\n";
                sError += "StackTrace: " + ex.StackTrace + "\r\n";
                MessageBox.Show(sError, "Error executing Remote Powershell call");

                sResults_Errors += "\r\n-- [Execution Error - Error executing Remote Powershell call]-----------\r\n\r\n" + sError;

            }
            finally
            {
                sResults_Certificates = oCertificateCallbackHandler._Certificates;
                oCertificateCallbackHandler = null;

                oPSSessionOption = null;

                if (oPowerShell != null)
                    if (oPowerShell.Runspace != null)
                        oPowerShell.Runspace.Close();

                if (oRunspace != null)
                    oRunspace.Dispose();
                oRunspace = null;

                //oPipeline.Dispose();
                oPipeline = null;

                if (oPowerShell != null)
                    oPowerShell.Dispose();
                oPowerShell = null;


            }




            this.txtCertificates.Text = sResults_Certificates;
            this.txtResults.Text = sResults_Output;
            this.txtErrors.Text = sResults_Errors;
        }


        private void SetCallType()
        {

            bool bChecked = false;


            bChecked = rdoExecuteWithRunSpace.Checked;

            this.rdoRunThisCommand.Enabled = bChecked;
            this.txtCommand1.Enabled = bChecked;
            this.txtArgument1x1.Enabled = bChecked;
            this.txtArgument1x2.Enabled = bChecked;
            this.txtArgument1x3.Enabled = bChecked;
            this.txtArgument1x4.Enabled = bChecked;
            this.txtParamName1x1.Enabled = bChecked;
            this.txtParamValue1x1.Enabled = bChecked;
            this.txtParamName1x2.Enabled = bChecked;
            this.txtParamValue1x2.Enabled = bChecked;
            this.txtParamName1x3.Enabled = bChecked;
            this.txtParamValue1x3.Enabled = bChecked;

            this.rdoRunThisScript.Enabled = bChecked;
            this.txtScript1.Enabled = bChecked;
            this.Script1Arg1.Enabled = bChecked;
            this.Script1Arg2.Enabled = bChecked;
            this.Script1Arg3.Enabled = bChecked;
            this.Script1Arg4.Enabled = bChecked;



            bChecked = this.rdoExecuteWithPipeline.Checked;

            this.chkFromPipeline.Enabled = bChecked;
            this.txtFromPipeline.Enabled = bChecked;
 

        }

  
         

        /// <summary>
        ///  Solo test sample for reference
        /// </summary>
        private void SampleTestRunPowerShellCommand()
        {
            string sUser = "";
            string sPassword = "";
            string sPowerShell_Url = cmboURI.Text.Trim() ;
            string sPowerShellUrl = ""; //this.cmboExchangePowerShellUrl.Text.Trim();
 
            System.Security.SecureString securePassword = new System.Security.SecureString();
            foreach (char c in sPassword)
            {
                securePassword.AppendChar(c);
            }

  
            PSCredential credential = new PSCredential(sUser, securePassword);

            Uri oUri = new Uri(sPowerShellUrl);

            WSManConnectionInfo connectionInfo = new WSManConnectionInfo(oUri, sPowerShellUrl, credential);
            connectionInfo.SkipCACheck = this.chkSkipCACheck.Checked;
            connectionInfo.SkipCNCheck = this.chkSkipCNCheck.Checked;
            connectionInfo.SkipRevocationCheck = this.chkSkipRevocationCheck.Checked;

            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Basic;
            connectionInfo.MaximumConnectionRedirectionCount = 2;
            using (Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo))

            {
                runspace.Open();

                using (PowerShell powershell = PowerShell.Create())

                {
                    powershell.Runspace = runspace;
 
                    //Create the command and add a parameter
                    powershell.AddCommand("Get-Mailbox");
                    powershell.AddParameter("RecipientTypeDetails", "UserMailbox");
                    //Invoke the command and store the results in a PSObject collection

                    Collection<PSObject> results = powershell.Invoke();

                    //Iterate through the results and write the DisplayName and PrimarySMTP address for each mailbox

                    foreach (PSObject result in results)
                    {
                        Console.WriteLine(result);
                    }
                    Console.Read();
                    runspace.Close();
                }
            }
 
        }


        private void SetCommandsAndScripts(ref PSCommand oCommand)
        {
            // Command 1 ------------------------------------
            if (rdoRunThisCommand.Checked == true)
            {
                oCommand.AddCommand(txtCommand1.Text.Trim());

                if (this.txtArgument1x1.Text.Trim().Length != 0)
                    oCommand.AddArgument(this.txtArgument1x1.Text.Trim());
                if (this.txtArgument1x2.Text.Trim().Length != 0)
                    oCommand.AddArgument(this.txtArgument1x2.Text.Trim());
                if (this.txtArgument1x3.Text.Trim().Length != 0)
                    oCommand.AddArgument(this.txtArgument1x3.Text.Trim());
 

                if (txtParamName1x1.Text.Trim().Length != 0)
                {
                    if (txtParamValue1x1.Text.Trim().Length != 0)
                        oCommand.AddParameter(txtParamName1x1.Text.Trim(), txtParamValue1x1.Text.Trim());
                    else
                        oCommand.AddParameter(txtParamName1x1.Text.Trim());
                }

                if (txtParamName1x2.Text.Trim().Length != 0)
                {
                    if (txtParamValue1x2.Text.Trim().Length != 0)
                        oCommand.AddParameter(txtParamName1x2.Text.Trim(), txtParamValue1x2.Text.Trim());
                    else
                        oCommand.AddParameter(txtParamName1x2.Text.Trim());
                }

                if (txtParamName1x3.Text.Trim().Length != 0)
                {
                    if (txtParamValue1x3.Text.Trim().Length != 0)
                        oCommand.AddParameter(txtParamName1x3.Text.Trim(), txtParamValue1x3.Text.Trim());
                    else
                        oCommand.AddParameter(txtParamName1x3.Text.Trim());
                }


            }

            // Script 1 ------------------------------------

            if (rdoRunThisScript.Checked == true)
            {
                oCommand.Commands.AddScript(txtScript1.Text.Trim(), chkScript1UseLocalScope.Checked);

                if (this.Script1Arg1.Text.Trim().Length != 0)
                    oCommand.AddArgument(this.Script1Arg1.Text.Trim());
                if (this.Script1Arg2.Text.Trim().Length != 0)
                    oCommand.AddArgument(this.Script1Arg2.Text.Trim());
                if (this.Script1Arg3.Text.Trim().Length != 0)
                    oCommand.AddArgument(this.Script1Arg3.Text.Trim());
                if (this.Script1Arg4.Text.Trim().Length != 0)
                    oCommand.AddArgument(this.Script1Arg4.Text.Trim());
            }

         
        }

        private string ProcessResponses(Collection<PSObject> oResults)
        {
            string ResponseInfo = string.Empty;
            ResponseInfo += "== [Results] ========================================\r\n";


            foreach (PSObject PSresult in oResults)
            {
                ResponseInfo += "\r\n-- [Result] -----------------------------------\r\n\r\n";

                foreach (PSPropertyInfo oInfo in PSresult.Properties)
                {
                    ResponseInfo += "Name:            " + oInfo.Name + "\r\n";
                    ResponseInfo += "TypeNameOfValue: " + oInfo.TypeNameOfValue + "\r\n";
                    try
                    {
                        if (oInfo.Value != null)
                            ResponseInfo += "Value:           " + oInfo.Value.ToString() + "\r\n";

                        else
                            ResponseInfo += "Value:           <Null>\r\n";
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        ResponseInfo += "Value:           <App does not support reading this value type>\r\n";

                    }
                    ResponseInfo += "-------- \r\n";
                }
                //ResponseInfo += PSresult.Properties["Name"].Value.ToString();
                //ResponseInfo += PSresult.Properties["Name"].Value.ToString();
            }

            return ResponseInfo;
        }

        //public void ProcessResponsesTv(Collection<PSObject> oResults)
        //{
        //    TreeView oTreeView = this.tvResults;
        //    TreeNode oNode = oTreeView.Nodes.Add("Results");
        //    oNode.Tag = null;



        //    oTreeView.Nodes.Clear();

        //    TreeNode xNode = null;

        //    foreach (PSObject PSresult in oResults)
        //    {


        //        foreach (PSPropertyInfo oInfo in PSresult.Properties)
        //        {

        //            xNode = new TreeNode(oInfo.Name + "[" + oInfo.TypeNameOfValue + "]");
        //            xNode.Tag = new TreeNodeTag(oInfo.Name, oInfo.TypeNameOfValue, oInfo.Value);
        //            oNode.Nodes.Add(xNode);
        //            xNode.Nodes.Add("");
        //            xNode = null;

        //        }
        //    }

        //}

         
        private void SetUpInputVariables(ref CommandCollection oCommandCollection)
        {



        }

        private void txtURI_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmboShellUri_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmboURI_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void chkScript1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void grpCommands_Enter(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            PsTestSettings oTestSettings = new PsTestSettings();
            SetDataFromForm(ref oTestSettings.SettingsData);
            oTestSettings.SaveSettingsToFile();
            oTestSettings = null;
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            PsTestSettings oTestSettings = new PsTestSettings();
            if (oTestSettings.LoadSettingFromFile())
            {
                SetFormFromData(oTestSettings.SettingsData);
            }
            oTestSettings = null;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            PsTestSettings oSettings = new PsTestSettings();
            this.Cursor = Cursors.WaitCursor;
            Test();
            this.Cursor = Cursors.Default;
        }

        private void rdoUseWSManConnectionInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoUseWSManConnectionInfo.Checked)
            {
                //this.rdoUseLocal.Checked = false;
                this.rdoUseNewPSSession.Checked = false;
            }

            PowershellCallTypeEnablement();
            SetCallType();
        }

        private void rdoUseNewPSSession_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoUseNewPSSession.Checked)
            {
                //this.rdoUseLocal.Checked = false;
                this.rdoUseWSManConnectionInfo.Checked = false;
            }

            PowershellCallTypeEnablement();
            SetCallType();
        }

        private void rdoExecuteWithRunSpace_CheckedChanged(object sender, EventArgs e)
        {
            SetScriptRunType();
        }

        private void rdoExecuteWithPipeline_CheckedChanged(object sender, EventArgs e)
        {
            SetScriptRunType();
        }

        private void SetScriptRunType()
        {


            if (rdoExecuteWithRunSpace.Checked)
                this.rdoExecuteWithPipeline.Checked = false;

            if (rdoExecuteWithPipeline.Checked)
                this.rdoExecuteWithRunSpace.Checked = false;

        }

        //private void SetUpInputVariablesAsCommandParameter(ref Runspace oRunspace, ref PSCommand oCommand, SetVariablesMethod oSetVariableType)
        //{

        //    Command oParamCommand = null;

        //    if (txtVarName1.Text.Trim().Length != 0)
        //        if (txtVarValue1.Text.Trim().Length != 0)
        //        {
        //            switch (oSetVariableType)
        //            {
        //                case SetVariablesMethod.SetUsingSessionStateProxySetVariable:
        //                    oRunspace.SessionStateProxy.SetVariable(txtVarName1.Text.Trim(), txtVarValue1.Text.Trim());
        //                    break;
        //                case SetVariablesMethod.SetUsingCommandPrameterSetVariable:
        //                    oParamCommand = new Command("Set-Variable");
        //                    oParamCommand.Parameters.Add("Name", txtVarName1.Text.Trim());
        //                    oParamCommand.Parameters.Add("Value", this.txtVarValue1.Text.Trim());
        //                    oCommand.Commands.Add(oParamCommand);
        //                    break;
        //                case SetVariablesMethod.SetUsingInvokeScript:
        //                    oCommand.AddScript("new-variable -scope global -name " + txtVarName1.Text.Trim() + " -value " + txtVarValue1.Text.Trim());
        //                    break;
        //            }
        //        }
        //        else
        //            MessageBox.Show("Variable 1 needs to have a value set.", "Missing Value");

        //    if (txtVarName2.Text.Trim().Length != 0)
        //        if (txtVarValue2.Text.Trim().Length != 0)
        //        {
        //            switch (oSetVariableType)
        //            {
        //                case SetVariablesMethod.SetUsingSessionStateProxySetVariable:
        //                    oRunspace.SessionStateProxy.SetVariable(txtVarName2.Text.Trim(), txtVarValue2.Text.Trim());
        //                    break;
        //                case SetVariablesMethod.SetUsingCommandPrameterSetVariable:
        //                    oParamCommand = new Command("Set-Variable");
        //                    oParamCommand.Parameters.Add("Name", txtVarName2.Text.Trim());
        //                    oParamCommand.Parameters.Add("Value", txtVarValue2.Text.Trim());
        //                    oCommand.Commands.Add(oParamCommand);
        //                    break;
        //                case SetVariablesMethod.SetUsingInvokeScript:
        //                    oCommand.AddScript("new-variable -scope global -name " + txtVarName2.Text.Trim() + " -value " + txtVarValue2.Text.Trim());
        //                    break;
        //            }
        //        }
        //        else
        //            MessageBox.Show("Variable 2 needs to have a value set.", "Missing Value");

        //    if (txtVarName3.Text.Trim().Length != 0)
        //        if (txtVarValue3.Text.Trim().Length != 0)
        //        {

        //            switch (oSetVariableType)
        //            {
        //                case SetVariablesMethod.SetUsingSessionStateProxySetVariable:
        //                    oRunspace.SessionStateProxy.SetVariable(txtVarName3.Text.Trim(), txtVarValue3.Text.Trim());
        //                    break;
        //                case SetVariablesMethod.SetUsingCommandPrameterSetVariable:
        //                    oParamCommand = new Command("Set-Variable");
        //                    oParamCommand.Parameters.Add("Name", txtVarName3.Text.Trim());
        //                    oParamCommand.Parameters.Add("Value", txtVarValue3.Text.Trim());
        //                    oCommand.Commands.Add(oParamCommand);
        //                    break;
        //                case SetVariablesMethod.SetUsingInvokeScript:
        //                    oCommand.AddScript("new-variable -scope global -name " + txtVarName3.Text.Trim() + " -value " + txtVarValue3.Text.Trim());
        //                    break;
        //            }
        //        }
        //        else
        //            MessageBox.Show("Variable 3 needs to have a value set.", "Missing Value");
        //    oParamCommand = null;

        //}


        private string ProcessErrors(PowerShell oPowerShell)
        {
            string ResponseErrors = string.Empty;


            ResponseErrors += "== [ResponseErrors] ========================================\r\n";

            ResponseErrors += "\r\n-- [ResponseError] ----------------------------------------\r\n\r\n";
            foreach (ErrorRecord current in oPowerShell.Streams.Error)
            {


                if (current.CategoryInfo != null)
                {
                    ResponseErrors += "CategoryInfo: " + current.CategoryInfo.ToString() + "\r\n";
                    ResponseErrors += "    Activity: " + current.CategoryInfo.Activity + "\r\n";
                    ResponseErrors += "    Category: " + current.CategoryInfo.Category.ToString() + "\r\n";
                    ResponseErrors += "    Reason: " + current.CategoryInfo.Reason.ToString() + "\r\n";
                    ResponseErrors += "    TargetName: " + current.CategoryInfo.TargetName.ToString() + "\r\n";
                    ResponseErrors += "    TargetType: " + current.CategoryInfo.TargetType.ToString() + "\r\n";

                }

                ResponseErrors += "    Exception: " + current.Exception.ToString() + "\r\n";
                ResponseErrors += "    FullyQualifiedErrorId: " + current.FullyQualifiedErrorId + "\r\n";
                ResponseErrors += "    ErrorDetails: " + current.ErrorDetails + "\r\n";


                ResponseErrors += "    InvocationInfo.:  \r\n";
                if (current.InvocationInfo != null)
                {
                    //foreach (string in current.InvocationInfo.BoundParameters)
                    //{

                    //}
                    // current.InvocationInfo.CommandOrigin = CommandOrigin. 
                    ResponseErrors += "        ExpectingInput: " + current.InvocationInfo.ExpectingInput.ToString() + "\r\n";
                    ResponseErrors += "        HistoryId: " + current.InvocationInfo.HistoryId.ToString() + "\r\n";
                    ResponseErrors += "        InvocationName: " + current.InvocationInfo.InvocationName + "\r\n";
                    ResponseErrors += "        Line: " + current.InvocationInfo.Line.ToString() + "\r\n";
                }

                ResponseErrors += "        MyCommand:  \r\n";
                if (current.InvocationInfo.MyCommand != null)
                {
                    ResponseErrors += "            CommandType: " + current.InvocationInfo.MyCommand.CommandType.ToString() + "\r\n";
                    ResponseErrors += "            Definition: " + current.InvocationInfo.MyCommand.Definition.ToString() + "\r\n";
                    //ResponseErrors += "        CommandType: " + current.InvocationInfo.MyCommand.Module..ToString() + "\r\n";
                    ResponseErrors += "            ModuleName: " + current.InvocationInfo.MyCommand.ModuleName.ToString() + "\r\n";
                    ResponseErrors += "            Name: " + current.InvocationInfo.MyCommand.Name.ToString() + "\r\n";
                    //ResponseErrors += "        OutputType: " + current.InvocationInfo.MyCommand.OutputType..ToString() + "\r\n";
                    //ResponseErrors += "        Parameters: " + current.InvocationInfo.MyCommand.Parameters.ToString() + "\r\n";
                    //ResponseErrors += "        ParameterSets: " + current.InvocationInfo.MyCommand.ParameterSets.ToString() + "\r\n";
                    ResponseErrors += "        ModuleName: " + current.InvocationInfo.MyCommand.Visibility.ToString() + "\r\n";
                }
                ResponseErrors += "        OffsetInLine: " + current.InvocationInfo.OffsetInLine.ToString() + "\r\n";
                ResponseErrors += "        PipelineLength: " + current.InvocationInfo.PipelineLength.ToString() + "\r\n";
                ResponseErrors += "        PipelinePosition: " + current.InvocationInfo.PipelinePosition.ToString() + "\r\n";
                ResponseErrors += "        PositionMessage: " + current.InvocationInfo.PositionMessage.ToString() + "\r\n";
                ResponseErrors += "        ScriptLineNumber: " + current.InvocationInfo.ScriptLineNumber.ToString() + "\r\n";
                ResponseErrors += "        ScriptName: " + current.InvocationInfo.ScriptName.ToString() + "\r\n";
                //ResponseErrors += "    UnboundArguments: " + current.InvocationInfo.UnboundArguments.ToString() + "\r\n";

                ResponseErrors += "        Exception:  \r\n";
                if (current.Exception != null)
                {
                    // ResponseErrors += "    Exception.InnerException: " + current.Exception.InnerException.ToString() + "\r\n";
                    ResponseErrors += "    Exception.Message: " + current.Exception.Message.ToString() + "\r\n";
                    //ResponseErrors += "    Exception.Source: " + current.Exception.Source.ToString() + "\r\n";
                    //ResponseErrors += "    Exception.StackTrace: " + current.Exception.StackTrace.ToString() + "\r\n";
                }
            }

            return ResponseErrors;
        }

        private static SecureString String2SecureString(string password)
        {
            SecureString remotePassword = new SecureString();
            for (int i = 0; i < password.Length; i++)
                remotePassword.AppendChar(password[i]);

            return remotePassword;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



        private void GetAuthenticationMechanism(string sAuthMethod, 
            ref AuthenticationMechanism oAuthenticationMechanism, 
            ref PsAuthenticationMechanism oPsAuthenticationMechanism, 
            ref bool bSpecifyCredentials)
        {


            switch (cmboAuthentication.Text)
            {

                case "oAuth":
                    bSpecifyCredentials = true;
                    oAuthenticationMechanism = AuthenticationMechanism.Default;
                    oPsAuthenticationMechanism = PsAuthenticationMechanism.oAuth;
                    break;
                case "Basic":
                    bSpecifyCredentials = true;
                    oAuthenticationMechanism = AuthenticationMechanism.Basic;
                    oPsAuthenticationMechanism = PsAuthenticationMechanism.Basic;
                    break;
                case "Credssp":
                    bSpecifyCredentials = true;
                    oAuthenticationMechanism = AuthenticationMechanism.Credssp;
                    oPsAuthenticationMechanism = PsAuthenticationMechanism.Credssp;
                    break;
                case "Default":
                    bSpecifyCredentials = false;
                    oAuthenticationMechanism = AuthenticationMechanism.Default;
                    oPsAuthenticationMechanism = PsAuthenticationMechanism.Default;
                    break;
                case "Digest":
                    bSpecifyCredentials = true;
                    oAuthenticationMechanism = AuthenticationMechanism.Digest;
                    oPsAuthenticationMechanism = PsAuthenticationMechanism.Digest;
                    break;
                case "Kerberos":
                    bSpecifyCredentials = false;
                    oAuthenticationMechanism = AuthenticationMechanism.Kerberos;
                    oPsAuthenticationMechanism = PsAuthenticationMechanism.Kerberos;
                    break;
                case "Negotiate":
                    bSpecifyCredentials = true;
                    oAuthenticationMechanism = AuthenticationMechanism.Negotiate;
                    oPsAuthenticationMechanism = PsAuthenticationMechanism.Negotiate;
                    break;
                case "NegotiateWithImplicitCredential":
                    bSpecifyCredentials = false;
                    oAuthenticationMechanism = AuthenticationMechanism.NegotiateWithImplicitCredential;
                    oPsAuthenticationMechanism = PsAuthenticationMechanism.NegotiateWithImplicitCredential;
                    break;
            }
        }
 


        private void SetUpInputVariablesAsCommandParameter(ref Runspace oRunspace, ref PSCommand oCommand, SetVariablesMethod oSetVariableType)
        {

            Command oParamCommand = null;

            if (txtVarName1.Text.Trim().Length != 0)
                if (txtVarValue1.Text.Trim().Length != 0)
                {
                    switch (oSetVariableType)
                    {
                        case SetVariablesMethod.SetUsingSessionStateProxySetVariable:
                            oRunspace.SessionStateProxy.SetVariable(txtVarName1.Text.Trim(), txtVarValue1.Text.Trim());
                            break;
                        case SetVariablesMethod.SetUsingCommandPrameterSetVariable:
                            oParamCommand = new Command("Set-Variable");
                            oParamCommand.Parameters.Add("Name", txtVarName1.Text.Trim());
                            oParamCommand.Parameters.Add("Value", this.txtVarValue1.Text.Trim());
                            oCommand.Commands.Add(oParamCommand);
                            break;
                        case SetVariablesMethod.SetUsingInvokeScript:
                            oCommand.AddScript("new-variable -scope global -name " + txtVarName1.Text.Trim() + " -value " + txtVarValue1.Text.Trim());
                            break;
                    }
                }
                else
                    MessageBox.Show("Variable 1 needs to have a value set.", "Missing Value");

            if (txtVarName2.Text.Trim().Length != 0)
                if (txtVarValue2.Text.Trim().Length != 0)
                {
                    switch (oSetVariableType)
                    {
                        case SetVariablesMethod.SetUsingSessionStateProxySetVariable:
                            oRunspace.SessionStateProxy.SetVariable(txtVarName2.Text.Trim(), txtVarValue2.Text.Trim());
                            break;
                        case SetVariablesMethod.SetUsingCommandPrameterSetVariable:
                            oParamCommand = new Command("Set-Variable");
                            oParamCommand.Parameters.Add("Name", txtVarName2.Text.Trim());
                            oParamCommand.Parameters.Add("Value", txtVarValue2.Text.Trim());
                            oCommand.Commands.Add(oParamCommand);
                            break;
                        case SetVariablesMethod.SetUsingInvokeScript:
                            oCommand.AddScript("new-variable -scope global -name " + txtVarName2.Text.Trim() + " -value " + txtVarValue2.Text.Trim());
                            break;
                    }
                }
                else
                    MessageBox.Show("Variable 2 needs to have a value set.", "Missing Value");

            if (txtVarName3.Text.Trim().Length != 0)
                if (txtVarValue3.Text.Trim().Length != 0)
                {

                    switch (oSetVariableType)
                    {
                        case SetVariablesMethod.SetUsingSessionStateProxySetVariable:
                            oRunspace.SessionStateProxy.SetVariable(txtVarName3.Text.Trim(), txtVarValue3.Text.Trim());
                            break;
                        case SetVariablesMethod.SetUsingCommandPrameterSetVariable:
                            oParamCommand = new Command("Set-Variable");
                            oParamCommand.Parameters.Add("Name", txtVarName3.Text.Trim());
                            oParamCommand.Parameters.Add("Value", txtVarValue3.Text.Trim());
                            oCommand.Commands.Add(oParamCommand);
                            break;
                        case SetVariablesMethod.SetUsingInvokeScript:
                            oCommand.AddScript("new-variable -scope global -name " + txtVarName3.Text.Trim() + " -value " + txtVarValue3.Text.Trim());
                            break;
                    }
                }
                else
                    MessageBox.Show("Variable 3 needs to have a value set.", "Missing Value");
            oParamCommand = null;

        }


        //private string ProcessErrors(PowerShell oPowerShell)
        //{
        //    string ResponseErrors = string.Empty;


        //    ResponseErrors += "== [ResponseErrors] ========================================\r\n";

        //    ResponseErrors += "\r\n-- [ResponseError] ----------------------------------------\r\n\r\n";
        //    foreach (ErrorRecord current in oPowerShell.Streams.Error)
        //    {


        //        if (current.CategoryInfo != null)
        //        {
        //            ResponseErrors += "CategoryInfo: " + current.CategoryInfo.ToString() + "\r\n";
        //            ResponseErrors += "    Activity: " + current.CategoryInfo.Activity + "\r\n";
        //            ResponseErrors += "    Category: " + current.CategoryInfo.Category.ToString() + "\r\n";
        //            ResponseErrors += "    Reason: " + current.CategoryInfo.Reason.ToString() + "\r\n";
        //            ResponseErrors += "    TargetName: " + current.CategoryInfo.TargetName.ToString() + "\r\n";
        //            ResponseErrors += "    TargetType: " + current.CategoryInfo.TargetType.ToString() + "\r\n";

        //        }

        //        ResponseErrors += "    Exception: " + current.Exception.ToString() + "\r\n";
        //        ResponseErrors += "    FullyQualifiedErrorId: " + current.FullyQualifiedErrorId + "\r\n";
        //        ResponseErrors += "    ErrorDetails: " + current.ErrorDetails + "\r\n";


        //        ResponseErrors += "    InvocationInfo.:  \r\n";
        //        if (current.InvocationInfo != null)
        //        {
        //            //foreach (string in current.InvocationInfo.BoundParameters)
        //            //{

        //            //}
        //            // current.InvocationInfo.CommandOrigin = CommandOrigin. 
        //            ResponseErrors += "        ExpectingInput: " + current.InvocationInfo.ExpectingInput.ToString() + "\r\n";
        //            ResponseErrors += "        HistoryId: " + current.InvocationInfo.HistoryId.ToString() + "\r\n";
        //            ResponseErrors += "        InvocationName: " + current.InvocationInfo.InvocationName + "\r\n";
        //            ResponseErrors += "        Line: " + current.InvocationInfo.Line.ToString() + "\r\n";
        //        }

        //        ResponseErrors += "        MyCommand:  \r\n";
        //        if (current.InvocationInfo.MyCommand != null)
        //        {
        //            ResponseErrors += "            CommandType: " + current.InvocationInfo.MyCommand.CommandType.ToString() + "\r\n";
        //            ResponseErrors += "            Definition: " + current.InvocationInfo.MyCommand.Definition.ToString() + "\r\n";
        //            //ResponseErrors += "        CommandType: " + current.InvocationInfo.MyCommand.Module..ToString() + "\r\n";
        //            ResponseErrors += "            ModuleName: " + current.InvocationInfo.MyCommand.ModuleName.ToString() + "\r\n";
        //            ResponseErrors += "            Name: " + current.InvocationInfo.MyCommand.Name.ToString() + "\r\n";
        //            //ResponseErrors += "        OutputType: " + current.InvocationInfo.MyCommand.OutputType..ToString() + "\r\n";
        //            //ResponseErrors += "        Parameters: " + current.InvocationInfo.MyCommand.Parameters.ToString() + "\r\n";
        //            //ResponseErrors += "        ParameterSets: " + current.InvocationInfo.MyCommand.ParameterSets.ToString() + "\r\n";
        //            ResponseErrors += "        ModuleName: " + current.InvocationInfo.MyCommand.Visibility.ToString() + "\r\n";
        //        }
        //        ResponseErrors += "        OffsetInLine: " + current.InvocationInfo.OffsetInLine.ToString() + "\r\n";
        //        ResponseErrors += "        PipelineLength: " + current.InvocationInfo.PipelineLength.ToString() + "\r\n";
        //        ResponseErrors += "        PipelinePosition: " + current.InvocationInfo.PipelinePosition.ToString() + "\r\n";
        //        ResponseErrors += "        PositionMessage: " + current.InvocationInfo.PositionMessage.ToString() + "\r\n";
        //        ResponseErrors += "        ScriptLineNumber: " + current.InvocationInfo.ScriptLineNumber.ToString() + "\r\n";
        //        ResponseErrors += "        ScriptName: " + current.InvocationInfo.ScriptName.ToString() + "\r\n";
        //        //ResponseErrors += "    UnboundArguments: " + current.InvocationInfo.UnboundArguments.ToString() + "\r\n";

        //        ResponseErrors += "        Exception:  \r\n";
        //        if (current.Exception != null)
        //        {
        //            // ResponseErrors += "    Exception.InnerException: " + current.Exception.InnerException.ToString() + "\r\n";
        //            ResponseErrors += "    Exception.Message: " + current.Exception.Message.ToString() + "\r\n";
        //            //ResponseErrors += "    Exception.Source: " + current.Exception.Source.ToString() + "\r\n";
        //            //ResponseErrors += "    Exception.StackTrace: " + current.Exception.StackTrace.ToString() + "\r\n";
        //        }
        //    }

        //    return ResponseErrors;
        //}

        private void rdoRunThisCommand_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void cmboAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAuthFieldsEnablement(AuthTypeNeedsSpecifiedCredentials(cmboAuthentication.Text));
        }
        private bool AuthTypeNeedsSpecifiedCredentials(string sSelectedAuthentication)
        {
            bool bRet = false;

            switch (sSelectedAuthentication)
            {
 

                case "Basic":
                    bRet = true;
                    break;
                //case "Credssp":
                //    bRet = true;  //?
                //    break;
                case "Default":
                    bRet = false;
                    break;
                case "Digest":
                    bRet = true;
                    break;
                case "Kerberos":
                    bRet = false;
                    break;
                case "Negotiate":
                    bRet = true;
                    break;
                case "NegotiateWithImplicitCredential":
                    bRet = false;
                    break;
                case "oAuth":
                    bRet = false;
                    break;
            }
            return bRet;
        }


        private void SetDataFromForm(ref PsTestSettings.TestSettingsData SettingsData)
        {

            SettingsData.AppVersion = "1.0";

            SettingsData.UseNewPSSession = this.rdoUseNewPSSession.Checked;
            //SettingsData.rdoUseLocal = this.rdoUseLocal.Checked;
            SettingsData.UseWSManConnectionInfo = this.rdoUseWSManConnectionInfo.Checked;

            SettingsData.ShellUri = this.cmboShellUri.Text.Trim();
           // SettingsData.Server = this.txtServer.Text.Trim();
            SettingsData.URI = this.cmboURI.Text.Trim();
            SettingsData.Authentication = this.cmboAuthentication.Text.Trim();
            SettingsData.User = this.txtUser.Text.Trim();
            SettingsData.Password = this.txtPassword.Text.Trim();
            SettingsData.SkipCNCheck = this.chkSkipCNCheck.Checked;
            SettingsData.SkipCACheck = this.chkSkipCACheck.Checked;
            SettingsData.SkipRevocationCheck = this.chkSkipRevocationCheck.Checked;

            SettingsData.VarName1 = this.txtVarName1.Text.Trim();
            SettingsData.VarValue1 = this.txtVarValue1.Text.Trim();
            SettingsData.VarName2 = this.txtVarName2.Text.Trim();
            SettingsData.VarValue2 = this.txtVarValue2.Text.Trim();
            SettingsData.VarName3 = this.txtVarName3.Text.Trim();
            SettingsData.VarValue3 = this.txtVarValue3.Text.Trim();

            SettingsData.VarName1Output = this.txtVarName1Output.Text.Trim();
            SettingsData.VarName2Output = this.txtVarName2Output.Text.Trim();
            SettingsData.VarName3Output = this.txtVarName3Output.Text.Trim();


            SettingsData.Command1Selected = this.rdoRunThisCommand.Checked;
            SettingsData.CommandText1 = this.txtCommand1.Text.Trim();
            SettingsData.Argument1x1 = this.txtArgument1x1.Text.Trim();
            SettingsData.Argument1x2 = this.txtArgument1x2.Text.Trim();
            SettingsData.Argument1x3 = this.txtArgument1x3.Text.Trim();
            SettingsData.Argument1x4 = this.txtArgument1x4.Text.Trim();
            SettingsData.ParamName1x1 = this.txtParamName1x1.Text.Trim();
            SettingsData.ParamValue1x1 = this.txtParamValue1x1.Text.Trim();
            SettingsData.ParamName1x2 = this.txtParamName1x2.Text.Trim();
            SettingsData.ParamValue1x2 = this.txtParamValue1x2.Text.Trim();
            SettingsData.ParamName1x3 = this.txtParamName1x3.Text.Trim();
            SettingsData.ParamValue1x3 = this.txtParamValue1x3.Text.Trim();



 


            SettingsData.Script1Selected = this.rdoRunThisScript.Checked;
            SettingsData.Script1 = this.txtScript1.Text;
            SettingsData.Script1Arg1 = this.Script1Arg1.Text;
            SettingsData.Script1Arg2 = this.Script1Arg2.Text;
            SettingsData.Script1Arg3 = this.Script1Arg3.Text;
            SettingsData.Script1Arg4 = this.Script1Arg4.Text;

            SettingsData.FromPipelineSelected = this.chkFromPipeline.Checked;
            SettingsData.FromPipeline = this.txtFromPipeline.Text;

            SettingsData.Script1UseLocalScope = this.chkScript1UseLocalScope.Checked;



            SetCallType();

        }
         

        private void SetFormFromData(PsTestSettings.TestSettingsData SettingsData)
        {
            this.IsLoading = true;

            this.rdoUseNewPSSession.Checked = SettingsData.UseNewPSSession;
            //this.rdoUseLocal.Checked = SettingsData.rdoUseLocal;
            this.rdoUseWSManConnectionInfo.Checked = SettingsData.UseWSManConnectionInfo;

            this.cmboShellUri.Text = SettingsData.ShellUri;
           // this.txtServer.Text = SettingsData.Server;
            this.cmboURI.Text = SettingsData.URI;
            this.cmboAuthentication.Text = SettingsData.Authentication;
            this.txtUser.Text = SettingsData.User;
            this.txtPassword.Text = SettingsData.Password;
            this.chkSkipCNCheck.Checked = SettingsData.SkipCNCheck;
            this.chkSkipCACheck.Checked = SettingsData.SkipCACheck;
            this.chkSkipRevocationCheck.Checked = SettingsData.SkipRevocationCheck;


            this.txtVarName1.Text = SettingsData.VarName1;
            this.txtVarValue1.Text = SettingsData.VarValue1;
            this.txtVarName2.Text = SettingsData.VarName2;
            this.txtVarValue2.Text = SettingsData.VarValue2;
            this.txtVarName3.Text = SettingsData.VarName3;
            this.txtVarValue3.Text = SettingsData.VarValue3;

            this.txtVarName1Output.Text = SettingsData.VarName1Output;
            this.txtVarName2Output.Text = SettingsData.VarName2Output;
            this.txtVarName3Output.Text = SettingsData.VarName3Output;
            this.txtVarName1Output.Text = string.Empty;
            this.txtVarName2Output.Text = string.Empty;
            this.txtVarName3Output.Text = string.Empty;


            this.rdoRunThisCommand.Checked = SettingsData.Command1Selected;
            this.txtCommand1.Text = SettingsData.CommandText1;
            this.txtArgument1x1.Text = SettingsData.Argument1x1;
            this.txtArgument1x2.Text = SettingsData.Argument1x2;
            this.txtArgument1x3.Text = SettingsData.Argument1x3;
            this.txtArgument1x4.Text = SettingsData.Argument1x4;
            this.txtParamName1x1.Text = SettingsData.ParamName1x1;
            this.txtParamValue1x1.Text = SettingsData.ParamValue1x1;
            this.txtParamName1x2.Text = SettingsData.ParamName1x2;
            this.txtParamValue1x2.Text = SettingsData.ParamValue1x2;
            this.txtParamName1x3.Text = SettingsData.ParamName1x3;
            this.txtParamValue1x3.Text = SettingsData.ParamValue1x3;


            this.rdoRunThisScript.Checked = SettingsData.Script1Selected;
            this.txtScript1.Text = SettingsData.Script1;
            this.Script1Arg1.Text = SettingsData.Script1Arg1;
            this.Script1Arg2.Text = SettingsData.Script1Arg2;
            this.Script1Arg3.Text = SettingsData.Script1Arg3;
            this.Script1Arg4.Text = SettingsData.Script1Arg4;

            

            this.chkFromPipeline.Checked = SettingsData.FromPipelineSelected;
            this.txtFromPipeline.Text = SettingsData.FromPipeline;

            this.chkScript1UseLocalScope.Checked = SettingsData.Script1UseLocalScope;
 

            if (SettingsData.ExecuteWithPipeline == true)
            {
                this.rdoExecuteWithRunSpace.Checked = false;
                this.rdoExecuteWithPipeline.Checked = true;
            }
            else
            {
                this.rdoExecuteWithRunSpace.Checked = true;
                this.rdoExecuteWithPipeline.Checked = false;
            }

            this.txtCertificates.Text = "";
            this.txtResults.Text = "";
            this.txtErrors.Text = "";

            PowershellCallTypeEnablement();
            SetCallType();

            this.IsLoading = false;

        }

        private void PowershellCallTypeEnablement()
        {

            bool bValue = false;

            //if (this.rdoUseLocal.Checked == true)
            //{
            //    bValue = false;
            //}

            if (this.rdoUseWSManConnectionInfo.Checked == true)
            {
                bValue = true;

            }
            else
            {
                bValue = true;
            }

            this.cmboShellUri.Enabled = bValue;
            //this.txtServer.Enabled = bValue;
            this.cmboAuthentication.Enabled = bValue;
            this.txtUser.Enabled = bValue;
            this.cmboURI.Enabled = bValue;
            this.txtPassword.Enabled = bValue;
            this.chkSkipCNCheck.Enabled = bValue;
            this.chkSkipCACheck.Enabled = bValue;
            this.chkSkipRevocationCheck.Enabled = bValue;
        }

        private void txtCertificates_DoubleClick(object sender, EventArgs e)
        {

            ShowTextDocument oForm = new ShowTextDocument();
            oForm.txtEntry.WordWrap = false;
            oForm.Text = "Information";
            oForm.txtEntry.Text = this.txtCertificates.Text;
            oForm.ShowDialog();

        }

        private void txtErrors_DoubleClick(object sender, EventArgs e)
        {

            ShowTextDocument oForm = new ShowTextDocument();
            oForm.txtEntry.WordWrap = false;
            oForm.Text = "Information";
            oForm.txtEntry.Text = this.txtErrors.Text;
            oForm.ShowDialog();
        }

        private void txtResults_DoubleClick(object sender, EventArgs e)
        {
            ShowTextDocument oForm = new ShowTextDocument();
            oForm.txtEntry.WordWrap = false;
            oForm.Text = "Information";
            oForm.txtEntry.Text = this.txtResults.Text;
            oForm.ShowDialog();
        }

        public static async Task<string> GetExchangeManagementShellToken()
        {
            //// See: https://blogs.msdn.microsoft.com/emeamsgdev/2018/09/07/acquiring-oauth2-access-tokens-for-automating-exchange-management-shell-cmdlets/
           
            //public string ExchagneManagemetnShellApplicationId = "a0c73c16-a7e3-4564-9a95-2bdf47383716";
            //public string ExchagneManagemetnShellApplicationRedirectUrL = "urn:ietf:wg:oauth:2.0:oob";

            try
            {
                AuthenticationContext authenticationContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext("https://login.microsoftonline.com/common", false);
                AuthenticationResult authenticationResult = await authenticationContext.AcquireTokenAsync("https://outlook.office365.com", "a0c73c16-a7e3-4564-9a95-2bdf47383716", new Uri("urn:ietf:wg:oauth:2.0:oob"), new PlatformParameters(PromptBehavior.Always));
                return authenticationResult.CreateAuthorizationHeader();
            }
            catch (Exception ex)
            {
                string x = ex.Message.ToString();
            }
            return "";
        }

        private void chkFromPipeline_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

     
}

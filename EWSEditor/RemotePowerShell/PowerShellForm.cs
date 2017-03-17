using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Remoting;
using System.Management.Automation.Runspaces;
using System.Security;      // used for SecureString type.

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



namespace EWSEditor.RemotePowerShell
{
    public partial class PowerShellForm : Form
    {
        string _PowerShell_URL1 = "https://outlook.office365.com/powershell-liveid/";
        string _PowerShell_URL2 = "https://Exchange-Server/powershell?serializationLevel=Full";
        string _PowerShell_URL3 = "https://ps.outlook.com/powershell/";
        string _schemaURI = "http://schemas.microsoft.com/powershell/Microsoft.Exchange";

        public PowerShellForm()
        {
            InitializeComponent();
        }

        private void PowerShellForm_Load(object sender, EventArgs e)
        {
            //this.txtURI.Text = _schemaURI;
            //this.cmboExchangePowerShellUrl.Items.Add(_PowerShell_URL1);
            //this.cmboExchangePowerShellUrl.Items.Add(_PowerShell_URL2);
            //this.cmboExchangePowerShellUrl.Items.Add(_PowerShell_URL3);
            //this.cmboExchangePowerShellUrl.Text = _PowerShell_URL1;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

        }

        private void DoRemotePowerShellCommandCall()
        {

        }

        private void DoRemotePowerShellScriptCall()
        {
            //Example from:  http://stackoverflow.com/questions/10566603/powershell-and-exchange-in-c-sharp

            //string schemaURI = "http://schemas.microsoft.com/powershell/Microsoft.Exchange";
            //Uri connectTo = new Uri("https://ps.outlook.com/powershell/");
            //PSCredential credential = new PSCredential(user, secureStringPassword); // the password must be of type SecureString
            //WSManConnectionInfo connectionInfo = new WSManConnectionInfo(connectTo, schemaURI, credential);
            //connectionInfo.MaximumConnectionRedirectionCount = 5;
            //connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Basic;

            //try
            //{
            //    Runspace remoteRunspace = RunspaceFactory.CreateRunspace(connectionInfo);
            //    remoteRunspace.Open();
            //}
            //catch (Exception e)
            //{
            //    //Handle error 
            //}
        }

        private void RunPowerShellCommand()
        {
            // the following is Myesha's sample:

            string sUser = "";
            string sPassword = "";
            string sPowerShell_Url = txtURI.Text.Trim() ;
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
            if (chkCommand1.Checked == true)
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

            if (chkScript1.Checked == true)
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

            // Command 2 ------------------------------------
            if (chkCommand2.Checked == true)
            {
                oCommand.AddCommand(txtCommand2.Text.Trim());

                /// Arguments
                if (this.txtArgument2x1.Text.Trim().Length != 0)
                    oCommand.AddArgument(this.txtArgument2x1.Text.Trim());
                if (this.txtArgument2x2.Text.Trim().Length != 0)
                    oCommand.AddArgument(this.txtArgument2x2.Text.Trim());
                if (this.txtArgument2x3.Text.Trim().Length != 0)
                    oCommand.AddArgument(this.txtArgument2x3.Text.Trim());
                if (this.txtArgument2x4.Text.Trim().Length != 0)
                    oCommand.AddArgument(this.txtArgument2x4.Text.Trim());

                if (txtParamName2x1.Text.Trim().Length != 0)
                {
                    if (txtParamValue2x1.Text.Trim().Length != 0)
                        oCommand.AddParameter(txtParamName2x1.Text.Trim(), txtParamValue2x1.Text.Trim());
                    else
                        oCommand.AddParameter(txtParamName2x1.Text.Trim());
                }

                if (txtParamName2x2.Text.Trim().Length != 0)
                {
                    if (txtParamValue2x2.Text.Trim().Length != 0)
                        oCommand.AddParameter(txtParamName2x2.Text.Trim(), txtParamValue2x2.Text.Trim());
                    else
                        oCommand.AddParameter(txtParamName2x2.Text.Trim());
                }

                if (txtParamName2x3.Text.Trim().Length != 0)
                {
                    if (txtParamValue2x3.Text.Trim().Length != 0)
                        oCommand.AddParameter(txtParamName2x3.Text.Trim(), txtParamValue2x3.Text.Trim());
                    else
                        oCommand.AddParameter(txtParamName2x3.Text.Trim());
                }

            }

            // Script 2 ------------------------------------

            if (chkScript2.Checked == true)
            {
                oCommand.Commands.AddScript(txtScript2.Text.Trim(), chkScript2UseLocalScope.Checked);

                if (this.Script2Arg1.Text.Trim().Length != 0)
                    oCommand.AddArgument(this.Script2Arg1.Text.Trim());
                if (this.Script2Arg2.Text.Trim().Length != 0)
                    oCommand.AddArgument(this.Script2Arg2.Text.Trim());
                if (this.Script2Arg3.Text.Trim().Length != 0)
                    oCommand.AddArgument(this.Script2Arg3.Text.Trim());
                if (this.Script2Arg4.Text.Trim().Length != 0)
                    oCommand.AddArgument(this.Script2Arg4.Text.Trim());
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

        private void GetAuthenticationMechanism(string sAuthMethod, ref AuthenticationMechanism oAuthenticationMechanism, ref bool bSpecifyCredentials)
        {


            switch (cmboAuthentication.Text)
            {
                case "Basic":
                    bSpecifyCredentials = true;
                    oAuthenticationMechanism = AuthenticationMechanism.Basic;
                    break;
                case "Credssp":
                    bSpecifyCredentials = true;
                    oAuthenticationMechanism = AuthenticationMechanism.Credssp;
                    break;
                case "Default":
                    bSpecifyCredentials = false;
                    oAuthenticationMechanism = AuthenticationMechanism.Default;
                    break;
                case "Digest":
                    bSpecifyCredentials = true;
                    oAuthenticationMechanism = AuthenticationMechanism.Digest;
                    break;
                case "Kerberos":
                    bSpecifyCredentials = false;
                    oAuthenticationMechanism = AuthenticationMechanism.Kerberos;
                    break;
                case "Negotiate":
                    bSpecifyCredentials = true;
                    oAuthenticationMechanism = AuthenticationMechanism.Negotiate;
                    break;
                case "NegotiateWithImplicitCredential":
                    bSpecifyCredentials = false;
                    oAuthenticationMechanism = AuthenticationMechanism.NegotiateWithImplicitCredential;
                    break;
            }
        }

        private void SetUpInputVariables(ref CommandCollection oCommandCollection)
        {



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

        //private static SecureString String2SecureString(string password)
        //{
        //    SecureString remotePassword = new SecureString();
        //    for (int i = 0; i < password.Length; i++)
        //        remotePassword.AppendChar(password[i]);

        //    return remotePassword;
        //}

        //private void groupBox1_Enter(object sender, EventArgs e)
        //{

        //}



        //private void GetAuthenticationMechanism(string sAuthMethod, ref AuthenticationMechanism oAuthenticationMechanism, ref bool bSpecifyCredentials)
        //{


        //    switch (cmboAuthentication.Text)
        //    {
        //        case "Basic":
        //            bSpecifyCredentials = true;
        //            oAuthenticationMechanism = AuthenticationMechanism.Basic;
        //            break;
        //        case "Credssp":
        //            bSpecifyCredentials = true;
        //            oAuthenticationMechanism = AuthenticationMechanism.Credssp;
        //            break;
        //        case "Default":
        //            bSpecifyCredentials = false;
        //            oAuthenticationMechanism = AuthenticationMechanism.Default;
        //            break;
        //        case "Digest":
        //            bSpecifyCredentials = true;
        //            oAuthenticationMechanism = AuthenticationMechanism.Digest;
        //            break;
        //        case "Kerberos":
        //            bSpecifyCredentials = false;
        //            oAuthenticationMechanism = AuthenticationMechanism.Kerberos;
        //            break;
        //        case "Negotiate":
        //            bSpecifyCredentials = true;
        //            oAuthenticationMechanism = AuthenticationMechanism.Negotiate;
        //            break;
        //        case "NegotiateWithImplicitCredential":
        //            bSpecifyCredentials = false;
        //            oAuthenticationMechanism = AuthenticationMechanism.NegotiateWithImplicitCredential;
        //            break;
        //    }
        //}

        //private void SetUpInputVariables(ref CommandCollection oCommandCollection)
        //{



        //}


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
    }
}

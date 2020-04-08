using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EWSEditor.Forms;
using EWSEditor.Common;
using EWSEditor.RemotePowerShell;

namespace EWSEditor.RemotePowerShell
{

    public class PsTestSettings
    {
        public string FormDataFilePath = string.Empty;
        public TestSettingsData SettingsData = null;

        public PsTestSettings()
        {
            FormDataFilePath = System.Windows.Forms.Application.UserAppDataPath;
            SettingsData = new TestSettingsData();
        }


        public class TestSettingsData
        {
            public string AppVersion = string.Empty;

            public bool UseWSManConnectionInfo = true;
            public bool UseNewPSSession = false;
            public bool rdoUseLocal = false;

            public string ShellUri = string.Empty;
            public string Server = string.Empty;
            public string URI = string.Empty;
            public string Authentication = string.Empty;
            public string User = string.Empty;
            public string Password = string.Empty;
            public bool SkipCNCheck = false;
            public bool SkipCACheck = false;
            public bool SkipRevocationCheck = false;

            public string VarName1 = string.Empty;
            public string VarValue1 = string.Empty;
            public string VarName2 = string.Empty;
            public string VarValue2 = string.Empty;
            public string VarName3 = string.Empty;
            public string VarValue3 = string.Empty;

            public string VarName1Output = string.Empty;
            public string VarName2Output = string.Empty;
            public string VarName3Output = string.Empty;
            public string VarName4Output = string.Empty;


            public bool Command1Selected = false;
            public string CommandText1 = string.Empty;
            public string Argument1x1 = string.Empty;
            public string Argument1x2 = string.Empty;
            public string Argument1x3 = string.Empty;
            public string Argument1x4 = string.Empty;
            public string ParamName1x1 = string.Empty;
            public string ParamValue1x1 = string.Empty;
            public string ParamName1x2 = string.Empty;
            public string ParamValue1x2 = string.Empty;
            public string ParamName1x3 = string.Empty;
            public string ParamValue1x3 = string.Empty;
            public string ParamName1x4 = string.Empty;
            public string ParamValue1x4 = string.Empty;
            public string ParamName1x5 = string.Empty;
            public string ParamValue1x5 = string.Empty;
            public string ParamName1x6 = string.Empty;
            public string ParamValue1x6 = string.Empty;

            public bool Script1Selected = false;
            public string Script1 = string.Empty;
            public string Script1Arg1 = string.Empty;
            public string Script1Arg2 = string.Empty;
            public string Script1Arg3 = string.Empty;
            public string Script1Arg4 = string.Empty;

            public bool Command2Selected = false;
            public string CommandText2 = string.Empty;
            public string Argument2x1 = string.Empty;
            public string Argument2x2 = string.Empty;
            public string Argument2x3 = string.Empty;
            public string Argument2x4 = string.Empty;
            public string ParamName2x1 = string.Empty;
            public string ParamValue2x1 = string.Empty;
            public string ParamName2x2 = string.Empty;
            public string ParamValue2x2 = string.Empty;
            public string ParamName2x3 = string.Empty;
            public string ParamValue2x3 = string.Empty;
            public string ParamName2x4 = string.Empty;
            public string ParamValue2x4 = string.Empty;
            public string ParamName2x5 = string.Empty;
            public string ParamValue2x5 = string.Empty;
            public string ParamName2x6 = string.Empty;
            public string ParamValue2x6 = string.Empty;


            public bool Script2Selected = false;
            public string Script2 = string.Empty;
            public string Script2Arg1 = string.Empty;
            public string Script2Arg2 = string.Empty;
            public string Script2Arg3 = string.Empty;
            public string Script2Arg4 = string.Empty;


            public bool FromPipelineSelected = false;
            public string FromPipeline = string.Empty;

            public bool ExecuteWithPipeline = false;
            public bool Script1UseLocalScope = false;
            public bool Script2UseLocalScope = false;

        }

        public void ClearSettings()
        {
            SettingsData.AppVersion = string.Empty;

            SettingsData.UseWSManConnectionInfo = true;
            SettingsData.UseNewPSSession = false;
            SettingsData.rdoUseLocal = false;


            SettingsData.ShellUri = string.Empty;
            SettingsData.Server = string.Empty;
            SettingsData.URI = string.Empty;
            SettingsData.Authentication = string.Empty;
            SettingsData.User = string.Empty;
            SettingsData.Password = string.Empty;
            SettingsData.SkipCNCheck = false;
            SettingsData.SkipCACheck = false;
            SettingsData.SkipRevocationCheck = false;

            SettingsData.VarName1 = string.Empty;
            SettingsData.VarValue1 = string.Empty;
            SettingsData.VarName2 = string.Empty;
            SettingsData.VarValue2 = string.Empty;
            SettingsData.VarName3 = string.Empty;
            SettingsData.VarValue3 = string.Empty;

            SettingsData.VarName1Output = string.Empty;
            SettingsData.VarName2Output = string.Empty;
            SettingsData.VarName3Output = string.Empty;
            SettingsData.VarName4Output = string.Empty;

            SettingsData.Command1Selected = false;
            SettingsData.CommandText1 = string.Empty;
            SettingsData.Argument1x1 = string.Empty;
            SettingsData.Argument1x2 = string.Empty;
            SettingsData.Argument1x3 = string.Empty;
            SettingsData.Argument1x4 = string.Empty;
            SettingsData.ParamName1x1 = string.Empty;
            SettingsData.ParamValue1x1 = string.Empty;
            SettingsData.ParamName1x2 = string.Empty;
            SettingsData.ParamValue1x2 = string.Empty;
            SettingsData.ParamName1x3 = string.Empty;
            SettingsData.ParamValue1x3 = string.Empty;
            SettingsData.ParamName1x4 = string.Empty;
            SettingsData.ParamValue1x4 = string.Empty;
            SettingsData.ParamName1x5 = string.Empty;
            SettingsData.ParamValue1x5 = string.Empty;
            SettingsData.ParamName1x6 = string.Empty;
            SettingsData.ParamValue1x6 = string.Empty;

            SettingsData.Script1Selected = false;
            SettingsData.Script1 = string.Empty;
            SettingsData.Script1Arg1 = string.Empty;
            SettingsData.Script1Arg2 = string.Empty;
            SettingsData.Script1Arg3 = string.Empty;
            SettingsData.Script1Arg4 = string.Empty;

            SettingsData.Command2Selected = false;
            SettingsData.CommandText2 = string.Empty;
            SettingsData.Argument2x1 = string.Empty;
            SettingsData.Argument2x2 = string.Empty;
            SettingsData.Argument2x3 = string.Empty;
            SettingsData.Argument2x4 = string.Empty;
            SettingsData.ParamName2x1 = string.Empty;
            SettingsData.ParamValue2x1 = string.Empty;
            SettingsData.ParamName2x2 = string.Empty;
            SettingsData.ParamValue2x2 = string.Empty;
            SettingsData.ParamName2x3 = string.Empty;
            SettingsData.ParamValue2x3 = string.Empty;
            SettingsData.ParamName2x4 = string.Empty;
            SettingsData.ParamValue2x4 = string.Empty;
            SettingsData.ParamName2x5 = string.Empty;
            SettingsData.ParamValue2x5 = string.Empty;
            SettingsData.ParamName2x6 = string.Empty;
            SettingsData.ParamValue2x6 = string.Empty;


            SettingsData.Script2Selected = false;
            SettingsData.Script2 = string.Empty;
            SettingsData.Script2Arg1 = string.Empty;
            SettingsData.Script2Arg2 = string.Empty;
            SettingsData.Script2Arg3 = string.Empty;
            SettingsData.Script2Arg4 = string.Empty;


            SettingsData.ExecuteWithPipeline = false;
            SettingsData.Script1UseLocalScope = false;
            SettingsData.Script2UseLocalScope = false;
        }



        public bool SaveSettingsToFile()  // TestingForm oTestingForm)
        {
            bool bRet = false;
            string sFile = string.Empty;
            string sConnectionSettings = string.Empty;

            //SetDataFromForm(oTestingForm);

            if (UserIoHelper.PickSaveFileToFolder(FormDataFilePath, "Connection Settings " + TimeHelper.NowMashup() + ".xml", ref sFile, "XML files (*.xml)|*.xml"))
            {
                sConnectionSettings = SerialHelper.SerializeObjectToString<TestSettingsData>(SettingsData);
                if (sConnectionSettings != string.Empty)
                {
                    try
                    {
                        System.IO.File.WriteAllText(sFile, sConnectionSettings);
                        bRet = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Saving File");
                    }
                }
            }
            return bRet;

        }

        public bool LoadSettingFromFile() //ref TestingForm oTestingForm)
        {
            bool bRet = false;
            string sFile = string.Empty;
            string sConnectionSettings = string.Empty;
            //TestSettingsData oTestSettingsData = null;
            this.ClearSettings();
            string sFileContents = string.Empty;

            if (UserIoHelper.PickLoadFromFile(FormDataFilePath, "*.xml", ref sFile, "XML files (*.xml)|*.xml"))
            {
                try
                {
                    sFileContents = System.IO.File.ReadAllText(sFile);
                    SettingsData = SerialHelper.DeserializeObjectFromString<TestSettingsData>(sFileContents);
                    //SetFormFromData(ref oTestingForm);
                    bRet = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Saving File");
                }

            }
            //oTestSettingsData = null;
            return bRet;
        }
    }
}

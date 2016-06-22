using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using EWSEditor.Common.UIHelpers;
 
using EWSEditor.Forms;
using EWSEditor.Forms.Controls;
using EWSEditor.Logging;
using EWSEditor.Common;
using EWSEditor.Forms.Dialogs;

// http://converter.telerik.com/

namespace EWSEditor
{
    public partial class MimeParserForm : Form
    {
        CDO.Message objCDOMsg;
        bool bLoaded = false;

        string m_MessageMime = "";


        public MimeParserForm()
        {
            InitializeComponent();
        }

        private void MimeParser_Load(object sender, EventArgs e)
        {

        }

        public string MessageMime
        {
            get { return m_MessageMime; }
            set
            {
                m_MessageMime = value;
                LoadMimeString(m_MessageMime);
            }
        }

        public bool LoadMimeString(string sMime)
        {
            bool bRet = false;
            txtFileName.Text = "";
            txtFileName.Enabled = false;
            cmdBrowse.Visible = false;
            cmdLoad.Visible = false;
          
            bRet = LoadMessage("string", sMime);
            if (bRet == true)
            {
                StatusBar1.Text = "Loaded";
            }
            return bRet;
        }

        public bool LoadMimeString(string sMime, string sRefPath)
        {
            bool bRet = false;
            txtFileName.Text = sRefPath;
            txtFileName.Enabled = false;
            cmdBrowse.Visible = false;
            cmdLoad.Visible = false;

            bRet = LoadMessage("string", sMime);
            if (bRet == true)
            {
                StatusBar1.Text = "Loaded";
            }
            return bRet;
        }

        public bool LoadMimeFile(string sFile)
        {
            bool bRet = false;
            txtFileName.Text = sFile;
            txtFileName.Enabled = true;
            cmdBrowse.Visible = true;
            cmdLoad.Visible = true;
            bRet = LoadMessage("file", sFile);
            if (bRet == true)
            {
                StatusBar1.Text = "Loaded";
            }
            return bRet;
        }


     private bool LoadMessage(string sLoadType, string sMessage)
	 {
		ADODB.Stream objMsgStream = new ADODB.Stream();
		string sFileName = "";
		objCDOMsg = null;
		objCDOMsg = new CDO.Message();
		bLoaded = false;

		try {
			this.Cursor = Cursors.WaitCursor;


			// First Get the Raw Mime and display it.
			string sFileText = null;
			if (sLoadType == "file") {
				//MyApp.AppUtil xObj = new MyApp.AppUtil();
				sFileName = txtFileName.Text.Trim();
				sFileText = UserIoHelper.GetFileAsString(sFileName);

                 
				txtMime.Text = sFileText;
 

				// Now Lets read this thing
				objMsgStream.Open();
				objMsgStream.LoadFromFile(sFileName);
				objCDOMsg.BodyPart.DataSource.OpenObject(objMsgStream, "IStream");
				m_MessageMime = sFileText;
			} else {
				sFileName = Path.GetTempFileName();
				txtMime.Text = sMessage;

				 
				UserIoHelper.SaveStringAsFile(sMessage, sFileName);
			 
				// Ran into problems writing mime text to a message, working around by using a temp file
				objMsgStream.Open();
				objMsgStream.LoadFromFile(sFileName);
				// Read temp file

				objCDOMsg.BodyPart.DataSource.OpenObject(objMsgStream, "IStream");
				// read it
				File.Delete(sFileName);
				// Get rid of temp file
				m_MessageMime = sMessage;
			}

			LoadMessageFields();
			LoadAttachemntsFields();
			ExtractBodyPart(objCDOMsg.BodyPart);
			// Messag Body

		} catch (Exception ex) {
			bLoaded = false;
			 MessageBox.Show("Error Loading File: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		try {
			System.Windows.Forms.TreeNode pNode = new System.Windows.Forms.TreeNode();
			TreeView1.Nodes.Clear();
			pNode = TreeView1.Nodes.Add("Root");
			// m_BaseURI
			pNode.Tag = objCDOMsg.BodyPart;

 

			int iBodyPartCount = 1;
			int iBodyPartCount2 = 1;
			int iBodyPartCount3 = 1;
			int iBodyPartCount4 = 1;
			int iBodyPartCount5 = 1;
			int iBodyPartCount6 = 1;
			int iBodyPartCount7 = 1;

			System.Windows.Forms.TreeNode aNode = null;
			System.Windows.Forms.TreeNode aNode2 = null;
			System.Windows.Forms.TreeNode aNode3 = null;
			System.Windows.Forms.TreeNode aNode4 = null;
			System.Windows.Forms.TreeNode aNode5 = null;
			System.Windows.Forms.TreeNode aNode6 = null;
			System.Windows.Forms.TreeNode aNode7 = null;

			iBodyPartCount = 1;
			// Note: I'm using this big loop because i want to be able to see things better
			// as this code loops through each body part.  Using a recursive call to a method
			// just makes the debugging process more difficult.
			foreach (CDO.IBodyPart objBodypart in objCDOMsg.BodyPart.BodyParts) {
				AddNode(objBodypart, ref pNode, ref aNode, iBodyPartCount);

				iBodyPartCount2 = 1;
				foreach (CDO.IBodyPart objBodypart2 in objBodypart.BodyParts) {
					AddNode(objBodypart2, ref aNode, ref aNode2, iBodyPartCount2);
					iBodyPartCount3 = 1;
					foreach (CDO.IBodyPart objBodypart3 in objBodypart2.BodyParts) {
						AddNode(objBodypart3, ref aNode2, ref aNode3, iBodyPartCount3);
						iBodyPartCount4 = 1;
						foreach (CDO.IBodyPart objBodypart4 in objBodypart3.BodyParts) {
							AddNode(objBodypart4, ref aNode3, ref aNode4, iBodyPartCount4);
							iBodyPartCount5 = 1;
							foreach (CDO.IBodyPart objBodypart5 in objBodypart4.BodyParts) {
								AddNode(objBodypart5, ref aNode4, ref aNode5, iBodyPartCount5);
								iBodyPartCount6 = 1;
								foreach (CDO.IBodyPart objBodypart6 in objBodypart5.BodyParts) {
									AddNode(objBodypart6, ref aNode5, ref aNode6, iBodyPartCount6);
									iBodyPartCount7 = 1;
                                    foreach (CDO.IBodyPart objBodypart7 in objBodypart6.BodyParts)
                                    {
										AddNode(objBodypart7, ref aNode6, ref aNode7, iBodyPartCount7);
										iBodyPartCount7 += 1;
									}
									iBodyPartCount6 += 1;
								}
								iBodyPartCount5 += 1;
							}
							iBodyPartCount4 += 1;
						}
						iBodyPartCount3 += 1;
					}
					iBodyPartCount2 += 1;
				}
				iBodyPartCount += 1;
			}
			pNode.ExpandAll();

			bLoaded = true;
		} catch (Exception ex) {
			bLoaded = false;
			MessageBox.Show("Error Loading Message Body Parts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

		}

		objMsgStream = null;
		Cursor = Cursors.Default;
		return bLoaded;
	}

        private bool AddNode(CDO.IBodyPart aBodyPart, ref System.Windows.Forms.TreeNode pNode, ref System.Windows.Forms.TreeNode aNewNode, int iCount)
        {
            bool bReturn = false;
            aNewNode = new System.Windows.Forms.TreeNode();
            string sText = "";

            if (aBodyPart.FileName.Trim().Length != 0)
            {
                sText = "(" + aBodyPart.FileName.ToString() + ")";
            }

            aNewNode.Text = (sText + "" + pNode.Text + "." + iCount.ToString() + "");
            aNewNode.Tag = aBodyPart;

            aNewNode.ImageIndex = 0;
            aNewNode.SelectedImageIndex = 0;

            pNode.Nodes.Add(aNewNode);
            return bReturn;

        }


        private void LoadMessageFields()
	{
		//ADODB.Field objField = default(ADODB.Field);
        //ADODB.Field objField = null;
		ListViewItem aListItem = default(ListViewItem);
		ListView1.Items.Clear();
		ListView1.View = View.Details;
		// Set the view to show details.
		ListView1.GridLines = true;
		// Display grid lines.
		string sValue = null;

        //ADODB.Field objField = null;
		foreach (ADODB.Field objField in objCDOMsg.Fields) {
			aListItem = new ListViewItem(objField.Name);
			//aListItem.Tag = anInstance.href
			try {
				sValue = objField.ToString();
				aListItem.SubItems.Add(sValue);
			} catch (Exception ex) {
				sValue = "(Cannot Extract - may not be set)";
				aListItem.SubItems.Add(sValue);
			}

			ListView1.Items.AddRange(new ListViewItem[] { aListItem });
			aListItem = null;
		}
	}

        //LoadMessageEnvelopeFields()
        //lvAttachments
        private void LoadAttachemntsFields()
	{
		 
		ListViewItem aListItem = default(ListViewItem);
		lvAttachments.Items.Clear();
		lvAttachments.View = View.Details;
		// Set the view to show details.
		lvAttachments.GridLines = true;
		// Display grid lines.
		//Dim sValue As String


        foreach (CDO.IBodyPart iBP in objCDOMsg.Attachments)
        {
			aListItem = new ListViewItem(iBP.FileName);

			if (iBP.ContentMediaType != null) {
				aListItem.SubItems.Add(iBP.ContentMediaType);
			} else {
				aListItem.SubItems.Add("");
			}
			if (iBP.ContentTransferEncoding != null) {
				aListItem.SubItems.Add(iBP.ContentTransferEncoding);
			} else {
				aListItem.SubItems.Add("");
			}
			if (iBP.Charset != null) {
				aListItem.SubItems.Add(iBP.Charset);
			} else {
				aListItem.SubItems.Add("");
			}
			if (iBP.ContentClass != null) {
				aListItem.SubItems.Add(iBP.ContentClass);
			} else {
				aListItem.SubItems.Add("");
			}
			if (iBP.ContentClass != null) {
				aListItem.SubItems.Add(iBP.ContentClassName);
			} else {
				aListItem.SubItems.Add("");
			}


			lvAttachments.Items.AddRange(new ListViewItem[] { aListItem });
			aListItem = null;
		}
	}
        private void ExtractBodyPart(CDO.IBodyPart iBP)
	{
		string sText = null;
		ADODB.Stream aStream = default(ADODB.Stream);

		// Get Encoded Stream
		try {
			aStream = iBP.GetEncodedContentStream();
			sText = aStream.ReadText();
			aStream.Close();
			txtEncoded.Text = sText;
			txtStream.BackColor = Color.White;
		} catch (Exception ex) {
			txtEncoded.Text = "";
			txtStream.BackColor = Color.Gray;
		}

		// Get Decoded Stream
		try {
			aStream = iBP.GetDecodedContentStream();
			sText = aStream.ReadText();
			aStream.Close();
			txtDecoded.Text = sText;
			txtStream.BackColor = Color.White;
		} catch (Exception ex) {
			txtDecoded.Text = "";
			txtStream.BackColor = Color.Gray;
		}

		// Get Stream
		try {
			aStream = iBP.GetStream();
			sText = aStream.ReadText();
			aStream.Close();
			txtStream.Text = sText;
			txtStream.BackColor = Color.White;
		} catch (Exception ex) {
			txtStream.Text = "";
			txtStream.BackColor =Color.Gray;
		}

		ListViewItem aListItem = default(ListViewItem);
		ListView1.Items.Clear();
		ListView1.View = View.Details;
		// Set the view to show details.
		ListView1.GridLines = true;
		// Display grid lines.
		string sValue = null;

		// Extract Bodypart Fields
	 
        foreach (ADODB.Field objField in iBP.Fields)
        {
			aListItem = new ListViewItem(objField.Name);
			//aListItem.Tag = anInstance.href
			try {
				sValue = objField.ToString();
                sValue = objField.Value as string;
				aListItem.SubItems.Add(sValue);
			} catch (Exception ex) {
				sValue = "(Cannot Extract - may not be set)";
				aListItem.SubItems.Add(sValue);
			}
			ListView1.Items.AddRange(new ListViewItem[] { aListItem });
			aListItem = null;
		}

		// ---- Body Part Properties --------------------------------
		ListView2.Items.Clear();
		ListView2.View = View.Details;
		// Set the view to show details.
		ListView2.GridLines = true;
		// Display grid lines.
		if (iBP.Charset != null) {
			AddLvItem(ref ListView2, "Charset", iBP.Charset);
		}
		if (iBP.ContentClass != null) {
			AddLvItem(ref ListView2, "ContentClass", iBP.ContentClass);
		}
		if (iBP.ContentMediaType != null) {
			AddLvItem(ref ListView2, "ContentMediaType", iBP.ContentMediaType);
		}
		if (iBP.ContentTransferEncoding != null) {
			AddLvItem(ref ListView2, "ContentTransferEncoding", iBP.ContentTransferEncoding);
		}
		if (iBP.FileName != null) {
			AddLvItem(ref ListView2, "FileName", iBP.FileName);
		}
		AddLvItem(ref ListView2, "BodyParts.Count", iBP.BodyParts.Count);
		aStream = null;
	}


        private void AddLvItem(ref ListView aListView, string sName, int iValue)
        {
            AddLvItem(ref aListView, sName, iValue.ToString());
        }
        private void AddLvItem(ref ListView aListView, string sName, string sValue)
        {
            ListViewItem aListItem = default(ListViewItem);

            aListItem = new ListViewItem(sName);
 
            aListItem.SubItems.Add(sValue);
            aListView.Items.AddRange(new ListViewItem[] { aListItem });

        }

        private void SaveBodyPart(ADODB.Stream aStream, string sFileName)
        {

            //Dim sr As StreamWriter
            //Dim sFileBody As String
            string sDataPath = "c:\\";
            string sUseFilename = null;
            SaveFileDialog saveFileDialog1 = default(SaveFileDialog);
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = sDataPath;
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = false;

            saveFileDialog1.FileName = sFileName;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sUseFilename = saveFileDialog1.FileName;
                saveFileDialog1 = null;

                try
                {
                    Cursor = Cursors.WaitCursor;
                    aStream.SaveToFile(sUseFilename);
                    Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Cannot write to file.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void cmdLoad_Click(System.Object sender, System.EventArgs e)
        {
            bool bRet = false;
            if ((File.Exists(txtFileName.Text.Trim()) == false))
            {
                MessageBox.Show("The file does not exist.", "Error",  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                StatusBar1.Text = "Not Loaded";
                bRet = LoadMessage("file", txtFileName.Text.Trim());
                if (bRet == true)
                {
                    StatusBar1.Text = "Loaded";
                }
            }
        }

        private void TreeView1_AfterSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
         
        }

        private void cmsMime_SelectAll_Click(object sender, EventArgs e)
        {
            txtMime.SelectAll();
        }

        private void cmsMime_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cmsBPDecStream_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cmsBPStream_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            //Dim myStream As Stream
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
        

            string sDataPath = null;
            sDataPath = txtFileName.Text.ToString();
            //Application.LocalUserAppDataPath() & "\Data"


            openFileDialog1.InitialDirectory = sDataPath;
            openFileDialog1.Filter = "eml files (*.eml)|*.eml |txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt |All files (*.*)|*.*"
            openFileDialog1.FilterIndex = 3;

            bLoaded = false;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Insert code to read the stream here.
                txtFileName.Text = openFileDialog1.FileName;
                bLoaded = true;

            }

        }

        private void lvAttachments_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.lvAttachments.ListViewItemSorter = new EWSEditor.Common.UIHelpers.ListViewItemComparer(e.Column);
            lvAttachments.Sort();
        }

        private void ListView2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.ListView2.ListViewItemSorter = new EWSEditor.Common.UIHelpers.ListViewItemComparer(e.Column);
            ListView2.Sort();
        }

        private void cmsMime_Copy_Click(object sender, EventArgs e)
        {
            TextEdit.RichText.CopySelection(ref txtMime );
        }

        private void cmsBPStream_Copy_Click(object sender, EventArgs e)
        {
            TextEdit.RichText.CopySelection(ref txtStream);
        }

        private void cmsBPDecStream_Copy_Click(object sender, EventArgs e)
        {
            TextEdit.RichText.CopySelection(ref txtDecoded);
        }

        private void cmdLoad_Click_1(object sender, EventArgs e)
        {
            bool bRet = false;
            if ((File.Exists(txtFileName.Text.Trim()) == false))
            {
                MessageBox.Show("The file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                StatusBar1.Text = "Not Loaded";
                bRet = LoadMessage("file", txtFileName.Text.Trim());
                if (bRet == true)
                {
                    StatusBar1.Text = "Loaded";
                }
            }

        }

        private void CmBpTree_Popup(object sender, EventArgs e)
        {
            TextEdit.RichText.CopySelection(ref txtStream);
        }

        private void cmsBPStream_SelectAll_Click(object sender, EventArgs e)
        {
            txtStream.SelectAll();
        }

        private void cmsBPEncStream_Copy_Click(object sender, EventArgs e)
        {
            TextEdit.RichText.CopySelection(ref txtEncoded);
        }

        private void cmsBPEncStream_SelectAll_Click(object sender, EventArgs e)
        {
            txtEncoded.SelectAll();
        }

        private void cmsBPDecStream_SelectAll_Click(object sender, EventArgs e)
        {
            txtDecoded.SelectAll();
        }

        private void mnuSaveBodyPartToFile_Click(object sender, EventArgs e)
        {
            if ((TreeView1.SelectedNode != null))
            {
                CDO.IBodyPart aBP = default(CDO.IBodyPart);
                aBP = (CDO.IBodyPart)TreeView1.SelectedNode.Tag;

                //Dim aStream As ADODB.Stream
                string sFilename = null;
                string sUseFilename = "";
                string sDatapath = "c:\\";

                SaveFileDialog saveFileDialog1 = default(SaveFileDialog);
                saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = sDatapath;
                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";


                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = false;

                sFilename = aBP.FileName;
                if (string.IsNullOrEmpty(sFilename))
                {
                    sFilename = "BodyPart (" + TreeView1.SelectedNode.Text + ").txt";
                }
                else
                {
                    sFilename = "BodyPart - " + sFilename;
                }

                saveFileDialog1.FileName = sFilename;
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    sUseFilename = saveFileDialog1.FileName;
                    saveFileDialog1 = null;
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        aBP.SaveToFile(sUseFilename);
                        Cursor = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Saving Bodypart " + ex.ToString());
                    }
                }
            }
            Cursor = Cursors.Default;
        }

        private void mnuSaveEncodedBodyPartToFile_Click(object sender, EventArgs e)
        {
            //    if ((TreeView1.SelectedNode != null))
            //    {
            //        CDO.IBodyPart aBP = default(CDO.IBodyPart);
            //        aBP = (CDO.IBodyPart)TreeView1.SelectedNode.Tag;

            //        //Dim aStream As ADODB.Stream
            //        string sFilename = null;
            //        string sUseFilename = "";
            //        string sDatapath = "c:\\";

            //        SaveFileDialog saveFileDialog1 = default(SaveFileDialog);
            //        saveFileDialog1 = new SaveFileDialog();
            //        saveFileDialog1.InitialDirectory = sDatapath;
            //        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";


            //        saveFileDialog1.FilterIndex = 2;
            //        saveFileDialog1.RestoreDirectory = false;

            //        sFilename = aBP.FileName;
            //        if (string.IsNullOrEmpty(sFilename))
            //        {
            //            sFilename = "BodyPart (" + TreeView1.SelectedNode.Text + ").txt";
            //        }
            //        else
            //        {
            //            sFilename = "BodyPart - " + sFilename;
            //        }

            //        saveFileDialog1.FileName = sFilename;
            //        if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //        {
            //            sUseFilename = saveFileDialog1.FileName;
            //            saveFileDialog1 = null;
            //            try
            //            {
            //                Cursor = Cursors.WaitCursor;
            //                aBP.SaveToFile(sUseFilename);
            //                Cursor = Cursors.Default;
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show("Error Saving Bodypart " + ex.ToString);
            //            }
            //        }
            //    }
            //    Cursor = Cursors.Default;
        }

        private void mnuSaveDecodedBodyPartToFile_Click(object sender, EventArgs e)
        {
            if ((TreeView1.SelectedNode != null))
            {
                CDO.IBodyPart aBP = default(CDO.IBodyPart);
                Cursor = Cursors.WaitCursor;
                aBP = (CDO.IBodyPart)TreeView1.SelectedNode.Tag;

                ADODB.Stream aStream = default(ADODB.Stream);
                string sFilename = null;
                bool bGotStream = false;
                aStream = new ADODB.Stream();
                try
                {
                    aStream = aBP.GetDecodedContentStream();
                    bGotStream = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Extracting stream: " + ex.Message);
                }
                if (bGotStream == true)
                {
                    sFilename = aBP.FileName;
                    if (string.IsNullOrEmpty(sFilename))
                    {
                        sFilename = "DecodedBodyPart (" + TreeView1.SelectedNode.Text + ").txt";
                    }
                    else
                    {
                        sFilename = "DecodedBodyPart - " + sFilename;
                    }
                    SaveBodyPart(aStream, sFilename);
                }
                Cursor = Cursors.Default;
            }
        }

        private void mnuSaveBodyPartStreamToFile_Click(object sender, EventArgs e)
        {
            if ((TreeView1.SelectedNode != null))
            {
                CDO.IBodyPart aBP = default(CDO.IBodyPart);
                Cursor = Cursors.WaitCursor;
                aBP = (CDO.IBodyPart)TreeView1.SelectedNode.Tag;

                ADODB.Stream aStream = default(ADODB.Stream);
                string sFilename = null;
                bool bGotStream = false;
                aStream = new ADODB.Stream();
                try
                {
                    aStream = aBP.GetStream();
                    bGotStream = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Extracting stream: " + ex.Message);
                }
                if (bGotStream == true)
                {
                    sFilename = aBP.FileName;
                    if (string.IsNullOrEmpty(sFilename))
                    {
                        sFilename = "BodyPartStream (" + TreeView1.SelectedNode.Text + ").txt";
                    }
                    else
                    {
                        sFilename = "BodyPartStream - " + sFilename;
                    }
                    Cursor = Cursors.WaitCursor;
                    SaveBodyPart(aStream, sFilename);
                    Cursor = Cursors.Default;
                }
                Cursor = Cursors.Default;
            }
        }

        private void TreeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            if (bLoaded == true)
            {
                Cursor = Cursors.WaitCursor;

                if ((e.Node.Tag != null))
                {
                    CDO.IBodyPart aBP = default(CDO.IBodyPart);
                    aBP = (CDO.IBodyPart)e.Node.Tag;
                    if (aBP == null)
                    {
                        ExtractBodyPart(objCDOMsg.BodyPart);
                        // Messag Body
                    }
                    else
                    {
                        ExtractBodyPart(aBP);
                        // Body Part
                    }
                }
                else
                {
                    StatusBar1.Panels[0].Text = " ";
                }
                Cursor = Cursors.Default;
            }
        }

        private void btnLoadTextEntry_Click(object sender, EventArgs e)
        {
            string sEntry = "";
            EWSEditor.Forms.Dialogs.EnterTextForm oForm = new EnterTextForm(sEntry);
            oForm.ShowDialog();
            if (oForm.ChoseOK == true)
            {
                bool bRet = false;
                StatusBar1.Text = "Not Loaded";
                bRet = LoadMessage("string", oForm.UserTextEntry);
                if (bRet == true)
                    StatusBar1.Text = "Loaded";
                else
                    StatusBar1.Text = "Not Loaded";
            }

        }

        private void txtMime_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void mnuSaveBodyPartToFile_Click(System.Object sender, System.EventArgs e)
        //{
        
        //}


        //private void mnuSaveBodyPartStreamToFile_Click(System.Object sender, System.EventArgs e)
        //{
        //    if ((TreeView1.SelectedNode != null))
        //    {
        //        CDO.IBodyPart aBP = default(CDO.IBodyPart);
        //        Cursor = Cursors.WaitCursor;
        //        aBP = (CDO.IBodyPart)TreeView1.SelectedNode.Tag;

        //        ADODB.Stream aStream = default(ADODB.Stream);
        //        string sFilename = null;
        //        bool bGotStream = false;
        //        aStream = new ADODB.Stream();
        //        try
        //        {
        //            aStream = aBP.GetStream;
        //            bGotStream = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error Extracting stream: " + ex.Message);
        //        }
        //        if (bGotStream == true)
        //        {
        //            sFilename = aBP.FileName;
        //            if (string.IsNullOrEmpty(sFilename))
        //            {
        //                sFilename = "BodyPartStream (" + TreeView1.SelectedNode.Text + ").txt";
        //            }
        //            else
        //            {
        //                sFilename = "BodyPartStream - " + sFilename;
        //            }
        //            Cursor = Cursors.WaitCursor;
        //            SaveBodyPart(aStream, sFilename);
        //            Cursor = Cursors.Default;
        //        }
        //        Cursor = Cursors.Default;
        //    }
        //}

        //private void mnuSaveEncodedBodyPartToFile_Click(System.Object sender, System.EventArgs e)
        //{
        //    if ((TreeView1.SelectedNode != null))
        //    {
        //        CDO.IBodyPart aBP = default(CDO.IBodyPart);
        //        Cursor = Cursors.WaitCursor;
        //        aBP = (CDO.IBodyPart)TreeView1.SelectedNode.Tag;

        //        ADODB.Stream aStream = default(ADODB.Stream);
        //        string sFilename = null;
        //        bool bGotStream = false;
        //        aStream = new ADODB.Stream();
        //        try
        //        {
        //            aStream = aBP.GetEncodedContentStream;
        //            bGotStream = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error Extracting stream: " + ex.Message);
        //        }
        //        if (bGotStream == true)
        //        {
        //            sFilename = aBP.FileName;
        //            if (string.IsNullOrEmpty(sFilename))
        //            {
        //                sFilename = "EncodedBodyPart (" + TreeView1.SelectedNode.Text + ").txt";
        //            }
        //            else
        //            {
        //                sFilename = "EncodedBodyPart - " + sFilename;
        //            }
        //            SaveBodyPart(aStream, sFilename);
        //        }
        //        Cursor = Cursors.Default;
        //    }
        //}

        //private void mnuSaveDecodedBodyPartToFile_Click(System.Object sender, System.EventArgs e)
        //{
        //    if ((TreeView1.SelectedNode != null))
        //    {
        //        CDO.IBodyPart aBP = default(CDO.IBodyPart);
        //        Cursor = Cursors.WaitCursor;
        //        aBP = (CDO.IBodyPart)TreeView1.SelectedNode.Tag;

        //        ADODB.Stream aStream = default(ADODB.Stream);
        //        string sFilename = null;
        //        bool bGotStream = false;
        //        aStream = new ADODB.Stream();
        //        try
        //        {
        //            aStream = aBP.GetDecodedContentStream;
        //            bGotStream = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error Extracting stream: " + ex.Message);
        //        }
        //        if (bGotStream == true)
        //        {
        //            sFilename = aBP.FileName;
        //            if (string.IsNullOrEmpty(sFilename))
        //            {
        //                sFilename = "DecodedBodyPart (" + TreeView1.SelectedNode.Text + ").txt";
        //            }
        //            else
        //            {
        //                sFilename = "DecodedBodyPart - " + sFilename;
        //            }
        //            SaveBodyPart(aStream, sFilename);
        //        }
        //        Cursor = Cursors.Default;
        //    }
        //}

        
    //private void ListView2_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    //{
    //    this.ListView2.ListViewItemSorter = new MyApp.ListViewItemComparer(e.Column);
    //    ListView2.Sort();
    //}


    //private void ListView2_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    //{
    //}

    //private void cmsMime_Copy_Click(System.Object sender, System.EventArgs e)
    //{
    //    MyApp.TextEdit.RichText.CopySelection(txtMime);
    //}

    //private void cmsMime_Undo_Click(System.Object sender, System.EventArgs e)
    //{
    //    MyApp.TextEdit.RichText.Undo(txtMime);
    //}

    //private void cmsMime_Paste_Click(System.Object sender, System.EventArgs e)
    //{
    //    MyApp.TextEdit.RichText.PasteSelection(txtMime);
    //}

    //private void cmsMime_Cut_Click(System.Object sender, System.EventArgs e)
    //{
    //    MyApp.TextEdit.RichText.CutSelection(txtMime);
    //}

    //private void cmsMime_SelectAll_Click(System.Object sender, System.EventArgs e)
    //{
    //    txtMime.SelectAll();
    //}

    //private void cmsBPStream_SelectAll_Click(System.Object sender, System.EventArgs e)
    //{
    //    txtStream.SelectAll();
    //}

    //private void cmsBPStream_Copy_Click(System.Object sender, System.EventArgs e)
    //{
    //    MyApp.TextEdit.RichText.CopySelection(txtStream);
    //}

    //private void cmsBPEncStream_Copy_Click(System.Object sender, System.EventArgs e)
    //{
    //    MyApp.TextEdit.RichText.CopySelection(txtEncoded);
    //}

    //private void cmsBPEncStream_SelectAll_Click(System.Object sender, System.EventArgs e)
    //{
    //    txtEncoded.SelectAll();
    //}

    //private void cmsBPDecStream_Copy_Click(System.Object sender, System.EventArgs e)
    //{
    //    MyApp.TextEdit.RichText.CopySelection(txtDecoded);
    //}

    //private void cmsBPDecStream_SelectAll_Click(System.Object sender, System.EventArgs e)
    //{
    //    txtDecoded.SelectAll();
    //}
    //public Form1()
    //{
    //    Load += Form1_Load;
    //}



    }
}

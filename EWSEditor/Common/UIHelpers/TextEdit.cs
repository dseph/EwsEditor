using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace EWSEditor.Common.UIHelpers
{
    public class TextEdit
    {
        public class RichText
        {
            public static void CopySelection(ref System.Windows.Forms.RichTextBox oRichTextBox)
            {
                // Ensure that text is selected in the text box.   
                if (oRichTextBox.SelectionLength > 0)
                {
                    // Copy the selected text to the Clipboard.
                    oRichTextBox.Copy();
                }
            }

            public static void CutSelection(ref System.Windows.Forms.RichTextBox oRichTextBox)
            {
                // Ensure that text is currently selected in the text box.   
                if (!string.IsNullOrEmpty(oRichTextBox.SelectedText))
                {
                    // Cut the selected text in the control and paste it into the Clipboard.
                    oRichTextBox.Cut();
                }
            }

            public static void PasteSelection(ref System.Windows.Forms.RichTextBox oRichTextBox)
            {
                // Determine if there is any text in the Clipboard to paste into the text box.
                if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
                {
                    // Determine if any text is selected in the text box.
                    if (oRichTextBox.SelectionLength > 0)
                    {
                        // Ask user if they want to paste over currently selected text.
                        if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            // Move selection to the point after the current selection and paste.
                            oRichTextBox.SelectionStart = oRichTextBox.SelectionStart + oRichTextBox.SelectionLength;
                        }
                    }
                    // Paste current text in Clipboard into text box.
                    oRichTextBox.Paste();
                }
            }

            public static void Undo(ref System.Windows.Forms.RichTextBox oRichTextBox)
            {
                // Determine if last operation can be undone in text box.   
                if (oRichTextBox.CanUndo == true)
                {
                    // Undo the last operation.
                    oRichTextBox.Undo();
                    // Clear the undo buffer to prevent last action from being redone.
                    oRichTextBox.ClearUndo();
                }
            }

            public static string GetRowColumnMouseDownFromRTFTextbox(ref RichTextBox aRTFTextbox, System.Windows.Forms.MouseEventArgs e)
            {
                int iLine = 0;
                int iStartOfLine = 0;
                int iColumn = 0;
                string sPosition = null;

                iLine = aRTFTextbox.GetLineFromCharIndex(aRTFTextbox.GetCharIndexFromPosition(new Point(e.X, e.Y))) + 1;
                iStartOfLine = aRTFTextbox.GetFirstCharIndexOfCurrentLine();
                iColumn = aRTFTextbox.GetCharIndexFromPosition(new Point(e.X, e.Y)) - iStartOfLine + 1;
                sPosition = "Line: " + iLine.ToString() + "  Column: " + iColumn.ToString();
                return sPosition;
            }


        }

    }
}

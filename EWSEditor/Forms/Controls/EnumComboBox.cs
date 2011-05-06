namespace EWSEditor.Forms.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    using EWSEditor.Diagnostics;
    using Microsoft.Exchange.WebServices.Data;

    public partial class EnumComboBox<T> : ComboBox where T : struct
    {
        private bool hasEmptyItem = false;
        private System.Collections.ObjectModel.Collection<T?> items = new System.Collections.ObjectModel.Collection<T?>();

        public EnumComboBox()
        {
            InitializeComponent();

            this.LoadComboBoxItems();
        }

        /// <summary>
        /// Gets or sets a value indicating whether an empty item should be
        /// listed in ComboBox drop down list.
        /// </summary>
        public bool HasEmptyItem
        {
            get
            {
                return this.hasEmptyItem;
            }

            set
            {
                // If the new value is different than the current reload
                // the ComboBox.Items collection
                if (this.hasEmptyItem != value)
                {
                    this.hasEmptyItem = value;
                    this.LoadComboBoxItems();
                }
            }
        }

        /// <summary>
        /// Gets or sets the SelectedItem of this ComboBox using the specified type.
        /// </summary>
        public new T? SelectedItem
        {
            get
            {
                try
                {
                    if (this.SelectedIndex >= 0 && this.SelectedIndex < this.Items.Count)
                    {
                        return this.Items[this.SelectedIndex];
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    // Shouldn't get an exception here but log it and bury it if we do
                    TraceHelper.WriteVerbose(ex);
                    return null;
                }
            }

            set
            {
                base.SelectedItem = value;
            }
        }

        public new System.Collections.ObjectModel.Collection<T?> Items
        {
            get
            {
                System.Collections.ObjectModel.Collection<T?> items = new System.Collections.ObjectModel.Collection<T?>();
                foreach (object o in base.Items)
                {
                    items.Add(o as T?);
                }

                return items;
            }
        }

        /// <summary>
        /// This method let's us work around a bug in Visual Studio
        /// were generic controls don't play nice with the VS designer.  The
        /// workaround is to use a regular ComboBox in the designer and convert
        /// it to EnumComboBox in the Load event of the hosting form.
        /// https://connect.microsoft.com/VisualStudio/feedback/details/249838/the-designer-could-not-be-shown-for-this-file-because-none-of-the-classes-within-it-can-be-designed
        /// </summary>
        /// <param name="control">
        /// ComboBox control to copy settings from to a new EnumComboBox.
        /// </param>
        public void TransformComboBox(ComboBox control)
        {
            // Copy properties from the original ComboBox to the new EnumComboBox
            this.DropDownStyle = control.DropDownStyle;
            this.Enabled = control.Enabled;
            this.FormattingEnabled = control.FormattingEnabled;
            this.Location = control.Location;
            this.Name = control.Name;
            this.Size = control.Size;
            this.TabIndex = control.TabIndex;

            // Hide the original control
            control.Parent.Controls.Add(this);
            control.Parent.Controls.Remove(control);
            this.Visible = true;
            control.Visible = false;
        }

        private void LoadComboBoxItems()
        {
            // Reset the collection
            base.Items.Clear();

            // Add an empty if necessary
            if (this.HasEmptyItem)
            {
                base.Items.Add(string.Empty);
            }

            if (typeof(T) == typeof(bool))
            {
                base.Items.Add(true);
                base.Items.Add(false);
            }
            else
            {
                foreach (object val in System.Enum.GetValues(typeof(T)))
                {
                    base.Items.Add((T)val);
                }
            }
        }
    }
}

﻿// Copyright (c) 2024 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using System.Windows.Forms;

namespace eVolve.DataTableTools.Revit.ExternalTables;

/// <summary> Dialog for defining a <see cref="SqlServerSource"/>. </summary>
internal partial class SqlServerSourceDialog : System.Windows.Forms.Form
{
    /// <summary> Constructor. </summary>
    ///
    /// <param name="dialogTitle"> The dialog title. </param>
    /// <param name="source"> Source object to fill the user input fields with. </param>
    public SqlServerSourceDialog(string dialogTitle, SqlServerSource source)
    {
        InitializeComponent();

        this.PrepDialog(dialogTitle);

        ExternalTableSourceBaseControl.SetData(source);
        ConnectionStringTextBox.Text = source.ConnectionString;
        CommandTextBox.Text = source.CommandText;

        FormClosing += SqlServerSourceDialog_FormClosing;
    }

    /// <summary> Validates user input. </summary>
    ///
    /// <param name="sender"> Source of the event. </param>
    /// <param name="e"> Form closing event information. </param>
    private void SqlServerSourceDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (DialogResult == DialogResult.OK && !e.Cancel)
        {
            var source = GetSource();
            e.Cancel = ExternalTableSourceBaseControl.ValidateData(source,
                new[]
                {
                    (source.ConnectionString, ConnectionStringGroupBox.Text),
                    (source.CommandText, CommandGroupBox.Text),
                });
        }
    }

    /// <summary> Returns a new <see cref="SqlServerSource"/> based on the current input. </summary>
    public SqlServerSource GetSource()
    {
        var data = ExternalTableSourceBaseControl.GetData<SqlServerSource>();
        data.ConnectionString = ConnectionStringTextBox.Text.Trim();
        data.CommandText = CommandTextBox.Text;
        return data;
    }
}

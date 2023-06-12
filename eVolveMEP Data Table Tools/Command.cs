﻿// Copyright (c) 2023 eVolve MEP, LLC
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

extern alias eVolve;
using Autodesk.Revit.Attributes;

namespace eVolve.DataTableTools.Revit;

/// <summary> Executes the import/export process. </summary>
[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
internal class Command : IExternalCommand
{
    /// <summary> Gets the button name of this tool as single line text. </summary>
    internal static string ButtonTextWithNoLineBreaks => ExtensionsCommon.Revit.Methods.GetButtonTextWithNoLineBreaks(Resources.ButtonText);

    /// <summary> Gets the icon resource. </summary>
    internal static System.IO.Stream IconResource => ExtensionsCommon.Revit.Methods.GetIconResource("DataTableTools_32x32.png");

    /// <summary> Gets URL of the help link to open when requested by the user. </summary>
    internal static string HelpLinkUrl
    {
        get
        {
#if ELECTRICAL
            return "";
#elif MECHANICAL
            return "";
#else
            return null;
#endif
        }
    }

    /// <inheritdoc/>
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        using var dialog = new ToolsDialog(commandData.Application.ActiveUIDocument.Document);
        dialog.ShowDialog();
        return Result.Succeeded;
    }
}
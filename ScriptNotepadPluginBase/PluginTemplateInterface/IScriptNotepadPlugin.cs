#region License
/*
MIT License

Copyright (c) 2019 Petteri Kautonen

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using static ScriptNotepadPluginBase.Types.DelegateTypes;

namespace ScriptNotepadPluginBase.PluginTemplateInterface
{
    /// <summary>
    /// An interface to write plug-ins for the ScriptNotepad software.
    /// </summary>
    public interface IScriptNotepadPlugin : IDisposable
    {
        /// <summary>
        /// An event which the plug-in should invoke when the plug-in wants to access the active document of the ScriptNotepad software.
        /// </summary>
        event OnRequestActiveDocument RequestActiveDocument;

        /// <summary>
        /// An event which the plug-in should invoke when the plug-in wants to access to all the open documents in the ScriptNotepad software.
        /// </summary>
        event OnRequestAllDocuments RequestAllDocuments;

        /// <summary>
        /// An event the plug-in should raise in case of a handled exception within the class.
        /// </summary>
        event OnPluginException PluginException;

        /// <summary>
        /// Additional initialization method for the plug-in.
        /// </summary>
        /// <param name="onRequestActiveDocument">The event provided by the hosting software (ScriptNotepad) to request for the active document within the software.</param>
        /// <param name="onRequestAllDocuments">The event provided by the hosting software (ScriptNotepad) to request for all open documents within the software.</param>
        /// <param name="onPluginException">The event provided by the hosting software (ScriptNotepad) for error reporting.</param>
        /// <param name="mainMenu">The <see cref="MenuStrip"/> which is the main menu of the hosting software (ScriptNotepad).</param>
        /// <param name="pluginMenuStrip">The <see cref="ToolStripMenuItem"/> which is the plug-in menu in the hosting software (ScriptNotepad).</param>
        /// <param name="sessionName">The name of the current session in the hosting software (ScriptNotepad).</param>
        /// <param name="scriptNotepadMainForm">A reference to the main form of the hosting software (ScriptNotepad).</param>
        void Initialize(OnRequestActiveDocument onRequestActiveDocument,
            OnRequestAllDocuments onRequestAllDocuments,
            OnPluginException onPluginException,
            MenuStrip mainMenu,
            ToolStripMenuItem pluginMenuStrip,
            string sessionName,
            Form scriptNotepadMainForm);

        /// <summary>
        /// This method is called by the hosting software (ScriptNotepad) if documents in the software have been changed. 
        /// </summary>
        void NotifyDocumentChanged();

        /// <summary>
        /// The name of this plug-in.
        /// </summary>
        string PluginName { get; }

        /// <summary>
        /// The main form of the hosting software (ScriptNotepad).
        /// </summary>
        Form ScriptNotepadMainForm { get; set; }

        /// <summary>
        /// Gets or sets the tool strip menu item the plug-in constructed.
        /// </summary>
        ToolStripMenuItem PluginMenu { get; set; }

        /// <summary>
        /// Disposes the menu created by the plug-in.
        /// </summary>
        void DisposeMenu();

        /// <summary>
        /// Gets or sets the current locale for the plug-in.
        /// </summary>
        string Locale { get; set; }

        /// <summary>
        /// The description of this plug-in.
        /// </summary>
        string PluginDescription { get; set; }

        /// <summary>
        /// Displays the about dialog for this plug-in.
        /// </summary>
        void AbountDialog();
    }
}

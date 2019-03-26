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

using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Text;
using static ScriptNotepadPluginBase.Types.DelegateTypes;

namespace ScriptNotepadPluginBase.EventArgClasses
{
    /// <summary>
    /// Event arguments for the <see cref="OnRequestActiveDocument"/> and for the <see cref="OnRequestAllDocuments"/> events.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class RequestScintillaDocumentEventArgs: EventArgs
    {
        /// <summary>
        /// Gets or sets a value indicating whether all documents from the ScriptNotepad's active session was returned.
        /// </summary>
        public bool AllDocuments { get; set; }

        /// <summary>
        /// A list of documents received from the <see cref="OnRequestActiveDocument"/> and for the <see cref="OnRequestAllDocuments"/> events.
        /// </summary>
        public List<
            (           
            Encoding Encoding, // the document's encoding..
            Scintilla Scintilla, // the Scintilla containing the document..
            string FileNameFull, // the full file name of the document..
            DateTime FileSysModified, // the date and time the document was modified in the file system..
            DateTime DBModified,  // the date and time the document was modified within the ScriptNotepad's database..
            bool IsActiveDocument // A flag indicating whether the document is the active document within the ScriptNotepad..
            )> Documents;
    }

    /// <summary>
    /// Event arguments for reporting a handled exception within the plug-in assembly.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class PluginExceptionEventArgs: EventArgs
    {
        /// <summary>
        /// Gets or sets the exception which occurred.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets the name of the plug-in module name in which the exception occurred.
        /// </summary>
        public string PluginModuleName { get; set; }
    }
}

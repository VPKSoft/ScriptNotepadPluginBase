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
            DateTime DBModified, // the date and time the document was modified within the ScriptNotepad's database..
            bool
            IsActiveDocument // A flag indicating whether the document is the active document within the ScriptNotepad..
            )> Documents = // fixed null reference..
            new List<(Encoding Encoding, Scintilla Scintilla, string FileNameFull, DateTime FileSysModified, DateTime
                DBModified, bool IsActiveDocument)>();
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

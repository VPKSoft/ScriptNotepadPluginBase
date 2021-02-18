using ScriptNotepadPluginBase.EventArgClasses;

namespace ScriptNotepadPluginBase.Types
{
    /// <summary>
    /// A class containing delegate definitions for the events used within the plug-in.
    /// </summary>
    public static class DelegateTypes
    {
        /// <summary>
        /// A delegate for an event which the plug-in should invoke when the plug-in wants to access the active document of the ScriptNotepad software.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="RequestScintillaDocumentEventArgs"/> instance containing the event data.</param>
        public delegate void OnRequestActiveDocument(object sender, RequestScintillaDocumentEventArgs e);

        /// <summary>
        /// A delegate for an event which the plug-in should invoke when the plug-in wants to access to all the open documents in the ScriptNotepad software.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="RequestScintillaDocumentEventArgs"/> instance containing the event data.</param>
        public delegate void OnRequestAllDocuments(object sender, RequestScintillaDocumentEventArgs e);

        /// <summary>
        /// A delegate for an event the plug-in should raise in case of a handled exception within the class.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="PluginExceptionEventArgs"/> instance containing the event data.</param>
        public delegate void OnPluginException(object sender, PluginExceptionEventArgs e);
    }
}

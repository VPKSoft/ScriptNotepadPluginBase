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

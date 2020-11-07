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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ScriptNotepadPluginBase.About.CustomControls
{
    /// <summary>
    /// A label control masked to look as a hyper link.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Label" />
    public partial class SimpleLinkLabel : Label
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleLinkLabel"/> class.
        /// </summary>
        public SimpleLinkLabel()
        {
            InitializeComponent();
            ForeColor = Color.Navy;
            Font = new Font(this.Font, FontStyle.Underline);
            Cursor = Cursors.Hand;
            Click += SimpleLinkLabel_Click;
        }

        /// <summary>
        /// Handles the Click event of the SimpleLinkLabel control and starts a web browser if the <see cref="LinkUrl"/> is valid.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void SimpleLinkLabel_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(LinkUrl);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Gets or sets the link URL for user to click on the control.
        /// </summary>
        [Category("Behavior")]
        public string LinkUrl { get; set; }

        /// <summary>
        /// Gets or sets the cursor that is displayed when the mouse pointer is over the control.
        /// </summary>
        [Browsable(false)]
        public override Cursor Cursor
        {
            get
            {
                return base.Cursor;
            }
            set
            {
                base.Cursor = value;
            }
        }
    }
}

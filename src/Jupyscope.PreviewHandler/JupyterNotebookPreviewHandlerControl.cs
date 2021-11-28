namespace Jupyscope.PreviewHandler
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Common;
    using Jupyscope.Contracts;
    using Jupyscope.Extensions;
    using Jupyscope.Helpers;
    using Jupyscope.Serializers;
    using Microsoft.PowerToys.PreviewHandler.JupyterNotebook.Properties;
    using PreviewHandlerCommon;

    /// <summary>
    /// Win Form Implementation for JupyterNotebook Preview Handler.
    /// </summary>
    public class JupyterNotebookPreviewHandlerControl : FormHandlerControl
    {
        /// <summary>
        /// RichTextBox control to display if external images are blocked.
        /// </summary>
        private RichTextBox infoBar;

        /// <summary>
        /// Extended Browser Control to display markdown html.
        /// </summary>
        private WebBrowserExt browser;

        /// <summary>
        /// True if external image is blocked, false otherwise.
        /// </summary>
        private bool infoBarDisplayed;

        /// <summary>
        /// Initializes a new instance of the <see cref="JupyterNotebookPreviewHandlerControl"/> class.
        /// </summary>
        public JupyterNotebookPreviewHandlerControl()
        {
        }

        /// <summary>
        /// Start the preview on the Control.
        /// </summary>
        /// <typeparam name="T">The data source type.</typeparam>
        /// <param name="dataSource">Path to the file.</param>
        public override void DoPreview<T>(T dataSource)
        {
            this.infoBarDisplayed = false;

            try
            {
                if (!(dataSource is string filePath))
                {
                    throw new ArgumentException($"{nameof(dataSource)} for {nameof(JupyterNotebookPreviewHandler)} must be a string but was a '{typeof(T)}'");
                }

                string fileText = File.ReadAllText(filePath);
                Regex imageTagRegex = new Regex(@"<[ ]*img.*>");
                if (imageTagRegex.IsMatch(fileText))
                {
                    this.infoBarDisplayed = true;
                }

                var notebook = TelescopeConverter.Deserialize<Notebook>(fileText);
                var notebookContentHTML = notebook.ToHtml();
                var notebookHTML = $"{HTMLHeaderHelper.Header}{notebookContentHTML}{HTMLHeaderHelper.Footer}";

                this.InvokeOnControlThread(() =>
                {
                    this.browser = new WebBrowserExt
                    {
                        DocumentText = notebookHTML,
                        Dock = DockStyle.Fill,
                        IsWebBrowserContextMenuEnabled = false,
                        ScriptErrorsSuppressed = true,
                        ScrollBarsEnabled = true,
                        AllowNavigation = false,
                    };
                    this.Controls.Add(this.browser);

                    if (this.infoBarDisplayed)
                    {
                        this.infoBar = this.GetTextBoxControl(Resources.BlockedImageInfoText);
                        this.Resize += this.FormResized;
                        this.Controls.Add(this.infoBar);
                    }
                });
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                this.InvokeOnControlThread(() =>
                {
                    this.Controls.Clear();
                    this.infoBarDisplayed = true;
                    this.infoBar = this.GetTextBoxControl(Resources.NotebookNotPreviewedError);
                    this.Resize += this.FormResized;
                    this.Controls.Add(this.infoBar);
                });
            }
            finally
            {
                base.DoPreview(dataSource);
            }
        }

        /// <summary>
        /// Gets a textbox control.
        /// </summary>
        /// <param name="message">Message to be displayed in textbox.</param>
        /// <returns>An object of type <see cref="RichTextBox"/>.</returns>
        private RichTextBox GetTextBoxControl(string message)
        {
            RichTextBox richTextBox = new RichTextBox
            {
                Text = message,
                BackColor = Color.LightYellow,
                Multiline = true,
                Dock = DockStyle.Top,
                ReadOnly = true,
            };
            richTextBox.ContentsResized += this.RTBContentsResized;
            richTextBox.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox.BorderStyle = BorderStyle.None;

            return richTextBox;
        }

        /// <summary>
        /// Callback when RichTextBox is resized.
        /// </summary>
        /// <param name="sender">Reference to resized control.</param>
        /// <param name="e">Provides data for the resize event.</param>
        private void RTBContentsResized(object sender, ContentsResizedEventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)sender;
            richTextBox.Height = e.NewRectangle.Height + 5;
        }

        /// <summary>
        /// Callback when form is resized.
        /// </summary>
        /// <param name="sender">Reference to resized control.</param>
        /// <param name="e">Provides data for the event.</param>
        private void FormResized(object sender, EventArgs e)
        {
            if (this.infoBarDisplayed)
            {
                this.infoBar.Width = this.Width;
            }
        }

        /// <summary>
        /// Callback when image is blocked by extension.
        /// </summary>
        private void ImagesBlockedCallBack()
        {
            this.infoBarDisplayed = true;
        }
    }
}

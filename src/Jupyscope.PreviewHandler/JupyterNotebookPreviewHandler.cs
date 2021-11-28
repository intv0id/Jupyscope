namespace Jupyscope.PreviewHandler
{
    using System;
    using System.Runtime.InteropServices;
    using Common;

    /// <summary>
    /// Implementation of preview handler for Jupyter notebook files.
    /// </summary>
    [Guid("e972eda6-2734-4dab-9dc0-289b41eb89ea")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class JupyterNotebookPreviewHandler : FileBasedPreviewHandler, IDisposable
    {
        private JupyterNotebookPreviewHandlerControl jupyterNotebookPreviewHandlerControl;
        private bool disposedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="JupyterNotebookPreviewHandler"/> class.
        /// </summary>
        public JupyterNotebookPreviewHandler()
        {
            this.Initialize();
        }

        /// <inheritdoc/>
        public override void DoPreview()
        {
            this.jupyterNotebookPreviewHandlerControl.DoPreview(this.FilePath);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        protected override IPreviewHandlerControl CreatePreviewHandlerControl()
        {
            this.jupyterNotebookPreviewHandlerControl = new JupyterNotebookPreviewHandlerControl();

            return this.jupyterNotebookPreviewHandlerControl;
        }

        /// <summary>
        /// Disposes objects.
        /// </summary>
        /// <param name="disposing">Is Disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.jupyterNotebookPreviewHandlerControl.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}

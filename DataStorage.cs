﻿using System.IO;
using System.Windows;
using System.Windows.Documents;
using Microsoft.Win32;

namespace TextEditor
{
    internal class DataStorage 
    {
        private static readonly string DocumentFilter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
        private bool IsDocumentOpened { get; set; }
        public string DocumentName { get; private set; }
        private static DataStorage _dataStorage;

        public static DataStorage GetInstance()
        {
            return _dataStorage ?? (_dataStorage = new DataStorage());
        }

        public void SaveDocument(TextRange documentRange)
        {
            if (!IsDocumentOpened)
            {
                var saveDialog = new SaveFileDialog {Filter = DocumentFilter};
                saveDialog.ShowDialog();
                DocumentName = saveDialog.FileName;
                IsDocumentOpened = true;
            }
            documentRange.Save(new FileStream(DocumentName, FileMode.Create), DataFormats.Rtf);
        }

        public string OpenDocument() 
        {
            var openDialog = new OpenFileDialog {Filter = DocumentFilter};
            openDialog.ShowDialog();
            IsDocumentOpened = true;
            return DocumentName = openDialog.FileName;
        }
    }
}
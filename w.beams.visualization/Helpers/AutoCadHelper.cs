using System;
using System.Windows;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;

namespace w.beams.visualization.Helpers
{
    static class AutoCadHelper
    {
        private static Document _activeDocument => Application.DocumentManager.MdiActiveDocument;

        private static Database _activeDocumentDatabase => _activeDocument.Database;
        public static Transaction Transaction;
        private static BlockTable _blockTable;
        private static BlockTableRecord _blockTableRecord;

        public static string Message { get; set; } = "An error occured";

        private static void OpenDoc()
        {
            _blockTable = (BlockTable)Transaction.GetObject(_activeDocumentDatabase.BlockTableId, OpenMode.ForWrite);
            _blockTableRecord = (BlockTableRecord)Transaction.GetObject(_blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
        }

        public static void Do(Action action)
        {
            try
            {
                using (_activeDocument.LockDocument())
                using (Transaction = _activeDocumentDatabase.TransactionManager.StartTransaction())
                {
                    OpenDoc();
                    action();
                    Transaction.Commit();
                }
            }
            catch (Autodesk.AutoCAD.Runtime.Exception ex)
            {
                MessageBox.Show($"{Message}\n\n{ex.Message}");
            }
        }

        /// <summary>
        /// Appends an entity to the block table record and adds it as a newly created object to the transaction. This must be used within an active transaction.
        /// </summary>
        /// <param name="entity"></param>
        public static void AppendAndAddToTransaction(Entity entity)
        {
            _blockTableRecord.AppendEntity(entity);
            Transaction.AddNewlyCreatedDBObject(entity, true);
        }

        /// <summary>
        /// Adds an entity to the transaction as a newly created object.
        /// </summary>
        /// <param name="entity"></param>
        public static void AddToTransaction(Entity entity)
        {
            Transaction.AddNewlyCreatedDBObject(entity, true);
        }
    }
}

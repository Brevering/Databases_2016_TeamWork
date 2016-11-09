using System;
using System.Collections.Generic;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

using CarsFactory.Reports.Documents.Abstract;
using CarsFactory.Reports.Documents.Contracts;
using CarsFactory.Utilities.Extensions;

namespace CarsFactory.Reports.Documents
{
    /// <summary>
    /// Provides methods for creating an iTextSharp.text.pdf document.
    /// </summary>
    public class PdfDocumentAdapter : AbstractDocumentAdapter
    {
        private const float DefaultCellPadding = 10f;
        private const float DefaultGrayFill = 0.9f;
        private const int DefaultColspan = 1;
        private const int CentralAlignment = 1;
        private const float FullWidthPercentage = 100f;
        private const string DataNotAvaliableSymbol = "N/A";

        private readonly Document document;

        public PdfDocumentAdapter(string fileName, Stream stream)
            : base(fileName)
        {
            this.document = new Document();
            PdfWriter.GetInstance(this.document, stream);
        }

        /// <summary>
        /// Saves the document.
        /// </summary>
        public override void Save()
        {
            this.document.Close();
        }

        /// <summary>
        /// Adds a header to the document with the specified text.
        /// </summary>
        /// <param name="text">The text content.</param>
        /// <returns>Self</returns>
        public override IDocumentAdapter AddHeader(string text)
        {
            this.document.Add(new Paragraph(text));
            this.document.Add(Chunk.NEWLINE);
            this.document.Add(new LineSeparator());
            this.document.Add(Chunk.NEWLINE);

            return this;
        }

        /// <summary>
        /// Adds a table to the document with the specified contents.
        /// </summary>
        /// <param name="tableData">The data to insert.</param>
        /// <returns>Self</returns>
        /// <remarks>The method relies on the data's property names for the naming of table headers.</remarks>
        public override IDocumentAdapter AddTabularData<TModel>(ICollection<TModel> tableData)
        {
            if (tableData == null)
            {
                throw new ArgumentNullException(nameof(tableData));
            }

            var modelProperties = typeof(TModel).GetProperties();
            var table = new PdfPTable(modelProperties.Length)
                        {
                            WidthPercentage = FullWidthPercentage,
                        };

            foreach (var property in modelProperties)
            {
                var propertyName = property.Name.DivideWordsByCapitalLetters();
                var cell = new PdfPCell(new Phrase(propertyName))
                           {
                               Colspan = DefaultColspan,
                               HorizontalAlignment = CentralAlignment,
                               GrayFill = DefaultGrayFill
                           };

                table.AddCell(cell);
            }

            foreach (var data in tableData)
            {
                foreach (var property in modelProperties)
                {
                    var value = property.GetValue(data);
                    var cellValue = (value ?? DataNotAvaliableSymbol).ToString();

                    var cell = new PdfPCell(new Phrase(cellValue))
                               {
                                   Padding = DefaultCellPadding,
                                   HorizontalAlignment = CentralAlignment
                               };
                    table.AddCell(cell);
                }
            }

            this.document.Add(table);

            return this;
        }

        /// <summary>
        /// Begins a new page in the current document.
        /// </summary>
        /// <returns>Self</returns>
        public override IDocumentAdapter NewPage()
        {
            this.document.NewPage();
            return this;
        }

        /// <summary>
        /// Adds metadata and opens the document.
        /// </summary>
        /// <returns>Self</returns>
        public override IDocumentAdapter AddMetadata()
        {
            this.document.AddTitle("Reports");
            this.document.AddSubject($"Report for {DateTime.Now}");
            this.document.AddKeywords("Report, Sales");
            this.document.AddCreator(AppDomain.CurrentDomain.FriendlyName);
            this.document.AddAuthor(AppDomain.CurrentDomain.FriendlyName);
            this.document.Open();
            return this;
        }
    }
}

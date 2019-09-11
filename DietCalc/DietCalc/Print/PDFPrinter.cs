using System;
using System.IO;
using System.Windows;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using DietCalc.Configuration;
using DietCalc.Logs;

namespace DietCalc.Print
{
    public class PDFPrinter
    {
        private void CreatePDF()
        {
            if (!Directory.Exists(LocalParameters.pdfPath))
            {
                Directory.CreateDirectory(LocalParameters.pdfPath);
            }
            if (!File.Exists(LocalParameters.pdfFile))
            {
                File.Create(LocalParameters.pdfFile).Close();
            }
            try
            {
                FileStream fs = new FileStream(LocalParameters.pdfFile, FileMode.Create);
                Document doc = new Document(PageSize.A4, 25f, 25f, 30f, 30f);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                Paragraph spacer = new Paragraph("");
                spacer.SpacingAfter = 100f;
                spacer.SpacingBefore = 30f;
                doc.AddAuthor("Hubert Kuszyński");
                doc.AddCreator("Soren");
                doc.AddKeywords("PDF");
                doc.AddSubject("PRINT OF YOUR CALORIES");
                doc.AddTitle("CALORIE PRINT");

                doc.Open();
                PdfContentByte pcb = writer.DirectContent;
                Image _img = Image.GetInstance(LocalParameters.logoPath);
                _img.SetAbsolutePosition(35, 700);
                _img.ScaleAbsolute(50, 50);
                _img.ScalePercent(25f);
                doc.Add(_img);
                doc.Add(spacer);

                PdfPTable dataTable = new PdfPTable(7);
                dataTable.WidthPercentage = 100;
                dataTable.AddCell("Name:");
                dataTable.AddCell("BMR:");
                dataTable.AddCell("TDEE:");
                dataTable.AddCell("Protein:");
                dataTable.AddCell("Carbohydrates:");
                dataTable.AddCell("Fats:");
                dataTable.AddCell("Date of creation:");
                dataTable.AddCell(LocalParameters.username);
                dataTable.AddCell(Convert.ToString(Math.Round(LocalParameters.BMRAmount, 2)));
                dataTable.AddCell(Convert.ToString(Math.Round(LocalParameters.TDEEAmount, 2)));
                dataTable.AddCell(Convert.ToString(Math.Round(LocalParameters.proteinAmount, 1)));
                dataTable.AddCell(Convert.ToString(Math.Round(LocalParameters.carbsAmount, 1)));
                dataTable.AddCell(Convert.ToString(Math.Round(LocalParameters.fatsAmount, 1)));
                dataTable.AddCell(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                dataTable.SpacingAfter = 10f;
                dataTable.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                doc.Add(dataTable);
                doc.Close();
                writer.Close();
                fs.Close();
                LogWriter.LogWrite($"Created PDF {LocalParameters.pdfFile}");
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
                LogWriter.LogWrite(a.ToString());
            }

        }
        public void PrintPDF()
        {
            CreatePDF();
            Process p = new Process();
            p.StartInfo.Verb = "runas";
            p.Start();
        }
    }
}

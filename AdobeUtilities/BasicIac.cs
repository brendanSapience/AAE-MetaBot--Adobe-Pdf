using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public class MyClassTest
{
    public void DoStuff()
    {
        string pdfFilePath = @"C:\Users\brendan.sapience\Desktop\Customers\MFS\Batch 2\Prospectus\brs_pro_clean.pdf";
        string outputPath = @"C:\AA_Tools\SplitPDFs";
        int interval = 10;
        int pageNameSuffix = 0;

        // Intialize a new PdfReader instance with the contents of the source Pdf file:  
        PdfReader reader = new PdfReader(pdfFilePath);

        FileInfo file = new FileInfo(pdfFilePath);
        string pdfFileName = file.Name.Substring(0, file.Name.LastIndexOf(".")) + "-";

        MyClassTest obj = new MyClassTest();

        for (int pageNumber = 1; pageNumber <= reader.NumberOfPages; pageNumber += interval)
        {
            pageNameSuffix++;
            string newPdfFileName = string.Format(pdfFileName + "{0}", pageNameSuffix);
            SplitAndSaveInterval(pdfFilePath, outputPath, pageNumber, interval, newPdfFileName);
        }
    }


    private void SplitAndSaveInterval(string pdfFilePath, string outputPath, int startPage, int interval, string pdfFileName)
    {
        using (PdfReader reader = new PdfReader(pdfFilePath))
        {
            Document document = new Document();
            PdfCopy copy = new PdfCopy(document, new FileStream(outputPath + "\\" + pdfFileName + ".pdf", FileMode.Create));
            document.Open();

            for (int pagenumber = startPage; pagenumber < (startPage + interval); pagenumber++)
            {
                if (reader.NumberOfPages >= pagenumber)
                {
                    copy.AddPage(copy.GetImportedPage(reader, pagenumber));
                }
                else
                {
                    break;
                }

            }

            document.Close();
        }
    }
}
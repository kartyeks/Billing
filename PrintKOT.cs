using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;
using PDACommunications;
namespace BillingManager
{
    public class PrintKOT
    {
        PrintDocument pdoc = null;
        public string MemberID;
        public string PersonID;
        public string TableID;
        //public float Quantity;
        public string TableNumber;
        public string KOTNo;
        public string StoreCode;
        public string Counter;
        public string StewardName;
        public string MemberName;
        public string AccountNumber;
        public string computerName;
        public string[] ItemCode;
        public string[] ItemName;
        public string[] Quantity;


        public PrintKOT()
        {

        }
        public void print1(KOTBillPrintTableList tList)
        {
            PrintDialog pd = new PrintDialog();
            pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Courier New", 15);
            PaperSize psize = new PaperSize("Custom", 100, 200);
            //ps.DefaultPageSettings.PaperSize = psize;
            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            //pdoc.DefaultPageSettings.PaperSize.Height =320;
            pdoc.DefaultPageSettings.PaperSize.Height = 820;
            pdoc.DefaultPageSettings.PaperSize.Width = 520;
            pdoc.DefaultPageSettings.Margins.Left = 2;

            // ItemCode = tList._PrintTables[0]._ItemCode;
            if (tList._PrintTables.Length != 0)
            {


                KOTNo = tList._PrintTables[0]._KOTNo;
                TableNumber = tList._PrintTables[0]._TableNumber;
                StoreCode = tList._PrintTables[0]._StoreCode;
                //this.Counter = Counter;
                StewardName = tList._PrintTables[0]._StewardName;
                MemberName = tList._PrintTables[0]._MemberName;
                AccountNumber = tList._PrintTables[0]._AccountNumber;
                // ItemCode = tList._PrintTables[i]._ItemCode.to;
                ItemCode = new String[tList._PrintTables.Length];
                ItemName = new String[tList._PrintTables.Length];
                Quantity = new String[tList._PrintTables.Length];


                int c = 0;
                for (int i = 0; i < tList._PrintTables.Length; i++)
                {
                    if (tList._PrintTables[i]._GroupID == 2)
                    {
                        ItemCode[c] = tList._PrintTables[i]._ItemCode;
                        ItemName[c] = tList._PrintTables[i]._ItemName;
                        Quantity[c] = tList._PrintTables[i]._Quantity;
                        c++;
                    }

                }
                if (c != 0)
                {
                    pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
                    PrintPreviewDialog pp = new PrintPreviewDialog();
                    pp.Document = pdoc;
                    if (IS91.Services.Common.GetAppSetting("VegPrinter") != "")
                    {
                        pdoc.PrinterSettings.PrinterName = IS91.Services.Common.GetAppSetting("VegPrinter");
                    }
                    pp.ShowDialog();

                }
                ItemCode = new String[tList._PrintTables.Length];
                ItemName = new String[tList._PrintTables.Length];
                Quantity = new String[tList._PrintTables.Length];
                int m = 0;
                for (int i = 0; i < tList._PrintTables.Length; i++)
                {
                    if (tList._PrintTables[i]._GroupID == 1)
                    {
                        ItemCode[m] = tList._PrintTables[i]._ItemCode;
                        ItemName[m] = tList._PrintTables[i]._ItemName;
                        Quantity[m] = tList._PrintTables[i]._Quantity;
                        m++;
                    }

                }
                if (m != 0)
                {
                    pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
                    PrintPreviewDialog pp2 = new PrintPreviewDialog();
                    pp2.Document = pdoc;
                    if (IS91.Services.Common.GetAppSetting("BarPrinter") != "")
                    {
                        pdoc.PrinterSettings.PrinterName = IS91.Services.Common.GetAppSetting("BarPrinter");
                    }
                    pp2.ShowDialog();

                }
            }
            else if (tList._PrintTables.Length == 0)
            {
                pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage_noData);
                PrintPreviewDialog pp = new PrintPreviewDialog();
                pp.Document = pdoc;
                pp.ShowDialog();
            }
            //pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
            //PrintPreviewDialog pp = new PrintPreviewDialog();
            //pp.Document = pdoc;
            //pp.ShowDialog();


            //DialogResult result = pd.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    PrintPreviewDialog pp = new PrintPreviewDialog();
            //    pp.Document = pdoc;
            //    result = pp.ShowDialog();
            //    if (result == DialogResult.OK)
            //    {
            //        pdoc.Print();
            //    }
            //}

        }

        public void print(KOTBillPrintTableList tList)
        {
            PrintDialog pd = new PrintDialog();
            pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Courier New", 15);
            PaperSize psize = new PaperSize("Custom", 100, 200);
            //ps.DefaultPageSettings.PaperSize = psize;
            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            //pdoc.DefaultPageSettings.PaperSize.Height =320;
            pdoc.DefaultPageSettings.PaperSize.Height = 820;
            pdoc.DefaultPageSettings.PaperSize.Width = 520;
            pdoc.DefaultPageSettings.Margins.Left = 2;

            // ItemCode = tList._PrintTables[0]._ItemCode;
            if (tList._PrintTables.Length != 0)
            {


                KOTNo = tList._PrintTables[0]._KOTNo;
                TableNumber = tList._PrintTables[0]._TableNumber;
                StoreCode = tList._PrintTables[0]._StoreCode;
                //this.Counter = Counter;
                StewardName = tList._PrintTables[0]._StewardName;
                MemberName = tList._PrintTables[0]._MemberName;
                AccountNumber = tList._PrintTables[0]._AccountNumber;
                // ItemCode = tList._PrintTables[i]._ItemCode.to;
                ItemCode = new String[tList._PrintTables.Length];
                ItemName = new String[tList._PrintTables.Length];
                Quantity = new String[tList._PrintTables.Length];


                int c = 0;
                for (int i = 0; i < tList._PrintTables.Length; i++)
                {
                    if (tList._PrintTables[i]._GroupID == 2)
                    {
                        ItemCode[c] = tList._PrintTables[i]._ItemCode;
                        ItemName[c] = tList._PrintTables[i]._ItemName;
                        Quantity[c] = tList._PrintTables[i]._Quantity;
                        c++;
                    }

                }
                if (c != 0)
                {
                    pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
                    PrintPreviewDialog pp = new PrintPreviewDialog();
                    pp.Document = pdoc;
                    if (IS91.Services.Common.GetAppSetting("VegPrinter") != "")
                    {
                        pdoc.PrinterSettings.PrinterName = IS91.Services.Common.GetAppSetting("VegPrinter");
                    }
                   // pp.ShowDialog();
                    pdoc.Print();
                    //Added by Archana

                    //DialogResult result = pp.ShowDialog();
                    //if (result == DialogResult.OK)
                    //{
                    //    //PrintPreviewDialog pp = new PrintPreviewDialog();
                    //    //pp.Document = pdoc;
                    //    //result = pp.ShowDialog();
                    //    if (result == DialogResult.OK)
                    //    {
                    //        pdoc.Print();
                    //    }
                    //}

                }
                ItemCode = new String[tList._PrintTables.Length];
                ItemName = new String[tList._PrintTables.Length];
                Quantity = new String[tList._PrintTables.Length];
                int m = 0;
                for (int i = 0; i < tList._PrintTables.Length; i++)
                {
                    if (tList._PrintTables[i]._GroupID == 1)
                    {
                        ItemCode[m] = tList._PrintTables[i]._ItemCode;
                        ItemName[m] = tList._PrintTables[i]._ItemName;
                        Quantity[m] = tList._PrintTables[i]._Quantity;
                        m++;
                    }

                }
                if (m != 0)
                {
                    pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
                    PrintPreviewDialog pp2 = new PrintPreviewDialog();
                    pp2.Document = pdoc;
                    if (IS91.Services.Common.GetAppSetting("BarPrinter") != "")
                    {
                        pdoc.PrinterSettings.PrinterName = IS91.Services.Common.GetAppSetting("BarPrinter");
                    }
                  //  pp2.ShowDialog();
                     pdoc.Print();
                    //Added by Archana

                    //DialogResult result = pp2.ShowDialog();
                    //if (result == DialogResult.OK)
                    //{
                    //    //PrintPreviewDialog pp = new PrintPreviewDialog();
                    //    //pp.Document = pdoc;
                    //    //result = pp.ShowDialog();
                    //    if (result == DialogResult.OK)
                    //    {
                    //        pdoc.Print();
                    //    }
                    //}

                }
            }
            else if (tList._PrintTables.Length == 0)
            {
                pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage_noData);
                PrintPreviewDialog pp = new PrintPreviewDialog();
                pp.Document = pdoc;
               // pp.ShowDialog();
                pdoc.Print();
                //Added by Archana

                //DialogResult result = pd.ShowDialog();
                //if (result == DialogResult.OK)
                //{
                //    //PrintPreviewDialog pp = new PrintPreviewDialog();
                //    //pp.Document = pdoc;
                //    //result = pp.ShowDialog();
                //    if (result == DialogResult.OK)
                //    {
                //        pdoc.Print();
                //    }
                //}
            }
            //pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
            //PrintPreviewDialog pp = new PrintPreviewDialog();
            //pp.Document = pdoc;
            //pp.ShowDialog();


            //DialogResult result = pd.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    PrintPreviewDialog pp = new PrintPreviewDialog();
            //    pp.Document = pdoc;
            //    result = pp.ShowDialog();
            //    if (result == DialogResult.OK)
            //    {
            //        pdoc.Print();
            //    }
            //}

        }
        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 8, FontStyle.Bold);
            float fontHeight = font.GetHeight();
            int startX = 2;
            int startY = 55;
            int Offset = 40;

            graphics.DrawString("KSCA CLUB HOUSE", new Font("Courier New", 14, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("   KOT/BOT", new Font("Courier New", 14, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            string underLine = "------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Table NO : " + TableNumber, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            underLine = "------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("KOT NO : " + KOTNo, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Counter : " + StoreCode, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Date Time : " + DateTime.Now, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Wtr : " + StewardName, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            underLine = "------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Member : " + MemberName, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Member Code : " + AccountNumber, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            underLine = "------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            int columnPosition = e.MarginBounds.Left;
            int rowPosition = e.MarginBounds.Top + 250;
            // Item header
            String columnHeaders = String.Format("{0, 0} {1, -25} {2, -15} ", "Code", "Item Name", "QTY");
            e.Graphics.DrawString(columnHeaders, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), e.MarginBounds.Left, rowPosition);
            rowPosition += 20;
            e.Graphics.DrawLine(new Pen(Brushes.Black), new Point(e.MarginBounds.Left, rowPosition), new Point(e.MarginBounds.Right, rowPosition));
            rowPosition += 15;
            font = new Font("Courier New", 8, FontStyle.Bold);
            String item = String.Empty;
            for (int i = 0; i < ItemCode.Length; i++)
            {
                if (ItemCode[i] != "")
                {
                    item += String.Format("{0, 0} {1, -25} {2, -15} ", ItemCode[i], ItemName[i], Quantity[i]);
                    item += Environment.NewLine;
                }
            }
            e.Graphics.DrawString(item, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), e.MarginBounds.Left, rowPosition);
        }



        void pdoc_PrintPage_noData(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 8, FontStyle.Bold);
            float fontHeight = font.GetHeight();
            int startX = 2;
            int startY = 55;
            int Offset = 40;

            graphics.DrawString("No Data", new Font("Courier New", 14, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
        }

        public void printUpdated(KOTBillPrintTableList tList)
        {
            PrintDialog pd = new PrintDialog();
            pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Courier New", 15);
            PaperSize psize = new PaperSize("Custom", 100, 200);
            //ps.DefaultPageSettings.PaperSize = psize;
            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            //pdoc.DefaultPageSettings.PaperSize.Height =320;
            pdoc.DefaultPageSettings.PaperSize.Height = 820;
            pdoc.DefaultPageSettings.PaperSize.Width = 520;
            pdoc.DefaultPageSettings.Margins.Left = 2;
            // ItemCode = tList._PrintTables[0]._ItemCode;
            if (tList._PrintTables.Length != 0)
            {


                KOTNo = tList._PrintTables[0]._KOTNo;
                TableNumber = tList._PrintTables[0]._TableNumber;
                StoreCode = tList._PrintTables[0]._StoreCode;
                //this.Counter = Counter;
                StewardName = tList._PrintTables[0]._StewardName;
                MemberName = tList._PrintTables[0]._MemberName;
                AccountNumber = tList._PrintTables[0]._AccountNumber;
                // ItemCode = tList._PrintTables[i]._ItemCode.to;
                ItemCode = new String[tList._PrintTables.Length];
                ItemName = new String[tList._PrintTables.Length];
                Quantity = new String[tList._PrintTables.Length];


                int a = 0;
                for (int i = 0; i < tList._PrintTables.Length; i++)
                {
                    if (tList._PrintTables[i]._GroupID == 2)
                    {
                        ItemCode[a] = tList._PrintTables[i]._ItemCode;
                        ItemName[a] = tList._PrintTables[i]._ItemName;
                        Quantity[a] = tList._PrintTables[i]._Quantity;
                        a++;
                    }

                }
                if (a != 0)
                {
                    pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage_Updaed_Veg);
                    PrintPreviewDialog pp = new PrintPreviewDialog();
                    pp.Document = pdoc;
                    if (IS91.Services.Common.GetAppSetting("VegPrinter") != "")
                    {
                        pdoc.PrinterSettings.PrinterName = IS91.Services.Common.GetAppSetting("VegPrinter");
                    }
                    //pp.ShowDialog();
                    pdoc.Print();
                }
                ItemCode = new String[tList._PrintTables.Length];
                ItemName = new String[tList._PrintTables.Length];
                Quantity = new String[tList._PrintTables.Length];
                int m = 0;
                for (int i = 0; i < tList._PrintTables.Length; i++)
                {
                    if (tList._PrintTables[i]._GroupID == 1)
                    {
                        ItemCode[m] = tList._PrintTables[i]._ItemCode;
                        ItemName[m] = tList._PrintTables[i]._ItemName;
                        Quantity[m] = tList._PrintTables[i]._Quantity;
                        m++;
                    }
                }
                if (m != 0)
                {
                    pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage_Updaed_Veg);
                    PrintPreviewDialog pp2 = new PrintPreviewDialog();
                    pp2.Document = pdoc;
                    if (IS91.Services.Common.GetAppSetting("BarPrinter") != "")
                    {
                        pdoc.PrinterSettings.PrinterName = IS91.Services.Common.GetAppSetting("BarPrinter");
                    }
                  //  pp2.ShowDialog();
                    pdoc.Print();
                }
            }
            else if (tList._PrintTables.Length  == 0)
            {
                pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage_Updated_noData);
                PrintPreviewDialog pp = new PrintPreviewDialog();
                pp.Document = pdoc;
               // pp.ShowDialog();
                pdoc.Print();
            }


        }

        void pdoc_PrintPage_Updaed_Veg(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 8, FontStyle.Bold);
            float fontHeight = font.GetHeight();
            int startX = 2;
            int startY = 55;
            int Offset = 40;

            graphics.DrawString("KSCA CLUB HOUSE", new Font("Courier New", 14, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Cancelled KOT/BOT", new Font("Courier New", 14, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            string underLine = "------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Table NO : " + TableNumber, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            underLine = "------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("KOT NO : " + KOTNo, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Counter : " + StoreCode, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Date Time : " + DateTime.Now, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Wtr : " + StewardName, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            underLine = "------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Member : " + MemberName, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Member Code : " + AccountNumber, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            underLine = "------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            int columnPosition = e.MarginBounds.Left;
            int rowPosition = e.MarginBounds.Top + 250;
            // Item header
            String columnHeaders = String.Format("{0, 0} {1, -25} {2, -15} ", "Code", "Item Name", "QTY");
            e.Graphics.DrawString(columnHeaders, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), e.MarginBounds.Left, rowPosition);
            rowPosition += 20;
            e.Graphics.DrawLine(new Pen(Brushes.Black), new Point(e.MarginBounds.Left, rowPosition), new Point(e.MarginBounds.Right, rowPosition));
            rowPosition += 15;
            font = new Font("Courier New", 8, FontStyle.Bold);
            String item = String.Empty;
            for (int i = 0; i < ItemCode.Length; i++)
            {
                if (ItemCode[i] != "")
                {
                    item += String.Format("{0, 0} {1, -25} {2, -15} ", ItemCode[i], ItemName[i], Quantity[i]);
                    item += Environment.NewLine;
                }
            }
            e.Graphics.DrawString(item, new Font("Courier New", 8, FontStyle.Bold), new SolidBrush(Color.Black), e.MarginBounds.Left, rowPosition);
        }

        void pdoc_PrintPage_Updated_noData(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 8, FontStyle.Bold);
            float fontHeight = font.GetHeight();
            int startX = 2;
            int startY = 55;
            int Offset = 40;

            graphics.DrawString("No Data", new Font("Courier New", 14, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
//using ACR120U;
using IS91.Services;
using System.Drawing.Printing;
using System.Drawing;
namespace BillingManager
{
    class SmartCardReaderNew
    {
        private int g_rHandle, g_retCode;
		private byte g_Sec, g_SID;
		private byte[] g_pKey = new byte[6];
		private bool g_isConnected = false;
        int sctype = 0;
        byte[] ResultSN = new byte[11];
        byte ResultTag = 0x00;
        bool g_IsSelected = false;
        PrintDocument printDocument1 = null;
        string SrcprintContentBase64String = string.Empty;

    public void CustomPrintDocument(string printContentBase64String ,string PrinterName )
    {
        try{

            PageSettings objPS = new PageSettings();
            PrinterName = objPS.PrinterSettings.PrinterName;
              SrcprintContentBase64String  = string.Concat(IS91.Services.Common.Deserialize(printContentBase64String));
            
            PrintingHelper.SendStringToPrinter(PrinterName, SrcprintContentBase64String, Environment.MachineName + "_" + IS91.Services.Common.GetFileNameFromDate(DateTime.Today));
            
            
        }catch( Exception ex)
        {
           Logger.LogThis(ex);
            
        }
    }
    public void BillPrintDocument(string printContentBase64String, string PrinterName)
    {
        try
        {

            PageSettings objPS = new PageSettings();
            PrinterName = objPS.PrinterSettings.PrinterName;
            SrcprintContentBase64String = string.Concat(IS91.Services.Common.Deserialize(printContentBase64String));
            Logger.LogThis(printContentBase64String);
            printDocument1 = new PrintDocument();
            printDocument1.PrintPage +=
          new PrintPageEventHandler(printDocument1_PrintPage);

            printDocument1.Print();
        }
        catch (Exception ex)
        {
            Logger.LogThis(ex);

        }
    }
    private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
    {
        int charactersOnPage = 0;
        int linesPerPage = 0;
        Font nf = new Font(new FontFamily("Arial"), 10,
        System.Drawing.FontStyle.Bold);
        // Sets the value of charactersOnPage to the number of characters
        // of stringToPrint that will fit within the bounds of the page.
        e.Graphics.MeasureString(SrcprintContentBase64String, nf,
            e.MarginBounds.Size, StringFormat.GenericTypographic,
            out charactersOnPage, out linesPerPage);

        // Draws the string within the bounds of the page
        e.Graphics.DrawString(SrcprintContentBase64String, nf, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);

        // Remove the portion of the string that has been printed.
        SrcprintContentBase64String = SrcprintContentBase64String.Substring(charactersOnPage);

        // Check to see if more pages are to be printed.
        e.HasMorePages = (SrcprintContentBase64String.Length > 0);
    }
        public bool IsCardConnected()
        {
            return Connect2Card();
        }
      private bool Connect2Card()
      {
           //int ctr = 0;
			//byte[] FirmwareVer = new byte[31];
		//	byte[] FirmwareVer1 = new byte[20];
			//byte infolen = 0x00;
			//string FirmStr;
          int port=0;
			ACR120U.tReaderStatus ReaderStat = new ACR120U.tReaderStatus();

			if (g_isConnected)
			{
				Logger.LogThis("Device is already connected.");
				return true;
			}
            int.TryParse(Common.GetAppSetting("ReaderPort"),out port);
            g_rHandle = ACR120U.ACR120_Open(ACR120U.ACR120_USB1);
            if (g_rHandle != 0)
            {
                Logger.LogThis("[X] " + ACR120U.GetErrMsg(g_rHandle));
                return false;
            }
            else
            {
                Logger.LogThis("Connected to USB" + string.Format("{0}", port + 1));
                g_isConnected = true;

                //Get the DLL version the program is using
                /*	g_retCode = ACR120U.ACR120_RequestDLLVersion(ref infolen, ref FirmwareVer[0]);
                    if (g_retCode < 0)

                        Logger.LogThis("[X] " + ACR120U.GetErrMsg(g_retCode));
					
                    else
                    {
                        FirmStr = "";
                        for(ctr=0;ctr<Convert.ToInt16(infolen)-1;ctr++)
                            FirmStr = FirmStr + char.ToString((char)(FirmwareVer[ctr]));
                        Logger.LogThis("DLL Version : " + FirmStr);
                    }
    
                    //Routine to get the firmware version.
                    g_retCode = ACR120U.ACR120_Status(g_rHandle, ref FirmwareVer1[0], ref ReaderStat);
                    if (g_retCode < 0)

                        Logger.LogThis("[X] " + ACR120U.GetErrMsg(g_retCode));
					
                    else
                    {
                        FirmStr = "";
                        for(ctr=0;ctr<Convert.ToInt16(infolen);ctr++)
                            if ((FirmwareVer1[ctr] != 0x00) && (FirmwareVer1[ctr] != 0xFF))
                                FirmStr = FirmStr + char.ToString((char)(FirmwareVer1[ctr]));
                        Logger.LogThis("Firmware Version : " + FirmStr);
                    }*/

            }

       /* On Error Resume Next
        Dim FirmwareVer(30) As Byte
        Dim infolen As Byte
        Dim FirmStr As String
        Dim ctr As Integer
        Dim FirmwareVer1(20) As Byte
        Dim ReaderStat As ACR120U.tReaderStatus

        'ACR120U.ACR120_Reset(G_rHandle)
        'Start of Routine
        G_rHandle = ACR120U.ACR120_Open(0)
        LogThis("G_rHandle : " & G_rHandle, False)
        'Check if Handle is Valid
        If G_rHandle < 0 Then

            Return False
        Else

            Dim portstat As Byte

            'Start of Routine
            G_retcode = ACR120U.ACR120_ReadUserPort(G_rHandle, portstat)

            'check if retcode is error
            If G_retcode < 0 Then
                DisConnectCard()
                LogThis("Read User Port Error: " + CStr(G_retcode))
                Return False
            Else

                LogThis("Read User Port Success: " + CStr(G_retcode))
                LogThis("Port Status: " + CStr(portstat))
            End If
            'Get the DLL version the program is using
            'G_retcode = ACR120U.ACR120_RequestDLLVersion(infolen, FirmwareVer(0))

            'FirmStr = ""

            'For ctr = 0 To infolen - 1

            '    FirmStr = FirmStr + Chr(FirmwareVer(ctr))

            'Next


            ''Routine to get the firmware version.
            'G_retcode = ACR120U.ACR120_Status(G_rHandle, FirmwareVer1(0), ReaderStat)

            'FirmStr = ""

            'For ctr = 0 To infolen - 1
            '    If FirmwareVer1(ctr) <> 0 And FirmwareVer1(ctr) <> &HFF Then

            '        FirmStr = FirmStr + Chr(FirmwareVer1(ctr))

            '    End If
            'Next
            ACR120U.ACR120_Power(G_rHandle, 1)

            LogThis("Power ON : " & G_retcode)

            'Dim ResultSN(11) As Byte
            'Dim ResultTag As Byte
            'Dim TagType(50) As Byte

            'G_retcode = ACR120U.ACR120_Select(G_rHandle, TagType(0), ResultTag, ResultSN(0))
            'LogThis("Select : " & G_retcode)
            'If G_retcode < 0 Then
            '    Return False
            'End If
            If Not SelectCard() Then
                DisConnectCard()
                Return False
            End If
        End If*/
            return true;
      }
      private bool SelectCard()
      {
          //byte[] ResultSN = new byte[11];
          //  byte ResultTag = 0x00;
			byte[] TagType = new byte[51];
			


			//Select specific card based from serial number	
			g_retCode = ACR120U.ACR120_Select(g_rHandle, ref TagType[0], ref ResultTag, ref ResultSN[0]);
			if (g_retCode < 0)
            {
				Logger.LogThis("[X] " + ACR120U.GetErrMsg(g_retCode));
			    return false;
            }		
			else
			{
				Logger.LogThis("Select Success");
                sctype = TagType[0];
				//get serial number and convert to hex
              
		/*		if ((TagType[0] == 4) || (TagType[0] == 5))
				{

					SN = "";
					for (ctr=0; ctr<7;ctr++)
					{
						SN = SN + string.Format("{0:X2} ",ResultSN[ctr]);
					}

				}
				else
				{

					SN = "";
					for (ctr=0; ctr<ResultTag;ctr++)
					{
						SN = SN + string.Format("{0:X2} ",ResultSN[ctr]);
					}

				}
          
				//Display Serial Number
				Logger.LogThis("( i ) Card Serial Number: " + SN + " ( " + ACR120U.GetTagType1(TagType[0]) + " )");*/
			}
            g_IsSelected = true;
          return true;
      }
      public string GetSerialNumber()
      {
          int ctr = 0;
          string SN = "";
          if(!g_IsSelected)
              SelectCard();
          if (!g_IsSelected) return string.Empty;
          if ((sctype == 4) || (sctype == 5))
          {

              SN = "";
              for (ctr = 0; ctr < 7; ctr++)
              {
                  SN = SN + string.Format("{0:X2} ", ResultSN[ctr]);
              }

          }
          else
          {

              SN = "";
              for (ctr = 0; ctr < ResultTag; ctr++)
              {
                  SN = SN + string.Format("{0:X2} ", ResultSN[ctr]);
              }

          }
          return SN;
      }
      public string ReadSmartCardDataStr()
      {
        bool blnConnect = Connect2Card();
        if(!blnConnect)
        {
            DisConnectCard();
            return string.Empty;
        }

        if (!g_IsSelected)
        {
            if (!SelectCard())
            {
                DisConnectCard();
                Logger.LogThis(string.Concat(DateTime.Now) + " Select Failed");
                return string.Empty;
            }
        }

        if(!Authenticate())
        {
             DisConnectCard();
            Logger.LogThis(String.Concat(DateTime.Now) + " Authentication Failure");
            return string.Empty;
        }

 
        string Str = ReadDefaultBlockData();
         DisConnectCard();
         return Str;
      }
      private string ReadDefaultBlockData()
      {
          
          byte[] dataRead = new byte[16];
			string dstr="";
			int ctr, tmpInt = 0;
			byte Blck = 0;
           byte G_BlockNum;
           string G_ReadType;
       /*  // Blck = Convert.ToByte(readF.tBlockNo.Text);
   
			//To access the exact block on the card you must Multiply Sector where you Login by 4
			//and add the Block.

			//Computation for exact block to Access
			tmpInt = Convert.ToInt16(Blck);
			if (Convert.ToInt16(g_Sec) > 31)
				tmpInt = tmpInt + ((Convert.ToInt16(g_Sec) - 32) * 16) + 128;
			else
				tmpInt = tmpInt + Convert.ToInt16(g_Sec) * 4;
			Blck = Convert.ToByte(tmpInt);

			g_retCode = ACR120U.ACR120_Read(g_rHandle, Blck, ref dataRead[0]);
            if (g_retCode < 0)
            {
                Logger.LogThis("[X] " + ACR120U.GetErrMsg(g_retCode));
                return string.Empty;
            }
            else
            {
                Logger.LogThis("Read Block Success");
                // convert bytes read to chosen option (e.g. AS HEX, AS ASCII)
                dstr = "";
                for (ctr = 0; ctr < 16; ctr++)
                {

                    dstr = dstr + char.ToString((char)(dataRead[ctr]));


                }

                Logger.LogThis("Read Block " + String.Format("{0}", Blck) + ": " + dstr);

            }*/
         int G_Sec = 1;
          byte BLCK = 0;
           for(int k = 0;k<3;k++)
           {
            //'BLCK = CByte("&H0" & k)
            int tmp=(int)BLCK;
            if(G_Sec > 31)
                tmp = ((G_Sec - 32) * 16) + 128 + k;
            else
                tmp = G_Sec * 4 + k;
           
               BLCK=(byte)tmp;
            G_BlockNum = BLCK;
            G_ReadType = "ASC";
            //ReDim dataRead(15);
            //'read specified block

            g_retCode = ACR120U.ACR120_Read(g_rHandle, G_BlockNum,ref dataRead[0]);
            //'check if retcode is error
            if( g_retCode < 0)
                return "";//g_retCode
            
            string tmpStr = "";
            for(int m=0;m<16;m++)
            {
                if( dataRead[m] != 0)
                    tmpStr = tmpStr + Convert.ToChar(dataRead[m]);
                
            }
            if(tmpStr == "")
                return dstr;
            
            dstr = dstr + tmpStr;
           }

        //Dim dataRead(15) As Byte
        //Dim dStr As String
       // Dim tmpStr As String
       // Dim ctr As Byte
        /*dStr = "";
        tmpStr = ""
        
        Dim k As Integer
        G_Sec = 1
        For k = 0 To 2
            'BLCK = CByte("&H0" & k)

            If G_Sec > 31 Then
                BLCK = ((G_Sec - 32) * 16) + 128 + k
            Else
                BLCK = G_Sec * 4 + k
            End If

            G_BlockNum = BLCK
            G_ReadType = "ASC"
            ReDim dataRead(15)
            'read specified block

            G_retcode = ACR120U.ACR120_Read(G_rHandle, G_BlockNum, dataRead(0))

            'check if retcode is error
            If G_retcode < 0 Then
                Return G_retcode
            End If
            tmpStr = ""
            For ctr = 0 To 15
                If dataRead(ctr) <> 0 Then
                    tmpStr = tmpStr + Chr(dataRead(ctr))
                End If
            Next
            If tmpStr = "" Then
                Return dStr
            End If
            dStr = dStr + tmpStr
        Next
            */
        return dstr;
 
      }
         private void DisConnectCard()
         {
             g_retCode = ACR120U.ACR120_Reset(g_rHandle);
             g_retCode = ACR120U.ACR120_Close(g_rHandle);
             g_IsSelected = false;
             ACR120U.ACR120_Power(g_rHandle, 0);
         }


         private bool Authenticate()
         {
             long sto = 0;
             byte vKeyType = 0x00;
             int ctr, tmpInt, PhysicalSector = 1;
              
            vKeyType = ACR120U.ACR120_LOGIN_KEYTYPE_DEFAULT_F;
            

             tmpInt =1;// Convert.ToInt16(loginForm.tSector.Text);
             g_Sec = Convert.ToByte(tmpInt);

             //Computation for obtaining the actual Physical Sector.
             if (Convert.ToInt16(g_Sec) > 31)
                 PhysicalSector = Convert.ToInt16(g_Sec) + ((Convert.ToInt16(g_Sec) - 32) * 3);
             else
                 PhysicalSector = Convert.ToInt16(g_Sec);

             g_retCode = ACR120U.ACR120_Login(g_rHandle, Convert.ToByte(PhysicalSector), Convert.ToInt16(vKeyType),
                 Convert.ToByte(sto), ref g_pKey[0]);
             if (g_retCode < 0)
             {
                    Logger.LogThis("[X] " + ACR120U.GetErrMsg(g_retCode));
                 return false;
         }
             else
             {
                 Logger.LogThis("Login Success");
                 Logger.LogThis("Log at Logical Sector: " + String.Format("{0}", Convert.ToInt16(g_Sec)));
                 Logger.LogThis("Log at Physical Sector: " + String.Format("{0}", PhysicalSector));
                 Logger.LogThis("Login Type index: " + string.Format("{0}", 1));

             }
             return true;
         }
    }
}

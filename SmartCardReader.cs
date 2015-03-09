using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using IS91.Services;
using System.Drawing;

public class SmartCardReader
{


	//Printer Helper
	public void CustomPrintDocument(string printContentBase64String, string PrinterName)
	{
		try {
			System.Drawing.Printing.PageSettings objPS = new System.Drawing.Printing.PageSettings();
			PrinterName = objPS.PrinterSettings.PrinterName;
			string SrcprintContentBase64String =string.Concat( IS91.Services.Common.Deserialize(printContentBase64String));
			PrintingHelper.SendStringToPrinter(PrinterName, SrcprintContentBase64String, Environment.MachineName + "_" + GetFileNameFromDate());
		} catch (Exception ex) {
		    Logger.LogThis(ex);
			MessageBox.Show("Printing Error. Please check your printer settings", "ICMS Print Module");
		}
	}


	//http://www.fredshack.com/docs/activex.html
	//Guru
	//ActiveX Class for Reading the Smart Card Device on the local machine and
	//intended to be used in a website or html page

	const int INVALID_SW1SW2 = -450;

	public bool isCardTypeACR38U;
	long retCode;
	long Protocol;
	long hContext;
	long hCard;
	long ReaderCount;
	long nBytesRet;
	string sReaderList = string.Empty;
	string sReaderGroup = string.Empty;
	bool ConnActive;
	bool autoDet;
	SCARD_IO_REQUEST ioRequest;
	SCARD_READERSTATE RdrState;
	long SendLen;
	long RecvLen;
	byte[] SendBuff = new byte[256];
	byte[] RecvBuff = new byte[256];
	string cbReaderText = string.Empty;

	bool CardTypeACR38U;
	public enum ReaderSelection
	{
		Auto = 0,
		Ask = 1,
		Specific = 2
	}


	private void ClearBuffers()
	{
		int index = 0;

		for (index = 0; index <= 255; index++) {
			RecvBuff[index] = 0x0;
			SendBuff[index] = 0x0;
		}

	}

	private string TrimReaderList(string item)
	{
		string functionReturnValue = null;

		string[] tmpstr = null;
		tmpstr =  item.Split(), Constants.vbNullChar, 5);
		int intx = 0;
		functionReturnValue = string.Empty;

		for (intx = 0; intx <= Information.UBound(tmpstr); intx++) {
			if ((tmpstr[intx] != Constants.vbNullChar) & !string.IsNullOrEmpty(Strings.Trim(tmpstr[intx]))) {
				if ((Strings.Asc(tmpstr[intx]) != 0)) {
					if (intx == 0) {
						functionReturnValue = tmpstr[intx];
					} else {
						functionReturnValue = functionReturnValue + Constants.vbNullChar + tmpstr[intx];
					}
				}
			}
		}
		//     TrimReaderList = Join(tmpstr, Chr(167))
		//    TrimNull = Replace(item, " ", Chr(167))
		//    TrimNull = Replace(TrimNull, vbNullChar, " ")
		//    TrimNull = Replace(TrimNull, Chr(167), " ")
		return Strings.Trim(TrimReaderList());
		return functionReturnValue;
	}

	//guru
	private string GetAvailableReader(ref int resultCount, ReaderSelection xReaderSelectionType, int LookForindx = 0)
	{


		sReaderList = Strings.StrDup(255, Constants.vbNullChar);
		ReaderCount = 255;

		//Establish context
		retCode = SCardEstablishContext(SCARD_SCOPE_USER, 0, 0, hContext);

		if (retCode != SCARD_S_SUCCESS) {
			Interaction.MsgBox(GetScardErrMsg(retCode));
			return string.Empty;
		}

		// 2. List PC/SC card readers installed in the system
		retCode = SCardListReaders(hContext, sReaderGroup, sReaderList, ReaderCount);

		if (retCode != SCARD_S_SUCCESS) {
			Interaction.MsgBox(GetScardErrMsg(retCode));
			return string.Empty;
		}

		string[] sTemp = null;
		sTemp = Strings.Split(TrimReaderList(sReaderList), Constants.vbNullChar);
		resultCount = Information.UBound(sTemp);

		//you have more readers to read from
		//but the caller has not passed correct details
		switch (xReaderSelectionType) {
			case ReaderSelection.Auto:
				return sTemp[0];
			case ReaderSelection.Ask:
				if (resultCount < 1) {
					return sTemp[0];
				}

				int intx = 0;
				for (intx = 0; intx <= resultCount; intx++) {
					if (Interaction.MsgBox("Do you want to read from " + sTemp[intx], Constants.vbYesNo) == Constants.vbYes) {
						return sTemp[intx];
					}
				}

				return sTemp[0];
			case ReaderSelection.Specific:
				return sTemp[LookForindx];
		}
		return string.Empty;
	}


	private bool Connect2Card()
	{

		int resultCount = 0;
		int LookForindx = 0;
		LookForindx = 0;

		cbReaderText = GetAvailableReader(resultCount, ReaderSelection.Ask);

		if (string.IsNullOrEmpty(cbReaderText)) {
			return false;
		}

		long dwPrefProtocol = 0;
		dwPrefProtocol = SCARD_PROTOCOL_T0 | SCARD_PROTOCOL_T1;

		long dwShareMode = 0;
		dwShareMode = SCARD_SHARE_SHARED;

		CardTypeACR38U = false;
		if ((Strings.InStr(Strings.UCase(cbReaderText), "ACS ACR38U") > 0)) {
			CardTypeACR38U = true;
			//        dwPrefProtocol = 0
			//        dwShareMode = SCARD_SHARE_DIRECT
			return true;
		}

		//Connect to reader using a shared connection
		retCode = SCardConnect(hContext, cbReaderText, dwShareMode, dwPrefProtocol, hCard, Protocol);

		if (retCode != SCARD_S_SUCCESS) {
			Interaction.MsgBox(GetScardErrMsg(retCode));
			return false;
		} else {
			return true;
			//Call MsgBox("Successful connection to " & cbReaderText)
		}


	}

	private bool AuthCard(int Startb)
	{

		if (CardTypeACR38U) {
			return true;
		}

		string tempstr = string.Empty;
		int index = 0;

		//Dim Startb As Integer
		//Startb = 1 'max "319"

		ClearBuffers();
		//Authentication command
		SendBuff[0] = 0xff;
		//Class
		SendBuff[1] = 0x86;
		//INS
		SendBuff[2] = 0x0;
		//P1
		SendBuff[3] = 0x0;
		//P2
		SendBuff[4] = 0x5;
		//Lc
		SendBuff[5] = 0x1;
		//Byte 1 : Version number
		SendBuff[6] = 0x0;
		//Byte 2
		SendBuff[7] = Startb;
		//Byte 3 : Block number

		SendBuff[8] = 0x60;
		//Byte 4 : Key Type A
		// SendBuff(8) = &H61                      'Byte 4 : Key Type B

		SendBuff[9] = Convert.ToInt32("&H" + "0");
		//Byte 5 : Key number

		SendLen = 10;
		RecvLen = 2;

		string outText1 = string.Empty;
		string outText2 = string.Empty;
		string outText3 = string.Empty;

		retCode = SendAPDU(ref outText1, ref outText2, ref outText3);
		if (retCode != SCARD_S_SUCCESS) {
			return false;
		} else {
			for (index = 0; index <= RecvLen - 1; index++) {
				tempstr = tempstr + Strings.Right("00" + Conversion.Hex(RecvBuff[index]), 2);
			}
			//Checking for response
			if (tempstr == "9000") {
				return true;
			//Call MsgBox("Authentication success")
			} else {
				return false;
				Interaction.MsgBox("Authentication failed");
			}
		}
	}

	private void DisConnectCard()
	{
		 // ERROR: Not supported in C#: OnErrorStatement

		retCode = SCardDisconnect(hCard, SCARD_UNPOWER_CARD);
		retCode = SCardReleaseContext(hContext);
	}


	private byte[] ReadDefaultBlockSet(int forBlock, int blockSize)
	{
		int index = 0;
		string tempstr = string.Empty;

		if (blockSize > 16) {
			blockSize = 16;
		}

		ClearBuffers();
		//Read Binary Block command
		SendBuff[0] = 0xff;
		//Class
		SendBuff[1] = 0xb0;
		//INS
		SendBuff[2] = 0x0;
		//P1
		SendBuff[3] = Convert.ToInt32("&H" + forBlock);
		//P2 : Block number
		SendBuff[4] = blockSize;
		//Le : Number of bytes to read

		SendLen = 5;
		RecvLen = blockSize + 2;

		string outText1 = string.Empty;
		string outText2 = string.Empty;
		string outText3 = string.Empty;

		retCode = SendAPDU(ref outText1, ref outText2, ref outText3);

		if (retCode != SCARD_S_SUCCESS) {
			return null;
		} else {
			for (index = RecvLen - 2; index <= RecvLen - 1; index++) {
				tempstr = tempstr + Strings.Right("00" + Conversion.Hex(RecvBuff[index]), 2);
			}
			//Check for response
			if (tempstr == "9000") {
				return RecvBuff;
			} else {
				Interaction.MsgBox("Read block error!");
			}
		}
		return null;

	}

	private bool WriteDefaultBlockSet(int forBlock, byte[] wData)
	{
		int index = 0;
		string tempstr = string.Empty;

		int blockSize = 16;

		ClearBuffers();
		//Read Binary Block command
		SendBuff[0] = 0xff;
		//Class
		SendBuff[1] = 0xd6;
		//INS
		SendBuff[2] = 0x0;
		//P1
		SendBuff[3] = Convert.ToInt32("&H" + forBlock);
		//P2 : Block number
		SendBuff[4] = blockSize;
		//Le : Number of bytes to read

		Array.Copy(wData, 0, SendBuff, 5, wData.Length);

		SendLen = blockSize + 5;
		RecvLen = 0x2;

		string outText1 = string.Empty;
		string outText2 = string.Empty;
		string outText3 = string.Empty;

		retCode = SendAPDU(ref outText1, ref outText2, ref outText3);

		if (retCode != SCARD_S_SUCCESS) {
			return false;
		} else {
			for (index = RecvLen - 2; index <= RecvLen - 1; index++) {
				tempstr = tempstr + Strings.Right("00" + Conversion.Hex(RecvBuff[index]), 2);
			}
			//Check for response
			if (tempstr == "9000") {
				return true;
			} else {
				Interaction.MsgBox("Write block error!");
			}
		}
		return false;

	}


	private void WriteDefaultBlockData(string wData)
	{
		int BytesWriteCount = 0;
		byte[] Bytes2Write = null;
		int BytesWritten = 0;
		int CurrentBlockNumber = 0;
		int CurrentBlockCapacity = 0;
		int index = 0;

		CurrentBlockNumber = 1;
		wData = ASCIIEncoding.ASCII.GetString(BitConverter.GetBytes(Convert.ToInt16(wData.Length)), 0, 2) + wData;
		Bytes2Write = ASCIIEncoding.ASCII.GetBytes(wData);
		BytesWriteCount = Bytes2Write.Length;


		while ((BytesWriteCount > 0)) {
			if (((CurrentBlockNumber + 1) % 4) == 0) {
				CurrentBlockCapacity = 0;
			} else {
				CurrentBlockCapacity = 16;
			}

			if ((CurrentBlockNumber == 1 | (CurrentBlockNumber % 4) == 0)) {
				if (!AuthCard(CurrentBlockNumber))
					return;
			}


			if (CurrentBlockCapacity > 0) {
				if (BytesWriteCount < CurrentBlockCapacity) {
					byte[] BlockBytes2Write = new byte[BytesWriteCount];
					Array.Copy(Bytes2Write, BytesWritten, BlockBytes2Write, 0, BlockBytes2Write.Length);

					WriteDefaultBlockSet(CurrentBlockNumber, BlockBytes2Write);
					BytesWritten += BlockBytes2Write.Length;
				} else {
					byte[] BlockBytes2Write = new byte[CurrentBlockCapacity];
					Array.Copy(Bytes2Write, BytesWritten, BlockBytes2Write, 0, CurrentBlockCapacity);

					WriteDefaultBlockSet(CurrentBlockNumber, BlockBytes2Write);
					BytesWritten += CurrentBlockCapacity;
				}

				BytesWriteCount = BytesWriteCount - BytesWritten;

			}
			CurrentBlockNumber = CurrentBlockNumber + 1;

		}
		return;

	}

	private string ReadDefaultBlockData()
	{

		if (CardTypeACR38U) {
			//call reader
			//check file
			//get/assign results
			return string.Empty;
		}

		int BytesReadCount = 0;
		byte[] BytesRead = null;
		int CurrentBlockNumber = 0;
		int CurrentBlockCapacity = 0;
		string DataStr = string.Empty;
		int index = 0;

		CurrentBlockNumber = 1;
		BytesRead = ReadDefaultBlockSet(1, 2);
		BytesReadCount = Convert.ToInt32(BytesRead[0]) + 2;


		while ((BytesReadCount > 0)) {
			if (((CurrentBlockNumber + 1) % 4) == 0) {
				CurrentBlockCapacity = 0;
			} else {
				CurrentBlockCapacity = 16;
			}

			if ((CurrentBlockNumber == 1 | (CurrentBlockNumber % 4) == 0)) {
				if (!AuthCard(CurrentBlockNumber))
					return string.Empty;
			}


			if (CurrentBlockCapacity > 0) {
				if (BytesReadCount < CurrentBlockCapacity) {
					BytesRead = ReadDefaultBlockSet(CurrentBlockNumber, BytesReadCount);
				} else {
					BytesRead = ReadDefaultBlockSet(CurrentBlockNumber, CurrentBlockCapacity);
				}

				for (index = 0; index <= RecvLen - 3; index++) {
					if (CurrentBlockNumber == 1) {
						if (index > 1)
							DataStr = DataStr + Strings.Right(Strings.Chr(BytesRead[index]), 2);
					} else {
						DataStr = DataStr + Strings.Right(Strings.Chr(BytesRead[index]), 2);
					}
				}

				BytesReadCount = BytesReadCount - (RecvLen - 2);

			}
			CurrentBlockNumber = CurrentBlockNumber + 1;

		}
		return Strings.Replace(DataStr, Strings.Chr(0), "");

	}

	private long SendAPDU(ref string outText1, ref string outText2, ref string outText3)
	{

		int index = 0;
		string tempstr = null;

		ioRequest.dwProtocol = Protocol;
		ioRequest.cbPciLength = Strings.Len(ioRequest);

		tempstr = "";

		for (index = 0; index <= SendLen - 1; index++) {
			tempstr = tempstr + Strings.Right("00" + Conversion.Hex(SendBuff[index]), 2) + " ";
		}

		outText1 = tempstr;
		//Call MsgBox(tempstr)

		retCode = SCardTransmit(hCard, ioRequest, SendBuff[0], SendLen, ioRequest, RecvBuff[0], RecvLen);

		if (retCode != SCARD_S_SUCCESS) {
			outText2 = GetScardErrMsg(retCode);
			//Call MsgBox(GetScardErrMsg(retCode))
			return retCode;

		}

		tempstr = "";

		for (index = 0; index <= RecvLen - 1; index++) {
			tempstr = tempstr + Strings.Right("00" + Conversion.Hex(RecvBuff[index]), 2) + " ";
		}

		outText3 = tempstr;
		//Call MsgBox(tempstr)
		return retCode;

	}

	//This Method writes Data String (upto 752 bytes) to the SmartCard from the device and
	//returns false if fails
	public bool Write2SmartCard(string SmartCardDataStr)
	{
		 // ERROR: Not supported in C#: OnErrorStatement

		//Try


		bool CardConnected = false;
		CardConnected = Connect2Card();
		if (!CardConnected) {
			DisConnectCard();
			return false;
		}

		if (!AuthCard(1)) {
			DisConnectCard();
			Interaction.MsgBox("Authentication Failure");
			return string.Empty;
		}

		//old card so no write operation supported
		if (CardTypeACR38U) {
			return false;
		}
		LogThis(string.Concat(DateTime.Now) + "(Before Write) : " + SmartCardDataStr);
		WriteDefaultBlockData(SmartCardDataStr);
		if (Err().Number > 0) {
			return false;
		}
		LogThis(string.Concat(DateTime.Now) + "(After Write) : " + SmartCardDataStr);
		//Catch ex As Exception
		//    LogThis(ex)
		//End Try
		return true;

	}
	public bool IsCardConnected()
	{
		 // ERROR: Not supported in C#: OnErrorStatement

		bool CardConnected = false;
		return CardConnected == Connect2Card();

	}

	//This Method reads the SmartCard Data from the device and
	//returns the stored data as String
	public string ReadSmartCardDataStr()
	{

		 // ERROR: Not supported in C#: OnErrorStatement


		bool CardConnected = false;

		CardConnected = Connect2Card();
		if (!CardConnected) {
			DisConnectCard();
			return string.Empty;
		}

		isCardTypeACR38U = CardTypeACR38U;

		//For "ACS ACR38U 0"

		if (CardTypeACR38U) {
			if (File.Exists("c:\\BGCCARD\\Success.txt"))
				FileSystem.Kill("c:\\BGCCARD\\Success.txt");
			if (File.Exists("c:\\BGCCARD\\Read.txt"))
				FileSystem.Kill("c:\\BGCCARD\\Read.txt");

			ShellandWait("c:\\BGCCARD\\read.exe", "", 0, ProcessWindowStyle.Hidden);

			if (File.Exists("c:\\BGCCARD\\Success.txt")) {
				//Success
				string sContent = Strings.Trim(File.ReadAllText("c:\\BGCCARD\\Read.txt"));

				if (string.IsNullOrEmpty(sContent)) {
					Interaction.MsgBox("Could not read the card! Please try again.");
					return string.Empty;
				} else {
					return Strings.Trim(Strings.Split(sContent, "~")[14]);
				}

			} else {
				Interaction.MsgBox("Could not read the card! Please try again.");
				return string.Empty;
			}
		}

		if (!AuthCard(1)) {
			DisConnectCard();
			Interaction.MsgBox("Authentication Failure");
			return string.Empty;
		}

		return ReadDefaultBlockData();

	}


	protected override void Finalize()
	{
		base.Finalize();
		DisConnectCard();
	}
}

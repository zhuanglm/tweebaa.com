namespace Moneris
{
    using System;
    
	public class TestReauthEfraud
	{
	  public static void Main(string[] args)
	  {
          string host = "esqa.moneris.com";
          string store_id = "store5";
          string api_token = "yesguy";

          string order_id = "Need_Unique_Order_ID_123456";
          string orig_order_id = "Need_Unique_Order_ID_12345";
          string amount = "304.00";
          string txn_number = "174885-0_7";
          string crypt = "7";
	        
	        /*************** Address Verification Service **********************/
	        
	       	AvsInfo avsCheck = new AvsInfo();	
	       	
	       	avsCheck.SetAvsStreetNumber ("212");
	       	avsCheck.SetAvsStreetName ("Payton Street");
	       	avsCheck.SetAvsZipCode ("M1M1M1");
            avsCheck.SetAvsEmail ("test@host.com");
            avsCheck.SetAvsHostname ("hostname");
            avsCheck.SetAvsBrowser ("Mozilla");
            avsCheck.SetAvsShipToCountry ("Canada");
            avsCheck.SetAvsShipMethod ("Ground");
            avsCheck.SetAvsMerchProdSku ("123456");
            avsCheck.SetAvsCustIp ("192.168.0.1");
            avsCheck.SetAvsCustPhone ("5556667777");

            ReAuth reauthTxn = new ReAuth(order_id, orig_order_id, txn_number, amount, crypt);
	       	reauthTxn.SetAvsInfo (avsCheck);       	
	       	
	       	/****************** Card Validation Digits *************************/
	       	
	       	CvdInfo cvdCheck = new CvdInfo();
	       	cvdCheck.SetCvdIndicator ("1");
	       	cvdCheck.SetCvdValue ("099");
	       	
	       	reauthTxn.SetCvdInfo (cvdCheck);	       	
	       	
	       	/************************** Request *************************/	       	
	
	        HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token,reauthTxn);	 
	            
	        /************************** Receipt *************************/	
	
	        try
	        {
	           	Receipt receipt = mpgReq.GetReceipt();
	
	    		Console.WriteLine("CardType = " + receipt.GetCardType());
	    		Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
	    		Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
	    		Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
	    		Console.WriteLine("TransType = " + receipt.GetTransType());
	    		Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
	    		Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
	    		Console.WriteLine("ISO = " + receipt.GetISO());
	    		Console.WriteLine("BankTotals = " + receipt.GetBankTotals());
	    		Console.WriteLine("Message = " + receipt.GetMessage());
	    		Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
	    		Console.WriteLine("Complete = " + receipt.GetComplete());
	    		Console.WriteLine("TransDate = " + receipt.GetTransDate());
	    		Console.WriteLine("TransTime = " + receipt.GetTransTime());
	    		Console.WriteLine("Ticket = " + receipt.GetTicket());
	    		Console.WriteLine("TimedOut = " + receipt.GetTimedOut ());   
	    		Console.WriteLine("Avs Response = " + receipt.GetAvsResultCode());
	    		Console.WriteLine("Cvd Response = " + receipt.GetCvdResultCode());
                Console.WriteLine("IsVisaDebit = " + receipt.GetIsVisaDebit());


	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} // end TestReauth
}

namespace Moneris
{
    using System;
    
	public class TestPurchaseEfraud
	{
	  public static void Main(string[] args)
	  {
	  
	  	/********************** Post Request Variables *************************/
	  
	        string host = "esqa.moneris.com";
	        string store_id = "store5";
	        string api_token = "yesguy";
	        
	        /********************** Transactional Variables **********************/
	        
	        string order_id = "Test_eFraud_dotNET_1234";
	        string amount = "10.02";
	        string pan = "4242424242424242";
	        string expiry_date = "1111";
	        string crypt = "7";
	        
	        /*************** Address Verification Service **********************/
	        
	       	AvsInfo avsCheck = new AvsInfo();	
	       	
	       	avsCheck.SetAvsStreetNumber ("212");
	       	avsCheck.SetAvsStreetName ("Payton Street");
	       	avsCheck.SetAvsZipCode ("M1M1M1");
            avsCheck.SetAvsEmail("test@host.com");
            avsCheck.SetAvsHostname("hostname");
            avsCheck.SetAvsBrowser("Mozilla");
            avsCheck.SetAvsShipToCountry("CAN");
            avsCheck.SetAvsShipMethod("G");
            avsCheck.SetAvsMerchProdSku("123456");
            avsCheck.SetAvsCustIp("192.168.0.1");
            avsCheck.SetAvsCustPhone("5556667777");
	       	
	       	Purchase purchaseTxn = new Purchase(order_id, amount, pan, expiry_date, crypt);
	       	purchaseTxn.SetAvsInfo (avsCheck);       	
	       	
	       	/****************** Card Validation Digits *************************/
	       	
	       	CvdInfo cvdCheck = new CvdInfo();
	       	cvdCheck.SetCvdIndicator ("1");
	       	cvdCheck.SetCvdValue ("099");
	       	
	       	purchaseTxn.SetCvdInfo (cvdCheck);	       	
	       	
	       	/************************** Request *************************/	       	
	
	        HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token,purchaseTxn);
	            
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
                Console.WriteLine("ITD Response = " + receipt.GetITDResponse());
                Console.WriteLine("IsVisaDebit = " + receipt.GetIsVisaDebit());
	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} // end TestPurchase
}

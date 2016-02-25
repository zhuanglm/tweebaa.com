namespace Moneris
{
    using System;
    using System.Collections;

	public class TestPurchaseVBV
	{
	  public static void Main(string[] args)
	  {
	  
		/******************** Post Request Variables ********************************/
	  
	        string host = "esqa.moneris.com";
	        string store_id = "store5";
	        string api_token = "yesguy";
	        
	        /******************** Transactional Variables ******************************/
	        
	        string order_id = "Need_Unique_Order_ID_12345";
		    string cust_id = "CUS887H67";
	        string amount = "1.00";
	        string pan = "4242424242424242";
	        string expiry_date = "1111";
	        string cavv = "AAABBJg0VhI0VniQEjRWAAAAAAA=";
            string dynamic_descriptor = "123456";
	        
	        /************************ Transaction Object Option1 *************************/
	        
	       	CavvPreAuth cavvPreauth 
				= new CavvPreAuth (order_id, cust_id, amount, pan, expiry_date, cavv);

            cavvPreauth.SetDynamicDescriptor(dynamic_descriptor);

	        /************************ Transaction Object Option2 *************************/
	        
	        Hashtable cavvParams = new Hashtable();	//transaction hashtable option
		    cavvParams.Add("order_id",order_id);
		    cavvParams.Add("cust_id",cust_id);
		    cavvParams.Add("amount",amount);
		    cavvParams.Add("pan",pan);
		    cavvParams.Add("expdate",expiry_date);
		    cavvParams.Add("cavv",cavv);

	        CavvPreAuth cavvPreauth2 
	        		= new CavvPreAuth(cavvParams); //single paramater hashtable construtor

    		/*************************** Https Post Request *****************************/

	        HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token, cavvPreauth2);
	            
	        /****************************** Receipt *************************************/
	        
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
	    		Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("CavvResultCode = " + receipt.GetCavvResultCode());
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} // end TestCavvPreauth
}

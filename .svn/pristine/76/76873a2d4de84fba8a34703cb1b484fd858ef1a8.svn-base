namespace Moneris
{
    using System;
    
	public class TestPreAuth
	{
	  public static void Main(string[] args)
	  {

		string host = "esqa.moneris.com";
		string order_id = "Need_Unique_Order_ID_12345";
		string store_id = "store5";
		string api_token = "yesguy";
		string amount = "304.00";
		string pan = "5454545454545454";
		string expdate = "0812";
		string crypt = "7";


        PreAuth preauth = new PreAuth(order_id, amount, pan, expdate, crypt);

        //preauth.SetDynamicDescriptor("123456");

        HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, preauth);
	                       
	                     
		/**********************   REQUEST  ************************/	                     
	                     
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
                Console.WriteLine("IsVisaDebit = " + receipt.GetIsVisaDebit());
	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} // end TestPreauth
}

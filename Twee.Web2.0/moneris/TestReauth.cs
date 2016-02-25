namespace Moneris
{
    using System;
    
	public class TestReauth
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
        string dynamic_descriptor = "123456";

        ReAuth ra = new ReAuth(order_id, orig_order_id, txn_number, amount, crypt);

        ra.SetDynamicDescriptor(dynamic_descriptor);

        HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, ra);
	                     
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
				
	} // end TestReauth
}

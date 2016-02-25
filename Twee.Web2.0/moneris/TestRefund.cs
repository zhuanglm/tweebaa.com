namespace Moneris
{
    using System;
	public class TestRefund
	{
	  public static void Main(string[] args)
	  {
            string host = "esqa.moneris.com";
            string store_id = "store5";
            string api_token = "yesguy";
            string order_id = "Test_eFraudkdsskdkdk";
            string amount = "5.00";
            string txn_number = "153150-4-0";
            string crypt = "7";
            string dynamic_descriptor = "123456";
	
            Refund r = new Refund(order_id, amount, txn_number, crypt);

            r.SetDynamicDescriptor(dynamic_descriptor);

            HttpsPostRequest mpgReq = new HttpsPostRequest(host, store_id, api_token, r);
	
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

	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} // end TestRefund
}

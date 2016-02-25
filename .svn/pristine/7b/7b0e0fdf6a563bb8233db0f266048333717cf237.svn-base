namespace Moneris
{
    using System;
    using System.Collections;

	public class MyTestPurchaseCustInfo
	{
	  public static void Main(string[] args)
	  {
	  	
	  	/********************* Post Request Variables ********************************/
	  	
	        string host = "esqa.moneris.com";
	        string store_id = "store5";
	        string api_token = "yesguy";
	        
	        /********************* Transactional Variables *******************************/
	        
	        string order_id = "Need_Unique_Order_ID";
	        string amount = "10.00";
	        string pan = "4242424242424242";
	        string expiry_date = "0812";
	        string crypt = "7";

		/************************* Recur Variables **********************************/

	        string recur_unit = "month"; //eom = end of month
	        string start_now = "true";
	        string start_date = "2006/07/28";
	        string num_recurs = "12";
	        string period = "1";
	        string recur_amount = "30.00";
	        
	        /************************* Recur Object Option1 ******************************/
	        
	        Recur recurring_cycle = new Recur (recur_unit, start_now, start_date, 
	        				   num_recurs, period, recur_amount);
	        				   
		/************************* Recur Object Option2 ******************************/
		
		Hashtable recur_hash = new Hashtable();
		
		recur_hash.Add ("recur_unit", recur_unit);
		recur_hash.Add ("start_now", start_now);
		recur_hash.Add ("start_date", start_date);
		recur_hash.Add ("num_recurs", num_recurs);
		recur_hash.Add ("period", period);
		recur_hash.Add ("recur_amount", recur_amount);
		
		Recur recurring_cycle2 = new Recur (recur_hash);      				   
	        				   
		/************************ Transactional Object *******************************/
		
		Purchase purchase = new Purchase (order_id, amount, pan, expiry_date, crypt);
	        				   
		/******************************* Set Recur ***********************************/
		
		purchase.SetRecur (recurring_cycle);        
	
		/**************************** Https Post Request ***************************/
	
	        HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token, purchase);
	
		/******************************* Receipt ***********************************/
	
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
	    		Console.WriteLine("Recur Success = " + receipt.GetRecurSuccess());
                Console.WriteLine("IsVisaDebit = " + receipt.GetIsVisaDebit());
	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} // end TestDrive Item
}

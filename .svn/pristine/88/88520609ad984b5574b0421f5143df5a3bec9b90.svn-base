namespace Moneris
{
    using System;
	public class TestRecurUpdate
	{
	  public static void Main(string[] args)
	  {
	        string host = "esqa.moneris.com";
	        string store_id = "store5";
	        string api_token = "yesguy";
	        string order_id = "VM-10006";
            string cust_id = "antonio";
	        string recur_amount = "1.50";
	        string pan = "4242424242424242";
	        string expiry_date = "1111";
            //string add_num = "";
            //string total_num = "";
            //string hold = "";
            //string terminate = "";

            RecurUpdate recurUpdate = new RecurUpdate(order_id);
            
            recurUpdate.setCustId(cust_id);
            recurUpdate.setRecurAmount(recur_amount);
            recurUpdate.setPan(pan);
            recurUpdate.setExpiryDate(expiry_date);
            //recurUpdate.setAddNumRecurs(add_num);
            //recurUpdate.setTotalNumRecurs(total_num);
            //recurUpdate.setHold(hold);
            //recurUpdate.setTerminate(terminate);

            HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token, recurUpdate);
	
            
	        try
	        {
	            Receipt receipt = mpgReq.GetReceipt();
	
	    		Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
	    		Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
	    		Console.WriteLine("Message = " + receipt.GetMessage());
	    		Console.WriteLine("Complete = " + receipt.GetComplete());
	    		Console.WriteLine("TransDate = " + receipt.GetTransDate());
	    		Console.WriteLine("TransTime = " + receipt.GetTransTime());
	    		Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("RecurUpdateSuccess = " + receipt.GetRecurUpdateSuccess());
                Console.WriteLine("NextRecurDate = " + receipt.GetNextRecurDate());
                Console.WriteLine("RecurEndDate = " + receipt.GetRecurEndDate());
	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} // end TestRecurUpdate
}

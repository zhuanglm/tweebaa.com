namespace Moneris
{
    using System;
    
	public class TestIDebitPurchase
	{
	  public static void Main(string[] args)
	  {
	        string host = "esqa.moneris.com";
	        string store_id = "store5";
	        string api_token = "yesguy";
	        string order_id = "Need_Unique_Order_ID_Cust_Info_005";
		    string cust_id = "Lance_Briggs_55";
	        string amount = "5.00";
	        string track2 = "5268051119993326=0609AAAAAAAAAAAAA000";

		  /********************* Billing/Shipping Variables ****************************/
	        
		  string first_name = "Bob";
		  string last_name = "Smith";
		  string company_name = "ProLine Inc.";
		  string address = "623 Bears Ave";
		  string city = "Chicago";
		  string province = "Illinois";
		  string postal_code = "M1M2M1";
		  string country = "Canada";
		  string phone = "777-999-7777";
		  string fax = "777-999-7778";
		  string tax1 = "10.00";
		  string tax2 = "5.78";
		  string tax3 = "4.56";
		  string shipping_cost = "10.00";
	        
		  /********************* Order Line Item Variables *****************************/
	        
		  string[] item_description = new string[]{"Chicago Bears Helmet", "Soldier Field Poster"};
		  string[] item_quantity = new string[]{"1", "1"};
		  string[] item_product_code = new string[]{"CB3450", "SF998S"};
		  string[] item_extended_amount = new string[]{"150.00", "19.79"};       
	        
		  /********************** Customer Information Object **************************/
	        
		  CustInfo customer = new CustInfo();
	        
		  /********************** Set Customer Billing Information **********************/
	        
		  customer.SetBilling (first_name, last_name, company_name, address, city,
							   province, postal_code, country, phone, fax, tax1, tax2, 
							   tax3, shipping_cost);	        
	        
		  /******************** Set Customer Shipping Information ***********************/
	        		     
		  customer.SetShipping (first_name, last_name, company_name, address, city,
								province, postal_code, country, phone, fax, tax1, tax2, 
								tax3, shipping_cost);	
	        		     
		  /***************************** Order Line Items  ******************************/
	         
		  customer.SetItem (item_description[0], item_quantity[0],	    
							item_product_code[0], item_extended_amount[0]);
	        		  
		  customer.SetItem (item_description[1], item_quantity[1],
							item_product_code[1], item_extended_amount[1]);
	        
	       	/************************** Request *************************/	   
    	
		    IDebitPurchase IOP_Txn = new IDebitPurchase (order_id, cust_id, amount, track2);

		    IOP_Txn.SetCustInfo (customer);

            //IOP_Txn.SetDynamicDescriptor("dynamicdescriptor1");

	        HttpsPostRequest mpgReq =
	            new HttpsPostRequest(host, store_id, api_token, IOP_Txn);

			
	            		
	
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
				
	} // end TestDrive Item
}

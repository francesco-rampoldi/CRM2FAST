using CRM_FAST.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using System.Data.Entity.SqlServer;

namespace CRM_FAST
{
	class CRM_FAST : IDisposable
	{
		Session session = null;
		FASTEntities FE = null;

		public void Run()
		{

			try
			{
				// Establish connection and login to SalesForce
				// Pass login and password as parameters
			  
				//session = new Session("fast.interface@kone.com.full", "Qas120lop"); //Qas120lop  test environment credentials
				session = new Session(Properties.Settings.Default.SFDC_API_WS_Login, Properties.Settings.Default.SFDC_API_WS_Pwd ); 

				// Display session ID
				// It can be used to access other SalesForce services e.g. with REST API
				Topgraf.LibManager.Logger.LogInfo("Session ID is: " + session.SessionInformation.sessionId);
				 FE = new FASTEntities();
				DateTime? LastUpdateDtime;
				try
				{
					LastUpdateDtime = (from O in FE.DAT_SF_opportunities group O by true into G select G.Max(z => z.UpdateDtime)).FirstOrDefault();

				}
				catch (Exception Ex)
				{
					Topgraf.LibManager.Logger.LogFatal("Fatal error retrieving last update date from FAST DB. Execution aborted.", Ex);
					throw;
				}
				List<Opportunity> oppsList;
				if (LastUpdateDtime.HasValue)
				{
					Topgraf.LibManager.Logger.LogInfo("Opportunities Last updated on : " + LastUpdateDtime.Value);
					oppsList = getOpportunity(LastUpdateDtime.Value, DateTime.Now);
				}
				else
				{
					Topgraf.LibManager.Logger.LogInfo("Opportunities never updated. Reading rows from 2013-01-01");
					oppsList = getOpportunity(Properties.Settings.Default.Opp_clean_import_start_date, DateTime.Now);
				}
				//TODO: get last update datetime from table DAT_OPPORTUNITIES

				// Get opportunities from selected time period
				// We have an Opportinty type constructed from Enterprise WSDL


				DAT_SF_opportunities result;

				//for each opportunity in query result from CRM, check if exists in FAST DB. If yes, update row, if no Create new row.
				if(oppsList != null  && oppsList.Count > 0){
					int updated = 0;
					int created = 0;
					Topgraf.LibManager.Logger.LogInfo("\nUpdating  DB...\n");
					for (int i = 0; i < oppsList.Count; i++)
					{
						//if yes, update opportunity, if not, insert new opportunity
						string opp_ID = oppsList[i].Id;
						result = (from O in FE.DAT_SF_opportunities
								  where O.ID == opp_ID
								  select O).FirstOrDefault();
						if (result != null)
						{
							if (result.UpdateDtime < oppsList[i].LastModifiedDate.GetValueOrDefault())
							{
								FillResult(oppsList, result, i);
								try
								{
									FE.SaveChanges();
									updated++;
								}
								catch //(Exception Ex)
								{
									
									throw ;
								}
							}
						}
						else
						{
							result = new DAT_SF_opportunities();
							result.ID = oppsList[i].Id;
							FillResult(oppsList, result, i);
							try
							{
								FE.DAT_SF_opportunities.Add(result);
								FE.SaveChanges();
								created++;
							}
							catch //(Exception Ex)
							{
								
								throw;
							}
						}
						// Check if owner is in DB
						DAT_SF_owners opp_own = (from OW in FE.DAT_SF_owners where OW.SAP_OWNER == result.SF_OwnerID select OW).FirstOrDefault();
						if (opp_own != null)
						{
							if (string.IsNullOrEmpty(opp_own.KAI))
							{
								string owner_email = oppsList[i].Owner.Email;
								Venditori V = (from v in FE.Venditori where v.email == owner_email select v).FirstOrDefault();
								if (V != null)
								{

									if (!string.IsNullOrEmpty(V.KAI))
									{
										opp_own.KAI = V.KAI;
										V.SAP_OWNER = opp_own.SAP_OWNER;
										FE.SaveChanges();

									}
								}
								else
								{
									Topgraf.LibManager.Logger.LogError("Impossibile trovare il venditore associato all'opportunità # {0}.ownerId {2} email da SFDC {1}", result.Opportunity_Code, owner_email, oppsList[i].OwnerId);
								}
							}
						}
						else
						{
							string owner_email = oppsList[i].Owner.Email;

							Venditori V = (from v in FE.Venditori where v.email.Contains(owner_email) select v).FirstOrDefault();
							string KAI = null;
							if (V != null)
							{

								V.SAP_OWNER = result.SF_OwnerID;
								KAI = V.KAI;
							}
							else
							{
								Topgraf.LibManager.Logger.LogError("Impossibile trovare il venditore associato all'opportunità # {0}.ownerId {2} email da SFDC {1}", result.Opportunity_Code, owner_email, oppsList[i].OwnerId);
							}
							opp_own = new DAT_SF_owners() { SAP_OWNER = result.SF_OwnerID, EMAIL = owner_email, KAI = KAI };
							FE.DAT_SF_owners.Add(opp_own);
							FE.SaveChanges();

						}

						if (oppsList != null)
							Console.WriteLine(oppsList[i].Name.ToString());
					} // end For
					Topgraf.LibManager.Logger.LogInfo("Updated {0} records in DAT_SF_OPPORTUNITIES", updated);
					Topgraf.LibManager.Logger.LogInfo("Created {0} records in DAT_SF_OPPORTUNITIES", created);
				} // end if - update DB - block
			}
			catch (Exception Ex)
			{
				Topgraf.LibManager.Logger.LogFatal("Fatal Error in main procedure, Aborting Execution.", Ex);
				//TODO: send email to administrator.
			}
			finally
			{
				if (session.SessionInformation.sessionId != null)
				{
					try 
					{	        
						session.Service.logout();
					}
					catch (Exception Ex)
					{

						Topgraf.LibManager.Logger.LogError("Error in session service logout. ", Ex);
					}
					
				}
				if (FE != null)
				{
					FE.Dispose();
				}
					
			}


		} // end Run() method

		private static void FillResult(List<Opportunity> oppsList, DAT_SF_opportunities result, int i)
		{
			result.ACCOUNTID = oppsList[i].AccountId;
			result.AMOUNT = (float)oppsList[i].Amount.GetValueOrDefault();
			result.BUSINESS_TYPE = oppsList[i].Business_Type__c;
			result.Opportunity_Category = oppsList[i].Opportunity_Category__c;
			result.Description = oppsList[i].Name;
			result.ISCLOSED = string.Format("{0:t;0;f}", Convert.ToInt32(oppsList[i].IsClosed.GetValueOrDefault()));
			result.ISWON = string.Format("{0:t;0;f}", Convert.ToInt32(oppsList[i].IsWon.GetValueOrDefault()));
			result.Offerta_DataPrevistaChiusura = oppsList[i].CloseDate.GetValueOrDefault().ToString("yyyyMMdd");
			result.Offerta_ProbabilitaAggiudicazione = oppsList[i].Probability.GetValueOrDefault().ToString();
			result.Opportunity_Code = oppsList[i].KONE_Opportunity_Number__c;
			if (oppsList[i].Account != null)
			{
				result.Party_CITY = oppsList[i].Account.BillingCity;
				result.Party_FAX = oppsList[i].Account.Fax;
				result.Party_IDParty = oppsList[i].Account.AccountNumber;
				result.Party_Indirizzo = oppsList[i].Account.BillingStreet;
				result.Party_PHONE = oppsList[i].Account.Phone;
				result.Party_POSTAL_CODE = oppsList[i].Account.BillingPostalCode;
				result.Party_RagioneSociale = oppsList[i].Account.Name;
				result.Party_REGION = oppsList[i].Account.BillingState;
			} else
			{  // if no account then set to null all party fields (there should always be an account linked to the opportunity)
				result.Party_CITY = null;
				result.Party_FAX = null;
				result.Party_IDParty = null;
				result.Party_Indirizzo = null;
				result.Party_PHONE = null;
				result.Party_POSTAL_CODE = null;
				result.Party_RagioneSociale = null;
				result.Party_REGION = null;
			}
			// fill sold-to-party fields if Partner record is present
			if (oppsList[i].Partners__r != null)
			{
				foreach (Partner__c partner in oppsList[i].Partners__r.records)
				{
					if (partner.Partner__r != null)
					{
						result.sold_to_Party_RagioneSociale = partner.Partner__r.Name;
						result.sold_to_Party_CITY = partner.Partner__r.BillingCity;
						result.sold_to_Party_FAX = partner.Partner__r.Fax;
						result.sold_to_Party_IDParty = partner.Partner__r.AccountNumber;
						result.sold_to_Party_Indirizzo = partner.Partner__r.BillingStreet;
						result.sold_to_Party_PHONE = partner.Partner__r.Phone;
						result.sold_to_Party_POSTAL_CODE = partner.Partner__r.BillingPostalCode;
						result.sold_to_Party_RagioneSociale = partner.Partner__r.Name;
						result.sold_to_Party_REGION = partner.Partner__r.BillingState;
					}
					else
					{
						Topgraf.LibManager.Logger.LogWarn("partner__r object is null. check partner visibility. ");
					}

				}

			}
			else
			{
				// if no sold to party is present, update related fields to null. 
				result.sold_to_Party_RagioneSociale = null;
				result.sold_to_Party_CITY = null;
				result.sold_to_Party_FAX = null;
				result.sold_to_Party_IDParty = null;
				result.sold_to_Party_Indirizzo = null;
				result.sold_to_Party_PHONE = null;
				result.sold_to_Party_POSTAL_CODE = null;
				result.sold_to_Party_RagioneSociale = null;
				result.sold_to_Party_REGION = null;
			}
			result.SALES_ORGANIZATION__CODE = oppsList[i].Sales_Organization__c;
			result.SF_OwnerID = oppsList[i].OwnerId;
			result.STAGENAME = oppsList[i].StageName;
			result.UpdateDtime = oppsList[i].LastModifiedDate.GetValueOrDefault();
		}

		/* This method will get opportunities from Italy
		* That were created in entered time period.
		* NOTE: Data in sandbox is about a year old */
		private List<Opportunity> getOpportunity(DateTime createdFrom, DateTime createdUntil)
		{
			string t1 = createdFrom.ToString("yyyy-MM-ddTHH:mm:ssZ");
			string t2 = createdUntil.ToString("yyyy-MM-ddTHH:mm:ssZ");
			bool done = false;

			// SOQL query - syntax is nearly same as normal SQL, documentation below:
			// http://www.salesforce.com/us/developer/docs/soql_sosl/index_Left.htm
			//string query = @"SELECT id, name, OwnerId, Owner.EmployeeNumber, Owner.FirstName , Owner.LastName, Owner.Email ,Owner.Alias, Owner.Sales_Office__c, Owner.UserName, Owner.Branch_Office__c, Owner.Camos_User__c, Business_Type__c, Opportunity_Category__c, Site_Country__c, KONE_Opportunity_Number__c, StageName, description, IsWon, IsClosed, Sales_Organization__c, Amount, CloseDate, Probability, Site_Street_Address__c, Site_City__c, Site_State_Province__c, Account.Fax, Account.Phone, AccountId, Account.Name, Account.NameLocal , Account.AccountNumber, Account.BillingCity, Account.BillingStreet, Account.BillingPostalCode, Account.BillingState, Account.BillingCountry, Account.Kone_Country__c, Account.Kone_City__c,  LastModifiedDate  FROM Opportunity  WHERE KONE_Opportunity_Number__c = '0003894633' AND Site_Country__c = 'Italy'";
			//string query = @"SELECT id, name, OwnerId, Owner.EmployeeNumber ,Owner.FirstName , Owner.LastName, Owner.Email ,Owner.Alias, Owner.Sales_Office__c, Owner.UserName, Owner.Branch_Office__c, Owner.Camos_User__c, Business_Type__c, Opportunity_Category__c, Site_Country__c, KONE_Opportunity_Number__c, StageName, description, IsWon, IsClosed, Sales_Organization__c, Amount, CloseDate, Probability, Site_Street_Address__c, Site_City__c, Site_State_Province__c, Account.Fax, Account.Phone, AccountId, Account.Name, Account.NameLocal , Account.AccountNumber, Account.BillingCity, Account.BillingStreet, Account.BillingPostalCode, Account.BillingState, Account.BillingCountry, Account.Kone_Country__c, Account.Kone_City__c,  LastModifiedDate  FROM Opportunity  WHERE LastModifiedDate > " + t1 + " AND LastModifiedDate < " + t2 + " AND Site_Country__c = 'Italy'";
			string query = string.Format(Properties.Settings.Default.Opp_getOpportunities_select_query, t1, t2);

			QueryResult qr = new QueryResult();
			try
			{
				Topgraf.LibManager.Logger.LogInfo("retrieving data from SFDC...");
				qr = session.Service.query(query);
			}
			catch (SoapException soapEx)
			{
				Topgraf.LibManager.Logger.LogFatal("Error retrieving data from SFDC.",soapEx);
				return null;
			}

			List<Opportunity> opps = new List<Opportunity>();
			if (qr.size > 0)
			{
				Topgraf.LibManager.Logger.LogInfo("\nNumber of opportunities found: " + qr.size.ToString());
				if (qr.size > qr.records.Count()) Topgraf.LibManager.Logger.LogInfo("retrieved first {0} records.", qr.records.Count());
				while (!done)
				{

					foreach (Opportunity opp in qr.records)
					{
						opps.Add(opp);
					}
					if (qr.done)
					{
						done = true;
					}
					else
					{
						Topgraf.LibManager.Logger.LogInfo("retrieving next batch from SFDC...");
						qr = session.Service.queryMore(qr.queryLocator);
						Topgraf.LibManager.Logger.LogInfo("retrieved {0} records.", qr.records.Count());
					}
				}
			}
			else
			{
				Topgraf.LibManager.Logger.LogInfo("No records found.");
			}



			return opps;
		}

		public void Dispose()
		{
			if (FE != null)
			{
				FE.Dispose();
			}
			if (session != null)
			{
				session.Dispose();
			}
		}
	}
}

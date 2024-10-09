public static void main(Args _args)
    {
        // Authorize API Request
		//Serialize body (Request Obj)
        AuthAPIRequestContract requestObject = new AuthAPIRequestContract();
        requestObject.client_id = "";
        requestObject.client_secret= "";
        requestObject.grant_type="client_credentials";
        requestObject.resource="";
        CLRObject request = requestObject;
        str requestJSON = SerializeDeserializeAbstract::SerializeObject(request);

		//Execute API - By passing the body
        RestSharp.RestResponse apiResponse = APIHelper::ExecuteFormEncodedAPIRequest("Base URL","Route","Headers","JSONBODY",RestSharp.Method::POST);
		//Capture response content into str
        str responseJSON = apiResponse.Content;
		// deserialize JSON to response object
        SerializeDeserializeHelper helper = new SerializeDeserializeHelper();
        AuthAPIResponse responseObject = new AuthAPIResponse();
        responseObject = helper.DeserializeJSON(responseJSON,responseObject.GetType());
       
		// use the response Object parms as required
        info(responseObject.access_token);
        info(strFmt("%1",responseObject.expires_in));
		// OData Request

        //Execute API - 
        str headers = "Authorization:Bearer "+responseObject.access_token;
		//headers pattern "Key1:Value1,Key2:Value2"
        RestSharp.RestResponse apiresp = APIHelper::ExecuteFormEncodedAPIRequest("Base URL","Route","Headers","JSONBODY",RestSharp.Method::POST);
        if(apiresp.StatusCode == System.Net.HttpStatusCode::OK || apiresp.StatusCode == System.Net.HttpStatusCode::Created || apiresp.StatusCode == System.Net.HttpStatusCode::Accepted)
        {
            //Capture response content into str
            str respoJSON = apiresp.Content;
            // deserialize JSON to response object
            FOCustomerResponse respObject =new FOCustomerResponse();
            respObject = helper.DeserializeJSON(respoJSON,respObject.GetType());
        
            System.Collections.IEnumerable enum;
            System.Collections.IEnumerator iter;
            enum = respObject.customers;
            iter = enum.GetEnumerator();

            while(iter.MoveNext())
            {
                Customer individualCust = iter.Current;
                info(individualCust.VLSFOLink);
            }
        }
    }
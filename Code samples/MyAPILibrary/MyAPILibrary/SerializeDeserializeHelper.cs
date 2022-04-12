using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FinOpsRestAPILibrary;
using RestSharp;
using MyAPILibrary.ReqResModels;
using System.Reflection;

namespace MyAPILibrary
{
    public class SerializeDeserializeHelper : SerializeDeserializeAbstract
    {
        public override object DeserializeJSON(string _JSON, Type _responseObjectType)
        {
            object ret = null;
            switch (_responseObjectType.Name)
            {
                case nameof(CreateUserResponse):
                    ret = JsonConvert.DeserializeObject<CreateUserResponse>(_JSON);
                    break;
                case nameof(GetUsersResponse):
                    ret = JsonConvert.DeserializeObject<GetUsersResponse>(_JSON);
                    break;
                default:
                    throw new Exception("Switch doesn't handle the case for: " 
                        + _responseObjectType.Name + ". Method name:" + MethodBase.GetCurrentMethod().Name);
            }
            return ret;
        }
    }
}

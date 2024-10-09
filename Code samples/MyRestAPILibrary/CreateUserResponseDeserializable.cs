namespace MyRestAPILibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FinOpsRestAPILibrary;
    using Newtonsoft;
    using Newtonsoft.Json;
    using MyRestAPILibrary.ReqResModels;

    public class CreateUserResponseDeserializable : IDeserializable
    {
        private string _responseJSON = string.Empty;
        public CreateUserResponseDeserializable(string _JSON)
        {
            _responseJSON = _JSON;
        }
        public object deserialize()
        {
            return JsonConvert.DeserializeObject<CreateUserResponse>(this._responseJSON);
        }
    }
}

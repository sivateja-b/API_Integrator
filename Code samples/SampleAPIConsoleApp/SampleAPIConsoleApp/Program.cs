using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAPILibrary;
using MyAPILibrary.ReqResModels;
using RestSharp;
using FinOpsRestAPILibrary;
namespace SampleAPIConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyAPILibrary.SerializeDeserializeHelper serializeDeserializeHelper
                = new MyAPILibrary.SerializeDeserializeHelper();

            #region Sample GET
            Console.WriteLine("Sample GET...");
            RestResponse getUsersResponse = APIHelper.ExecuteAPIRequest
                ("https://reqres.in/", "/api/users?page=2", String.Empty, String.Empty, RestSharp.Method.GET);
            GetUsersResponse UsersFromAPI = serializeDeserializeHelper.DeserializeJSON(
                getUsersResponse.Content,typeof(GetUsersResponse)) as GetUsersResponse;
            foreach (User user in UsersFromAPI.data)
            {
                Console.WriteLine(user.email);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            #endregion

            #region Sample POST
            Console.WriteLine("Sample POST...");
            #region Serialize Create user request
            CreateUserRequest CreateUserRequest = new CreateUserRequest();
            Console.WriteLine("Input name...");
            CreateUserRequest.name = Console.ReadLine();
            Console.WriteLine("Input job...");
            CreateUserRequest.job = Console.ReadLine();
            string CreateUserReqJSON = SerializeDeserializeHelper.SerializeObject(CreateUserRequest);
            #endregion

            RestResponse createUserResponse = APIHelper.ExecuteAPIRequest
                ("https://reqres.in/", "/api/users", String.Empty, CreateUserReqJSON, RestSharp.Method.POST);
            CreateUserResponse userResponse = serializeDeserializeHelper.DeserializeJSON(createUserResponse.Content
                ,typeof(CreateUserResponse)) as CreateUserResponse;
            Console.WriteLine();
            Console.WriteLine("User created successfully...");
            Console.WriteLine("Name: " + userResponse.name);
            Console.WriteLine("Job: " + userResponse.job);
            Console.WriteLine("Id: " + userResponse.id);
            Console.WriteLine("Created at: " + userResponse.createdAt);
            Console.ReadKey();
            #endregion
        }
    }
}

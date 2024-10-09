namespace ConsoleApp_RestLibTest
{
    using System;
    using FinOpsRestAPILibrary;
    using RestSharp;
    using MyRestAPILibrary.ReqResModels;
    using MyRestAPILibrary;

    internal class Program
    {
        static void Main(string[] args)
        {
            Serializer serializer
               = new Serializer();

            #region Sample GET
            Console.WriteLine("Sample GET...");
            RestResponse getUsersResponse = APIHelper.ExecuteAPIRequest
                ("https://reqres.in/", "/api/users?page=2", String.Empty, String.Empty, RestSharp.Method.Get);
            IDeserializable deserializable = new GetUserResponseDeserializable(getUsersResponse.Content);
            GetUsersResponse UsersFromAPI = deserializable.deserialize() as GetUsersResponse;
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
            string CreateUserReqJSON = serializer.SerializeObject(CreateUserRequest);
            #endregion

            RestResponse createUserResponse = APIHelper.ExecuteAPIRequest
                ("https://reqres.in/", "/api/users", String.Empty, CreateUserReqJSON, RestSharp.Method.Post);
            deserializable = new CreateUserResponseDeserializable(createUserResponse.Content);
            CreateUserResponse userResponse = deserializable.deserialize() as CreateUserResponse;
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

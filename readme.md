NOTE: All this code is available in github samples folder of repository.

**NOTE!! Your solution will run but it might not be debuggable due to the DLL obfuscations. The supporting debugging is work in progress, look out for updates.**

1.	Create a .NET framework class library project and add the DLL references from github.
![image](https://user-images.githubusercontent.com/63949792/162920056-429d8fd3-4f37-4714-9dad-43b9ddfe860d.png)

TIP: If you are planning to maintain the code in version control. Create a new folder in your project  Paste the DLLs from github in that folder and add references.

2.	Add “using” for the 3 DLL namespaces.
 
3.	Serializing (Data contract to JSON) and Deserializing (JSON to Data contract) are the key concepts required for consuming an API. These concepts can be achieved by extending the class 
SerializeDeserializeAbstract
 ![image](https://user-images.githubusercontent.com/63949792/162920082-e260f4c0-151e-4c83-a251-b279afa16a14.png)

4.	Create a class implementation for SerializeDeserializeAbstract
 ![image](https://user-images.githubusercontent.com/63949792/162920121-662e92ba-2562-459d-b56e-6fa0cfd13c02.png)

5.	Identify your request and response models based on the API documentation, use JSON2C# site to create your C# models.
TIP: Always remember that your request models (Request data contracts) will be SERIALIZED, and your response models (Response data contracts) are used for DESERIALIZING.

6.	Implement the DeserializeJSON method based on your response models, the sample should look like this.
 ![image](https://user-images.githubusercontent.com/63949792/162920163-af0d41c7-afe3-40c4-81c8-292cf970a642.png)

TIP: The switch case in deserializeJSON method will keep on growing based on your response models and API requirements. This is the reason it is left as abstract.

7.	Build your class library project and consume it in your MVC app or D365 FO project or any other .NET supported projects.
 ![image](https://user-images.githubusercontent.com/63949792/162920187-29f7a6df-264c-43a7-a87f-b210139aaa73.png)


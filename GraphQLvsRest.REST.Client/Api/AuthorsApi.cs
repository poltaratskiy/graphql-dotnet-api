using System;
using System.Collections.Generic;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAuthorsApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="body"></param>
        /// <returns>Author</returns>
        Author ApiAuthorsAddauthorPut (AddAuthorRequest body);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Author</returns>
        Author ApiAuthorsGetauthorGet (int? id);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="template"></param>
        /// <returns>List&lt;Author&gt;</returns>
        List<Author> ApiAuthorsGetauthorsGet (string template);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AuthorsApi : IAuthorsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public AuthorsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthorsApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="body"></param>
        /// <returns>Author</returns>
        public Author ApiAuthorsAddauthorPut (AddAuthorRequest body)
        {
    
            var path = "/api/Authors/addauthor";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(body); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiAuthorsAddauthorPut: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiAuthorsAddauthorPut: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Author) ApiClient.Deserialize(response.Content, typeof(Author), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Author</returns>
        public Author ApiAuthorsGetauthorGet (int? id)
        {
    
            var path = "/api/Authors/getauthor";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (id != null) queryParams.Add("id", ApiClient.ParameterToString(id)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiAuthorsGetauthorGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiAuthorsGetauthorGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Author) ApiClient.Deserialize(response.Content, typeof(Author), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="template"></param>
        /// <returns>List&lt;Author&gt;</returns>
        public List<Author> ApiAuthorsGetauthorsGet (string template)
        {
    
            var path = "/api/Authors/getauthors";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (template != null) queryParams.Add("template", ApiClient.ParameterToString(template)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiAuthorsGetauthorsGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiAuthorsGetauthorsGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<Author>) ApiClient.Deserialize(response.Content, typeof(List<Author>), response.Headers);
        }
    
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ZyronatorCore.Settings;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using ZyronatorCore.Models;
using RestSharp.Deserializers;

namespace ZyronatorCore.Controllers
{
    [Route("api/discogsuserlists")]
    public class DiscogsUserListsController : Controller
    {
        private readonly RestClient _restClient;
        private readonly string _defaultDiscogsUser;

        public DiscogsUserListsController(IOptions<DiscogsApiSettings> discogsApiSettings)
        {
            _restClient = new RestClient
            {
                BaseUrl = new Uri(discogsApiSettings.Value.DefaultUri),
                UserAgent = discogsApiSettings.Value.UserAgent
            };

            _defaultDiscogsUser = discogsApiSettings.Value.DefaultDiscogsUser;
        }

        // GET: api/discogsuserlists
        [HttpGet]
        public IEnumerable<List> Get()
        {
            List<List> userLists = new List<List>();

            var request = new RestRequest();
            request.Resource = "users/{username}/lists";
            request.AddUrlSegment("username", _defaultDiscogsUser);

            IRestResponse response = _restClient.Execute(request);

            JsonDeserializer deserializer = new JsonDeserializer();
            var rootUserLists = deserializer.Deserialize<RootUserLists>(response);

            userLists.AddRange(rootUserLists.Lists);

            bool more = NextPage(rootUserLists);

            while (more == true)
            {
                Uri nextPageUri = new Uri(rootUserLists.Pagination.Urls.Next);

                _restClient.BaseUrl = nextPageUri;

                request = new RestRequest();

                response = _restClient.Execute(request);

                rootUserLists = deserializer.Deserialize<RootUserLists>(response);

                userLists.AddRange(rootUserLists.Lists);

                more = NextPage(rootUserLists);
            }

            return userLists;
        }

        private bool NextPage(RootUserLists rootUserLists)
        {
            int pages = rootUserLists.Pagination.Pages;
            int page = rootUserLists.Pagination.Page;

            if (page < pages)
            {
                return true;
            }

            return false;
        }

        // GET api/discogsuserlists/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/discogsuserlists
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/discogsuserlists/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/discogsuserlists/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using ZyronatorShared;

namespace ZyronatorCore.Controllers
{
    [Route("api/discogsuserlists")]
    [EnableCors("CorsGetPolicy")]
    public class DiscogsUserListsController : Controller
    {
        private readonly ZyronatorRestClient _restClient;

        public DiscogsUserListsController()
        {
            _restClient = new ZyronatorRestClient();
        }

        // GET: api/discogsuserlists
        [HttpGet]
        public IEnumerable<ZyronatorShared.DiscogsApiModels.List> Get()
        {
            DiscogsUserListFetcher listsFetcher = new DiscogsUserListFetcher(_restClient);

            List<ZyronatorShared.DiscogsApiModels.List> userLists = new List<ZyronatorShared.DiscogsApiModels.List>(listsFetcher.GetUserLists());

            return userLists;
        }

        // GET api/discogsuserlists/5
        [HttpGet("{id}")]
        public ZyronatorShared.DiscogsApiModels.DiscogsUserListDetail Get(int id)
        {
            DiscogsListDetailFetcher detailsFetcher = new DiscogsListDetailFetcher(_restClient);

            return detailsFetcher.Get(id);
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

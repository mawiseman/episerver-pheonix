using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Features.ImageUrlGenerator.Controllers
{
    public class ImageUrlGeneratorController : Controller
    {
        [Route(Constants.ImageUrlGeneratorRoute + "{text}", Name = "ImageUrlGeneratorIndex")]
        // GET: ImageUrlGenerator
        public ActionResult Index(string text)
        {
            // TODO: should probably put this code in a service

            // TODO: store in config?

            const string ROOT_PATH = "/assets/ImageUrlGenerator";
            const string URL_GENERATOR = "https://fakeimg.pl/120x90/ff5800/fff/?retina=1&text=";

            // check for an authenticated user
            // TODO: should probably tie this to roles and not just IsAuthenticated

            if (!User.Identity.IsAuthenticated)
                return new HttpUnauthorizedResult();

            string sourcePath = Server.MapPath(ROOT_PATH);

            if (!System.IO.Directory.Exists(sourcePath))
                System.IO.Directory.CreateDirectory(sourcePath);

            // get safe filename

            string safeFilename = text;

            foreach (var c in System.IO.Path.GetInvalidFileNameChars())
            {
                safeFilename = safeFilename.Replace(c.ToString(), "");
            }

            safeFilename += ".jpg";

            // prepare the final variables

            string filePath = System.IO.Path.Combine(sourcePath, safeFilename);
            string url = ROOT_PATH + "/" + safeFilename;

            // if a physical file does not exist

            if (!System.IO.File.Exists(filePath))
            {
                // download it

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(URL_GENERATOR + text), filePath);
                }
            }

            return Redirect(url);
        }
    }
}
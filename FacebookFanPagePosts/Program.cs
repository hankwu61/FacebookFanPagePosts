using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using System.IO;
using System.Web;
using System.Net.Http;
using System.Configuration;

namespace FacebookFanPagePosts
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            //var host = new JobHost();
            //// The following code ensures that the WebJob will be running continuously
            //host.RunAndBlock();

            RunAsync3().Wait();
        }

        //post to group wall
        static async Task RunAsync()
        {
            // Use HttpClient
            using (var client = new HttpClient())
            {
                //809985219212735/feed 空空分享社團
                //'https://graph.facebook.com/v2.12/{}/posts?limit=100&access_token=
                // Set variable values for post to facebook
                string uri = "https://graph.facebook.com/v2.12/" + ConfigurationManager.AppSettings["FacebookPageId"] + "/feed?";
                string accessToken = ConfigurationManager.AppSettings["FacebookAccessToken"];
                string link = "http://www.msdevz.com/news/article.aspx?id=5899&o=3";
                string picture = "http://news.kuwaittimes.net/website/wp-content/uploads/2015/11/microsoft.jpg";
                string name = "Microsoft Cloud Roadshow 2016 leads towards cloud innovation ";
                string description = "KT: Tell us something more about Microsoft Azure and new projects. Phillips: We recently introduced Azure, which marries our business intelligence capabilities and data visualization with learning in advance analytics with the ability to create applications.";

                // Formulate querystring for graph post
                StringContent queryString = new StringContent("access_token=" + accessToken + "&link=" + link + "&picture=" + picture + "&name=" + name + "&description=" + description);

                // Post to facebook /{page-id}/feed edge
                HttpResponseMessage response = await client.PostAsync(new Uri(uri), queryString);
                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    string postId = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(postId);
                    Console.ReadLine();
                }
            }
        }


        //wall comments
        static async Task RunAsync2()
        {
            // Use HttpClient
            using (var client = new HttpClient())
            {
                //809985219212735/feed 空空分享社團
                //809985219212735_809985762546014?fields=comments
                // Set variable values for post to facebook
                string uri = "https://graph.facebook.com/v2.12/809985219212735_809985762546014?fields=comments";
                string accessToken = ConfigurationManager.AppSettings["FacebookAccessToken"];
               // string link = "http://www.msdevz.com/news/article.aspx?id=5899&o=3";
               // string picture = "http://news.kuwaittimes.net/website/wp-content/uploads/2015/11/microsoft.jpg";
               // string name = "Microsoft Cloud Roadshow 2016 leads towards cloud innovation ";
              //  string description = "KT: Tell us something more about Microsoft Azure and new projects. Phillips: We recently introduced Azure, which marries our business intelligence capabilities and data visualization with learning in advance analytics with the ability to create applications.";

                // Formulate querystring for graph post
                StringContent queryString = new StringContent("access_token=" + accessToken + "&debug=all&fields=comments&format=json&method=get&pretty=0&suppress_http_code=1");

                // Post to facebook /{page-id}/feed edge
                HttpResponseMessage response = await client.PostAsync(new Uri(uri), queryString);
                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    string postId = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(postId);
                    Console.ReadLine();
                }
            }
        }


        //wall post data
        static async Task RunAsync3()
        {

            //search?q=p8image&type=group    搜尋社團id

            //search? q = himiwei814 & type = page 搜尋粉絲團id

           


            // Use HttpClient
            using (var client = new HttpClient())
            {
                //809985219212735/feed 空空分享社團
                //809985219212735_809985762546014?fields=comments
                // Set variable values for post to facebook
                string uri = "https://graph.facebook.com/v2.12/809985219212735?fields=feed";
                string accessToken = ConfigurationManager.AppSettings["FacebookAccessToken"];
                // string link = "http://www.msdevz.com/news/article.aspx?id=5899&o=3";
                // string picture = "http://news.kuwaittimes.net/website/wp-content/uploads/2015/11/microsoft.jpg";
                // string name = "Microsoft Cloud Roadshow 2016 leads towards cloud innovation ";
                //  string description = "KT: Tell us something more about Microsoft Azure and new projects. Phillips: We recently introduced Azure, which marries our business intelligence capabilities and data visualization with learning in advance analytics with the ability to create applications.";

                // Formulate querystring for graph post
                StringContent queryString = new StringContent("access_token=" + accessToken + "&debug=all&fields=feed&format=json&method=get&pretty=0&suppress_http_code=1");

                // Post to facebook /{page-id}/feed edge
                HttpResponseMessage response = await client.PostAsync(new Uri(uri), queryString);
                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    string postId = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(postId);
                    Console.ReadLine();
                }
            }
        }



    }
}

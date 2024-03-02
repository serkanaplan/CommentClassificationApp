using ClassificationApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClassificationApp.Controllers
{
    public class PredictionController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(CommentModel commentModel)
        {
            var sampleData = new MLModel.ModelInput()
            {
                Metin = commentModel.Text
            };

            var result = MLModel.Predict(sampleData);

            Console.WriteLine(result.PredictedLabel);

            commentModel.Result = Convert.ToInt32(result.PredictedLabel);

            return View(commentModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

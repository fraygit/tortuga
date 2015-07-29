using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tortuga.MongoData.Entities.Model;

namespace tortuga.Controllers
{
    public class DocumentController : Controller
    {
        //
        // GET: /Document/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DocumentEditor()
        {
            DocumentSchema document = new DocumentSchema();
            document.Name = "Inventory";
            var fieds = new List<Field>();
            fieds.Add(new Field
            {
                DataType = DataType.String,
                Name = "Item Name"
            });
            fieds.Add(new Field
            {
                DataType = DataType.String,
                Name = "Item Description"
            });


            var subProducts = new List<Field>();
            subProducts.Add(new Field { Name = "Name", DataType = DataType.String });
            subProducts.Add(new Field { Name = "Description", DataType = DataType.String });
            subProducts.Add(new Field { Name = "Quantity", DataType = DataType.Number });

            fieds.Add(new Field
            {
                DataType = DataType.Document,
                Name = "Sub Products",
                Fields = subProducts
            });
            document.Fields = fieds;

            return View(document);
        }

    }
}

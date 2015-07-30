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

        [HttpPost]
        public ActionResult ListFields(DocumentSchema documentSchema)
        {
            return View(documentSchema);
        }

        public ActionResult DocumentEditor()
        {
            DocumentSchema document = new DocumentSchema();
            document.Name = "Inventory";
            var fieds = new List<Field>();
            fieds.Add(new Field
            {
                DataType = DataType.String,
                Name = "Item Name",
                FieldGuid = Guid.NewGuid()
            });
            fieds.Add(new Field
            {
                DataType = DataType.String,
                Name = "Item Description",
                FieldGuid = Guid.NewGuid()
            });


            var subProducts = new List<Field>();
            subProducts.Add(new Field { Name = "Name", DataType = DataType.String, FieldGuid = Guid.NewGuid() });
            subProducts.Add(new Field { Name = "Description", DataType = DataType.String, FieldGuid = Guid.NewGuid() });
            subProducts.Add(new Field { Name = "Quantity", DataType = DataType.Number, FieldGuid = Guid.NewGuid() });

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

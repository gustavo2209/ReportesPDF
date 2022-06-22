using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Layout.Properties;
using iText.Kernel.Colors;

namespace ReportesPDF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HolaMundo()
        {
            HolaMundoCrea("C:/temp/hola.pdf");
            return File("C:/temp/hola.pdf", "application/pdf");
        }

        public virtual void HolaMundoCrea(string ruta)
        {
            PdfWriter writer = new PdfWriter(ruta);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            // ----------------------------------------------------

            document.Add(new Paragraph("Hola Mundo"));

            // ----------------------------------------------------
            document.Close();
        }

        public ActionResult Listas()
        {
            ListasCrea("C:/temp/listas.pdf");
            return File("C:/temp/listas.pdf", "application/pdf");
        }

        public virtual void ListasCrea(string ruta)
        {
            PdfWriter writer = new PdfWriter(ruta);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            // ----------------------------------------------------

            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            document.Add(new Paragraph("Varias lineas").SetFont(font));

            List list = new List().SetListSymbol("\u2022").SetFont(font);
            list.Add(new ListItem("Arriba Perú"));
            list.Add(new ListItem("C# Developer"));
            list.Add(new ListItem("Clases OnLine"));
            list.Add(new ListItem("Mañana es miércoles"));
            list.Add(new ListItem("Está bajando la temperatura"));
            list.Add(new ListItem("Última línea"));

            document.Add(list);

            // ----------------------------------------------------
            document.Close();
        }

        public ActionResult Imagenes()
        {
            ImagenesCrea("C:/temp/imagenes.pdf");
            return File("C:/temp/imagenes.pdf", "application/pdf");
        }

        public virtual void ImagenesCrea(string ruta)
        {
            PdfWriter writer = new PdfWriter(ruta);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            // ----------------------------------------------------

            Image img01 = new Image(ImageDataFactory.Create("C:/temp/images/img01.png"));
            Image img02 = new Image(ImageDataFactory.Create("C:/temp/images/img02.png"));

            Paragraph p = new Paragraph("Primera imagen")
                .Add(img01)
                .Add("Segunda imagen")
                .Add(img02);

            document.Add(p);

            // ----------------------------------------------------
            document.Close();
        }

        public ActionResult Tablas()
        {
            TablasCrea("C:/temp/tablas.pdf");
            return File("C:/temp/tablas.pdf", "application/pdf");
        }

        public virtual void TablasCrea(string ruta)
        {
            PdfWriter writer = new PdfWriter(ruta);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            // ----------------------------------------------------

            Table table = new Table(4);
            table.SetWidth(UnitValue.CreatePercentValue(100));

            table.AddCell("Alumno");
            table.AddCell("Nota 1");
            table.AddCell("Nota 2");
            table.AddCell("Nota 3");

            table.AddCell("Juan Pérez");
            table.AddCell("15");
            table.AddCell("16");
            table.AddCell("14");

            table.AddCell("Karla Torres");
            table.AddCell("17");
            table.AddCell("15");
            table.AddCell("15");

            document.Add(table);

            /* -------------------------------------------------------------------------------- */

            document.Add(new Paragraph());
            document.Add(new Paragraph());
            document.Add(new Paragraph());

            Table table2 = new Table(new float[] { 40f, 10f, 10f, 10f });
            table2.SetWidth(UnitValue.CreatePercentValue(100));

            table2.AddHeaderCell(new Cell()
                .SetTextAlignment(TextAlignment.CENTER)
                .SetBackgroundColor(new DeviceRgb(0, 140, 0))
                .Add(new Paragraph("Alumno").SetFontColor(new DeviceRgb(255, 255, 255))));
            table2.AddHeaderCell(new Cell()
                .SetBackgroundColor(new DeviceRgb(0, 140, 0))
                .Add(new Paragraph("Nota 1").SetFontColor(new DeviceRgb(255, 255, 255))));
            table2.AddHeaderCell(new Cell()
                .SetBackgroundColor(new DeviceRgb(0, 140, 0))
                .Add(new Paragraph("Nota 2").SetFontColor(new DeviceRgb(255, 255, 255))));
            table2.AddHeaderCell(new Cell()
                .SetBackgroundColor(new DeviceRgb(0, 140, 0))
                .Add(new Paragraph("Nota 3").SetFontColor(new DeviceRgb(255, 255, 255))));

            table2.AddCell("Juan Pérez");
            table2.AddCell(new Cell()
                .SetTextAlignment(TextAlignment.RIGHT)
                .Add(new Paragraph("15")));
            table2.AddCell(new Cell()
                .SetTextAlignment(TextAlignment.RIGHT)
                .Add(new Paragraph("16")));
            table2.AddCell(new Cell()
                .SetTextAlignment(TextAlignment.RIGHT)
                .Add(new Paragraph("14")));

            table2.AddCell("Karla Torres");
            table2.AddCell(new Cell()
                .SetTextAlignment(TextAlignment.RIGHT)
                .Add(new Paragraph("17")));
            table2.AddCell(new Cell()
                .SetTextAlignment(TextAlignment.RIGHT)
                .Add(new Paragraph("15")));
            table2.AddCell(new Cell()
                .SetTextAlignment(TextAlignment.RIGHT)
                .Add(new Paragraph("15")));

            document.Add(table2);

            /* -------------------------------------------------------------------------------- */

            document.Add(new Paragraph());
            document.Add(new Paragraph());
            document.Add(new Paragraph());

            Table table3 = new Table(3);
            table3.SetWidth(UnitValue.CreatePercentValue(100));

            table3.AddCell(new Cell(1, 3).Add(new Paragraph("colspan 3")));
            table3.AddCell(new Cell(2, 1).Add(new Paragraph("rowspan 2")));

            table3.AddCell("Cell");
            table3.AddCell("Cell");
            table3.AddCell("Cell");
            table3.AddCell("Cell");

            document.Add(table3);

            /* -------------------------------------------------------------------------------- */

            document.Add(new Paragraph());
            document.Add(new Paragraph());
            document.Add(new Paragraph());

            Table table4 = new Table(4);
            table4.SetWidth(UnitValue.CreatePercentValue(100));

            table4.AddCell(new Cell(1, 4).Add(new Paragraph("colspan 4")));
            table4.AddCell(new Cell(2, 1).Add(new Paragraph("rowspan 2")));
            table4.AddCell(new Cell(1, 1).Add(new Paragraph("cell")));
            table4.AddCell(new Cell(1, 1).Add(new Paragraph("cell")));
            table4.AddCell(new Cell(2, 1).Add(new Paragraph("rowspan 2")));
            table4.AddCell(new Cell(1, 1).Add(new Paragraph("cell")));
            table4.AddCell(new Cell(1, 1).Add(new Paragraph("cell")));
            table4.AddCell(new Cell(1, 4).Add(new Paragraph("colspan 4")));

            document.Add(table4);

            // ----------------------------------------------------
            document.Close();
        }

        public ActionResult Categorias()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;

namespace ClassLibrary1.Commands.LayOut
{
    [Transaction(TransactionMode.Manual)]
    public class CreateView : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            //Coger las vistas planta proyecto
            var views = new FilteredElementCollector(doc).WhereElementIsNotElementType().OfClass(typeof(ViewPlan)).ToList();
            using (var tx = new Transaction(doc, "Duplicate views"))
            {
                tx.Start();
                foreach (ViewPlan v in views)
                {
                    if (!v.Name.Contains("Plano"))
                    {
                        var newName = v.Name + "_DLS";
                        var fview = views.FirstOrDefault(x => x.Name == newName);
                        var borrar = v.Name;
                        if (fview == null)
                        {
                            var newView = v.Duplicate(ViewDuplicateOption.WithDetailing);
                            var nv = doc.GetElement(newView) as ViewPlan;
                            nv.Name = newName;
                        }
                    }
                }
                //DUPLICAR TODAS LAS VISTAS DE PROYECTO.
                //COMPROBAR QUE LAS VISTAS TIENEN PLANTILLA Y SI NO LA APLICAMOS. CAMBIAR LA ESCALA DE LA VISTA
                //PLANOS POR CADA VISTA DUPLICADA
                //AÑADIR VISTA AL PLANO Y PONER CENTRADA LA VISTA EN EL CAJETIN
                //RELLENAR PARAMETROS TIPICOS: DIBUAJADO, FECHA... 
                tx.Commit();
            }
            return Result.Succeeded;
        }
    }
}

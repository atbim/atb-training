using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ClassLibrary1
{
    class App : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            //Save dll route
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            //Create ribbon panel
            var panelName = "ATB Developments";
            application.CreateRibbonTab(panelName);

            var pnlApiTraining = application.CreateRibbonPanel(panelName, "Maquetación");
            Commands.LayOut.ButtonsOnPanel.CreateButtons(pnlApiTraining, thisAssemblyPath);

            return Result.Succeeded;
        }
    }
}

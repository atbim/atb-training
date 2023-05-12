using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ClassLibrary1.Commands.LayOut
{
    class ButtonsOnPanel
    {
        internal static void CreateButtons(RibbonPanel panel, string assemblyPath)
        {
            var btnCreateView = panel.AddItem(
                new PushButtonData(
                    "btnCreateView",
                    "Crear Vistas",
                    assemblyPath,
                    "ClassLibrary1.Commands.LayOut.CreateView")) as PushButton;
            btnCreateView.LargeImage = new BitmapImage(
                new Uri("pack://application:,,,/ClassLibrary1;component/Resources/ATB_Joker_WIP.png"));
        }
    }
}

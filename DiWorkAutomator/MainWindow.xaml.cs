using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiWorkAutomator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JsonWorkItemManager jsonWI;
        RequestWorkItemManager reqWI;
        DataManager data;

        public MainWindow()
        {
            InitializeComponent();
            data = new DataManager();
            jsonWI = new JsonWorkItemManager(data.GetUrlParent());
            reqWI = new RequestWorkItemManager(data.GetApiKey(), data.GetEndpointWorkItem());

            tbStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tbSprintName.Text = "DiWork\\" + DateTime.Now.ToString("dd-MM-yy") + " al " + DateTime.Now.AddDays(4).ToString("dd-MM-yy");
        }
        private async void btnDW_Click(object sender, RoutedEventArgs e)
        {
            string fechaInicioStr = tbStartDate.Text; //
            double tiempoTask = Convert.ToDouble(tbTaskTime.Text); //
            int cantDiasSprint = Convert.ToInt32(tbCantDays.Text); //
            string nombreSprint = tbSprintName.Text; //
            string email = tbAssignedTo.Text; //
            string CSId;

            double tiempoCS = tiempoTask * cantDiasSprint;

            var fecha = DateTime.ParseExact(fechaInicioStr, "dd/MM/yyyy", null);

            if (cbHasParent.IsChecked == true)
            {
                CSId = tbParent.Text;
            }
            else
            {
                var jsonCS = jsonWI.GetJsonOfDailyDWClientStory(fecha, email, nombreSprint, tiempoCS, cantDiasSprint);
                var responseCS = await reqWI.PostDailyClientStory(jsonCS);

                JObject jObject = JObject.Parse(responseCS);
                CSId = jObject["id"].Value<string>();
            }

            for (int i = 0; i < cantDiasSprint; i++)
            {
                var jsonT = jsonWI.GetJsonOfDailyDWTask(fecha, email, nombreSprint, CSId, tiempoTask);
                var responseT = await reqWI.PostDailyWorkItem(jsonT);

                fecha = fecha.AddDays(1);
            }
        }

        private async void btnGS_Click(object sender, RoutedEventArgs e)
        {
            string fechaInicioStr = tbStartDate.Text; //
            double tiempoTask = Convert.ToDouble(tbTaskTime.Text); //
            int cantDiasSprint = Convert.ToInt32(tbCantDays.Text); //
            string nombreSprint = tbSprintName.Text; //
            string email = tbAssignedTo.Text; //
            string CSId;

            double tiempoCS = tiempoTask * cantDiasSprint;

            var fecha = DateTime.ParseExact(fechaInicioStr, "dd/MM/yyyy", null);



            if(cbHasParent.IsChecked == true)
            {
                CSId = tbParent.Text;
            }
            else
            {
                var jsonCS = jsonWI.GetJsonOfDailyGSClientStory(fecha, email, nombreSprint, tiempoCS, cantDiasSprint);
                var responseCS = await reqWI.PostDailyClientStory(jsonCS);

                JObject jObject = JObject.Parse(responseCS);
                CSId = jObject["id"].Value<string>();
            }

            for (int i = 0; i < cantDiasSprint; i++)
            {
                var jsonT = jsonWI.GetJsonOfDailyGSTask(fecha, email, nombreSprint, CSId, tiempoTask);
                var responseT = await reqWI.PostDailyWorkItem(jsonT);

                fecha = fecha.AddDays(1);
            }
        }

        private async void btnPRU_Click(object sender, RoutedEventArgs e)
        {
            string fechaInicioStr = tbStartDate.Text; //
            double tiempoTask = Convert.ToDouble(tbTaskTime.Text); //
            int cantDiasSprint = Convert.ToInt32(tbCantDays.Text); //
            string nombreSprint = tbSprintName.Text; //
            string email = tbAssignedTo.Text; //
            string CSId;

            double tiempoCS = tiempoTask * cantDiasSprint;

            var fecha = DateTime.ParseExact(fechaInicioStr, "dd/MM/yyyy", null);



            if (cbHasParent.IsChecked == true)
            {
                CSId = tbParent.Text;
            }
            else
            {
                var jsonCS = jsonWI.GetJsonOfDailyPrudentialClientStory(fecha, email, nombreSprint, tiempoCS, cantDiasSprint);
                var responseCS = await reqWI.PostDailyClientStory(jsonCS);

                JObject jObject = JObject.Parse(responseCS);
                CSId = jObject["id"].Value<string>();
            }

            for (int i = 0; i < cantDiasSprint; i++)
            {
                var jsonT = jsonWI.GetJsonOfDailyPrudentialTask(fecha, email, nombreSprint, CSId, tiempoTask);
                var responseT = await reqWI.PostDailyWorkItem(jsonT);

                fecha = fecha.AddDays(1);
            }
        }

        private async void btnCAR_Click(object sender, RoutedEventArgs e)
        {
            string fechaInicioStr = tbStartDate.Text; //
            double tiempoTask = Convert.ToDouble(tbTaskTime.Text); //
            int cantDiasSprint = Convert.ToInt32(tbCantDays.Text); //
            string nombreSprint = tbSprintName.Text; //
            string email = tbAssignedTo.Text; //
            string CSId;

            double tiempoCS = tiempoTask * cantDiasSprint;

            var fecha = DateTime.ParseExact(fechaInicioStr, "dd/MM/yyyy", null);



            if (cbHasParent.IsChecked == true)
            {
                CSId = tbParent.Text;
            }
            else
            {
                var jsonCS = jsonWI.GetJsonOfDailyCardifClientStory(fecha, email, nombreSprint, tiempoCS, cantDiasSprint);
                var responseCS = await reqWI.PostDailyClientStory(jsonCS);

                JObject jObject = JObject.Parse(responseCS);
                CSId = jObject["id"].Value<string>();
            }

            for (int i = 0; i < cantDiasSprint; i++)
            {
                var jsonT = jsonWI.GetJsonOfDailyCardifTask(fecha, email, nombreSprint, CSId, tiempoTask);
                var responseT = await reqWI.PostDailyWorkItem(jsonT);

                fecha = fecha.AddDays(1);
            }
        }

        private void cbHasParent_Checked(object sender, RoutedEventArgs e)
        {
            tbParent.IsReadOnly = false;
            tbParent.Opacity = 1;
        }

        private void cbHasParent_Unchecked(object sender, RoutedEventArgs e)
        {
            tbParent.IsReadOnly = true;
            tbParent.Opacity = 0.3;
        }
    }
}

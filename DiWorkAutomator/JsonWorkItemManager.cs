using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiWorkAutomator
{
    internal class JsonWorkItemManager
    {
        public string UrlParent { get; private set; }

        public JsonWorkItemManager(string urlParent)
        {
            this.UrlParent = urlParent;
        }

        private string GetJsonOfWorkItem(string titulo, string descripcion, double remainingWork, double originalEstimate, string areaPath, string state, string activity, string tag, string assignedTo, string iterationPath, string parent)
        {
            List<Field> lFields = new List<Field>
            {
                new Field
                {
                    op = "add",
                    path = "/fields/System.Title",
                    value = titulo
                },

                new Field
                {
                    op = "add",
                    path = "/fields/System.Description",
                    value = descripcion
                },

                new Field
                {
                    op = "add",
                    path = "/fields/Microsoft.VSTS.Scheduling.RemainingWork",
                    value = remainingWork
                },

                new Field
                {
                    op = "add",
                    path = "/fields/Microsoft.VSTS.Scheduling.OriginalEstimate",
                    value = originalEstimate
                },

                new Field
                {
                    op = "add",
                    path = "/fields/System.AreaPath",
                    value = areaPath
                },

                new Field
                {
                    op = "add",
                    path = "/fields/System.State",
                    value = state
                },

                new Field
                {
                    op = "add",
                    path = "/fields/Microsoft.VSTS.Common.Activity",
                    value = activity
                },

                new Field
                {
                    op = "add",
                    path = "/fields/System.Tags",
                    value = tag
                },

                new Field
                {
                    op = "add",
                    path = "/fields/System.AssignedTo",
                    value = assignedTo
                },


                new Field
                {
                    op = "add",
                    path = "/fields/System.IterationPath",
                    value = iterationPath
                },

                new Field
                {
                    op = "add",
                    path = "/relations/-",
                    value = new
                    {
                        rel = "System.LinkTypes.Hierarchy-Reverse",
                        url = UrlParent + parent
                    }
                }
            };



            return JsonConvert.SerializeObject(lFields).ToString();
        }

        #region dw
        public string GetJsonOfDailyDWTask(DateTime fecha, string assignedTo, string sprint, string parent, double tiempo)
        {
            return GetJsonOfWorkItem
            (
                "Daily DiWork " + fecha.ToString("dd/MM"),
                "Reunión diaria de DiWork",
                0.5,
                0.5,
                "DiWork",
                "New",
                "DiWork Ceremony",
                "DIWORK",
                assignedTo,
                sprint,
                parent
            );
        }

        public string GetJsonOfDailyDWClientStory(DateTime fecha, string assignedTo, string sprint, double tiempo, int cantDias)
        {
            return GetJsonOfWorkItem
            (
                "Reuniones Diarias DiWork del " + fecha.ToString("dd/MM/yy") + " al " + fecha.AddDays(cantDias - 1).ToString("dd/MM/yy"),
                "Reuniones diarias de DiWork",
                tiempo,
                tiempo,
                "DiWork",
                "New",
                "DiWork Ceremony",
                "DIWORK",
                assignedTo,
                sprint,
                "3103"
            );
        }

        #endregion dw

        #region gs

        public string GetJsonOfDailyGSTask(DateTime fecha, string assignedTo, string sprint, string parent, double tiempo)
        {
            return GetJsonOfWorkItem
            (
                "Daily GS " + fecha.ToString("dd/MM"),
                "Reunión diaria de Galicia Seguros",
                tiempo,
                tiempo,
                "DiWork\\Galicia",
                "New",
                "Client Ceremony",
                "GALICIA",
                assignedTo,
                sprint,
                parent
            );
        }

        public string GetJsonOfDailyGSClientStory(DateTime fecha, string assignedTo, string sprint, double tiempo, int cantDias)
        {
            return GetJsonOfWorkItem
            (
                "Reuniones Diarias GS del " + fecha.ToString("dd/MM/yy") + " al " + fecha.AddDays(cantDias - 1).ToString("dd/MM/yy"),
                "Reuniones diarias de Galicia Seguros",
                tiempo,
                tiempo,
                "DiWork\\Galicia",
                "New",
                "Client Ceremony",
                "GALICIA",
                assignedTo,
                sprint,
                "3109"
            );
        }

        #endregion gs

        #region cardif

        public string GetJsonOfDailyCardifTask(DateTime fecha, string assignedTo, string sprint, string parent, double tiempo)
        {
            return GetJsonOfWorkItem
            (
                "Daily Cardif " + fecha.ToString("dd/MM"),
                "Reunión diaria de Cardif",
                tiempo,
                tiempo,
                "DiWork\\Cardif",
                "New",
                "Client Ceremony",
                "CARDIF",
                assignedTo,
                sprint,
                parent
            );
        }

        public string GetJsonOfDailyCardifClientStory(DateTime fecha, string assignedTo, string sprint, double tiempo, int cantDias)
        {
            return GetJsonOfWorkItem
            (
                "Reuniones Cardif " + fecha.ToString("dd-MM-yy") + " al " + fecha.AddDays(cantDias - 1).ToString("dd-MM-yy"),
                "Reuniones diarias de Cardif",
                tiempo,
                tiempo,
                "DiWork\\Cardif",
                "New",
                "DiWork Ceremony",
                "CARDIF",
                assignedTo,
                sprint,
                "1201"
            );
        }
        #endregion cardif

        #region prudential
        public string GetJsonOfDailyPrudentialTask(DateTime fecha, string assignedTo, string sprint, string parent, double tiempo)
        {
            return GetJsonOfWorkItem
            (
                "Daily Prudential Modulo de Siniestro " + fecha.ToString("dd/MM/yy"),
                "Reunión diaria de Prudential",
                tiempo,
                tiempo,
                "DiWork\\Prudential",
                "New",
                "Client Ceremony",
                "PRUDENTIAL",
                assignedTo,
                sprint,
                parent
            );
        }

        public string GetJsonOfDailyPrudentialClientStory(DateTime fecha, string assignedTo, string sprint, double tiempo, int cantDias)
        {
            return GetJsonOfWorkItem
            (
                "Reuniones diarias Prudential del " + fecha.ToString("dd/MM/yy") + " al " + fecha.AddDays(cantDias - 1).ToString("dd/MM/yy"),
                "Reuniones diarias de Prudential",
                tiempo,
                tiempo,
                "DiWork\\Prudential",
                "New",
                "Client Ceremony",
                "PRUDENTIAL",
                assignedTo,
                sprint,
                "1659"
            );
        }
        #endregion prudential

        //Daily Prudential Modulo de Siniestro 18/01/2023 09:30
        //Daily Cardif 20/01
        //Reuniones Cardif 09-01-22 al 13-01-22
        //1659
    }
}

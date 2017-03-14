using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.DataVisualization;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Globalization;
using Exemplo_grafico.Models;

namespace Exemplo_grafico.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult MostrarGraficoPersonalizado()
        {

            List<LogsViewModels> MeusLogs = new List<LogsViewModels>();
            //Preenchendo qualquer dado para exibir no gráfico
            //Substitua por seu método para buscar as informações e preenchar a model
            Random rand = new Random();
            for(int i = 0; i < 20; i++)
            {
                LogsViewModels auxLog = new LogsViewModels();
                auxLog.CodigoLog = i;
                auxLog.Dia = DateTime.Now.AddMonths(rand.Next(5)).AddDays(i).AddSeconds(rand.Next(1000)).AddMinutes(rand.Next(60));
                auxLog.QtdeAcessos = i + rand.Next(200);
                MeusLogs.Add(auxLog);
            }

            Chart chart = MostrarGrafico(MeusLogs);

            MemoryStream ms = new MemoryStream();
            chart.SaveImage(ms);

            return File(ms.GetBuffer(), @"image/png");
        }

        private Chart MostrarGrafico(List<LogsViewModels> DadosLogsErros)
        {
            var chart = new Chart();
            chart.Width = 930;
            chart.Height = 600;
            chart.BackColor = Color.FromArgb(211, 223, 240);
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BackSecondaryColor = Color.White;
            chart.BackGradientStyle = GradientStyle.TopBottom;
            chart.BorderlineWidth = 1;
            chart.Palette = ChartColorPalette.BrightPastel;
            chart.BorderlineColor = Color.FromArgb(26, 59, 105);
            chart.RenderType = RenderType.BinaryStreaming;
            chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            chart.AntiAliasing = AntiAliasingStyles.All;
            chart.TextAntiAliasingQuality = TextAntiAliasingQuality.Normal;
            chart.Titles.Add(CreateTitle("Quantidade de acessos por dia"));
            chart.Series.Add(CreateSeries(SeriesChartType.Bar, DadosLogsErros));
            chart.ChartAreas.Add(CreateChartArea());

            return chart;
        }

        public Title CreateTitle(String titulo)
        {
            Title title = new Title
            {
                Text = titulo,
                ShadowColor = Color.FromArgb(32, 0, 0, 0),
                Font = new Font("Trebuchet MS", 14F, FontStyle.Bold),
                ShadowOffset = 3,
                ForeColor = Color.FromArgb(26, 59, 105)
            };

            return title;
        }

        public Series CreateSeries(SeriesChartType chartType, ICollection<LogsViewModels> list)
        {
            var series = new Series
            {
                Name = "Gráfico de histórico de acessos",
                IsValueShownAsLabel = true,
                Color = Color.FromArgb(198, 99, 99),
                ChartType = chartType,
                BorderWidth = 2
            };

            List<Color> Cores = ColorList();
            int i = 0;
            foreach (var item in list)
            {
                var point = new DataPoint
                {
                    AxisLabel = item.Dia.ToString(),
                    YValues = new double[] { Convert.ToDouble(item.QtdeAcessos) }
                };

                series.Points.Add(point);
            }

            foreach (var element in series.Points)
            {
                element.Color = Cores[i];
                i++;
            }

            return series;
        }

        public ChartArea CreateChartArea()
        {
            var chartArea = new ChartArea();
            chartArea.Name = "Gráfico de histórico de acessos";
            chartArea.BackColor = Color.Transparent;
            chartArea.AxisX.IsLabelAutoFit = false;
            chartArea.AxisY.IsLabelAutoFit = false;
            chartArea.AxisX.LabelStyle.Font = new Font("Verdana,Arial,Helvetica,sans-serif", 8F, FontStyle.Regular);
            chartArea.AxisY.LabelStyle.Font = new Font("Verdana,Arial,Helvetica,sans-serif", 8F, FontStyle.Regular);
            chartArea.AxisY.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.Interval = 1;

            return chartArea;
        }

        public Legend CreateLegend()
        {
            var legend = new Legend
            {
                Name = "Gráfico de histórico de acessos",
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                BackColor = Color.Transparent,
                Font = new Font(new FontFamily("Trebuchet MS"), 9),
                LegendStyle = LegendStyle.Row
            };

            return legend;
        }

        public List<Color> ColorList()
        {
            List<Color> listaCores = new List<Color>();
            listaCores.Add(Color.FromArgb(200, 0, 0, 205));
            listaCores.Add(Color.FromArgb(200, 139, 0, 0));
            listaCores.Add(Color.FromArgb(200, 0, 100, 0));
            listaCores.Add(Color.FromArgb(200, 148, 0, 211));
            listaCores.Add(Color.FromArgb(200, 105, 105, 105));
            listaCores.Add(Color.FromArgb(200, 255, 0, 0));
            listaCores.Add(Color.FromArgb(200, 210, 105, 30));
            listaCores.Add(Color.FromArgb(200, 178, 34, 34));
            listaCores.Add(Color.FromArgb(200, 70, 130, 180));
            listaCores.Add(Color.FromArgb(200, 240, 230, 140));
            listaCores.Add(Color.FromArgb(200, 65, 105, 225));
            listaCores.Add(Color.FromArgb(200, 154, 205, 50));
            listaCores.Add(Color.FromArgb(200, 184, 134, 11));
            listaCores.Add(Color.FromArgb(200, 255, 105, 180));
            listaCores.Add(Color.FromArgb(200, 255, 140, 0));
            listaCores.Add(Color.FromArgb(200, 47, 79, 79));
            listaCores.Add(Color.FromArgb(200, 128, 128, 0));
            listaCores.Add(Color.FromArgb(200, 139, 69, 19));
            listaCores.Add(Color.FromArgb(200, 147, 112, 219));
            listaCores.Add(Color.FromArgb(200, 0, 191, 255));
            listaCores.Add(Color.FromArgb(200, 198, 99, 99));
            //repetir cores (crie outra lógica se seu gráfico pode possuir muitas colunas)
            listaCores.Add(Color.FromArgb(200, 0, 0, 205));
            listaCores.Add(Color.FromArgb(200, 139, 0, 0));
            listaCores.Add(Color.FromArgb(200, 0, 100, 0));
            listaCores.Add(Color.FromArgb(200, 148, 0, 211));
            listaCores.Add(Color.FromArgb(200, 105, 105, 105));
            listaCores.Add(Color.FromArgb(200, 255, 0, 0));
            listaCores.Add(Color.FromArgb(200, 210, 105, 30));
            listaCores.Add(Color.FromArgb(200, 178, 34, 34));
            listaCores.Add(Color.FromArgb(200, 70, 130, 180));
            listaCores.Add(Color.FromArgb(200, 240, 230, 140));
            listaCores.Add(Color.FromArgb(200, 65, 105, 225));
            listaCores.Add(Color.FromArgb(200, 154, 205, 50));
            listaCores.Add(Color.FromArgb(200, 184, 134, 11));
            listaCores.Add(Color.FromArgb(200, 255, 105, 180));
            listaCores.Add(Color.FromArgb(200, 255, 140, 0));
            listaCores.Add(Color.FromArgb(200, 47, 79, 79));
            listaCores.Add(Color.FromArgb(200, 128, 128, 0));
            listaCores.Add(Color.FromArgb(200, 139, 69, 19));
            listaCores.Add(Color.FromArgb(200, 147, 112, 219));
            listaCores.Add(Color.FromArgb(200, 0, 191, 255));
            listaCores.Add(Color.FromArgb(200, 198, 99, 99));
            return listaCores;
        }
    }
}